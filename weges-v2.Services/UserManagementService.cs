using System.Net.Http.Json;

using weges_v2.SharedKernel.Models;

namespace weges_v2.Services;
public class UserManagementService(HttpClient httpClient)
{
    public async Task<HttpResponseMessage> RegisterUserAsync(RegisterModel userRegister, CancellationToken cancellationToken = default)
    {
        var response = await httpClient.PostAsJsonAsync("/register", userRegister, cancellationToken);
        response.EnsureSuccessStatusCode();
        return response;
    }

    public async Task<HttpResponseMessage> LoginUserAsync(LoginModel userLogin, CancellationToken cancellationToken = default)
    {
        var response = await httpClient.PostAsJsonAsync("/login", userLogin, cancellationToken);
        response.EnsureSuccessStatusCode();
        return response;
    }
}
