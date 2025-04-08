using ApiModel.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace Services;
public class CustomEmailSender(IEmailService emailService, IConfiguration configuration) : IEmailSender<WegesUser>
{
    private readonly IEmailService _emailService = emailService;
    private readonly IConfiguration _configuration = configuration;

    public async Task SendConfirmationLinkAsync(WegesUser user, string email, string confirmationLink)
    {
        await _emailService.EnviarEmail(new List<string> { email }, new Dictionary<string, string> { { "{{{{{emailConfirmationLink}}}}}", confirmationLink } }, _configuration.GetSection("EmailTemplates:ConfirmacaoEmailTemplate").Value!);
    }

    public async Task SendPasswordResetCodeAsync(WegesUser user, string email, string resetCode)
    {
        await _emailService.EnviarEmail(new List<string> { email }, new Dictionary<string, string> { { "{{{{{{resetCode}}}}}", resetCode } }, _configuration.GetSection("EmailTemplates:ResetPasswordCodeTemplate").Value!);
    }

    public async Task SendPasswordResetLinkAsync(WegesUser user, string email, string resetLink)
    {
        await _emailService.EnviarEmail(new List<string> { email }, new Dictionary<string, string> { { "{{{{{emailResetLink}}}}}", resetLink } }, _configuration.GetSection("EmailTemplates:ResetPasswordLinkTemplate").Value!);
    }
}
