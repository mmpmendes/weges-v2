using System.Net.Http.Json;

using weges_v2.SharedKernel.Models;

namespace weges_v2.Services;
public class UserManagementService(HttpClient httpClient)
{
    public async Task<HttpResponseMessage> RegisterUserAsync(RegisterModel userRegister, CancellationToken cancellationToken = default)
    {
        var response = await httpClient.PostAsJsonAsync("/register", userRegister, cancellationToken);
        return response;
    }

    public async Task<HttpResponseMessage> LoginUserAsync(LoginModel userLogin, CancellationToken cancellationToken = default)
    {
        var response = await httpClient.PostAsJsonAsync("/login", userLogin, cancellationToken);
        return response;
    }

    public async Task<HttpResponseMessage> RefreshTokenAsync(string refreshToken, CancellationToken cancellationToken = default)
    {
        var response = await httpClient.PostAsJsonAsync("/refresh", new { refreshToken }, cancellationToken);
        return response;
    }

    //public async Task<HttpResponseMessage> ConfirmEmailAsync(ConfirmationModel confirmationModel, CancellationToken cancellationToken = default)
    //{
    //    var response = await httpClient.GetFromJsonAsync<ConfirmationModel>("/confirmEmail", { confirmationModel }, cancellationToken);
    //    return response;
    //}

    public async Task<HttpResponseMessage> ResendConfirmationEmail(string email, string token, CancellationToken cancellationToken = default)
    {
        var response = await httpClient.PostAsJsonAsync("/ResendConfirmationEmail", new { email, token }, cancellationToken);
        return response;
    }

    public async Task<UserInfo?> GetUserInfoAsync(string accessToken, CancellationToken cancellationToken = default)
    {
        var response = await httpClient.GetFromJsonAsync<UserInfo>("/manage/info", cancellationToken);
        return response;
    }




    public async Task<HttpResponseMessage> LogoutUserAsync(string accessToken, CancellationToken cancellationToken = default)
    {
        var response = await httpClient.PostAsJsonAsync("/logout", new { accessToken }, cancellationToken);
        return response;
    }



    public async Task<HttpResponseMessage> ForgotPasswordAsync(string email, CancellationToken cancellationToken = default)
    {
        var response = await httpClient.PostAsJsonAsync("/forgot-password", new { email }, cancellationToken);
        return response;
    }

    public async Task<HttpResponseMessage> ResetPasswordAsync(string email, string token, string password, CancellationToken cancellationToken = default)
    {
        var response = await httpClient.PostAsJsonAsync("/reset-password", new { email, token, password }, cancellationToken);
        return response;
    }

    public async Task<HttpResponseMessage> TwoFactorLoginAsync(LoginModel userLogin, CancellationToken cancellationToken = default)
    {
        var response = await httpClient.PostAsJsonAsync("/two-factor-login", userLogin, cancellationToken);
        return response;
    }

    public async Task<HttpResponseMessage> TwoFactorRecoveryAsync(LoginModel userLogin, CancellationToken cancellationToken = default)
    {
        var response = await httpClient.PostAsJsonAsync("/two-factor-recovery", userLogin, cancellationToken);
        return response;
    }

    public async Task<HttpResponseMessage> TwoFactorRecoveryCodeAsync(LoginModel userLogin, CancellationToken cancellationToken = default)
    {
        var response = await httpClient.PostAsJsonAsync("/two-factor-recovery-code", userLogin, cancellationToken);
        return response;
    }
}
