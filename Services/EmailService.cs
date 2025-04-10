using Microsoft.Extensions.Options;

using System.Net;
using System.Net.Mail;

namespace Services;
public class EmailService(IOptions<EmailConfiguracoes> options) : IEmailService
{
    private readonly EmailConfiguracoes _options = options.Value;


    /// <summary>
    /// Envia o email.
    /// </summary>
    /// <param name="paras">The recipientes.</param>
    /// <param name="ccs">The ccs.</param>
    /// <param name="bccs">The bccs.</param>
    /// <param name="placeHolders">The place holders.</param>
    /// <param name="templatePath">The template path.</param>
    /// <returns>A bool.</returns>
    public Task<bool> EnviarEmail(
        List<string> paras
        , Dictionary<string, string> placeHolders
        , string templatePath
        , List<string>? ccs = null
        , List<string>? bccs = null)
    {
        try
        {
            if (string.IsNullOrEmpty(templatePath))
                throw new Exception("Template email em falta.");


            // Load and parse the template with placeholders
            var body = CarregarTemplate(templatePath, placeHolders);

            SmtpClient client = new SmtpClient(_options.Host)
            {
                Port = _options.Port,
                EnableSsl = _options.UseSSL,
                Credentials = new NetworkCredential(_options.UserName, _options.Password)
            };

            MailMessage mail = new MailMessage()
            {
                From = new MailAddress(_options.Email, _options.Name),
                Subject = _options.DefaultSubject,
                Body = body,
                IsBodyHtml = true, // Set to true if you want to send HTML email
            };

            if (bccs is not null)
            {
                foreach (string bcc in bccs)
                {
                    mail.Bcc.Add(bcc);
                }
            }

            if (ccs is not null)
            {
                foreach (string cc in ccs)
                {
                    mail.CC.Add(cc);

                }
            }

            foreach (string para in paras)
            {
                mail.To.Add(para);
            }


            client.SendMailAsync(mail);

            return Task.FromResult(true);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            return Task.FromResult(false);
        }
    }

    /// <summary>
    /// Carrega o template com os valores passados via parâmetro.
    /// </summary>
    /// <param name="templatePath">The template path.</param>
    /// <param name="placeholders">The placeholders.</param>
    /// <returns>A string.</returns>
    private string CarregarTemplate(string templatePath, Dictionary<string, string> placeholders)
    {
        var templateContent = File.ReadAllText(templatePath);

        foreach (var placeholder in placeholders)
        {
            templateContent = templateContent.Replace($"{placeholder.Key}", placeholder.Value);
        }

        return templateContent;
    }
}
