using SharedKernel.DTO;
using SharedKernel.Models;

using System.Net.Http.Json;

namespace Services;
public class IdentityService(HttpClient httpClient)
{
    public async Task<bool> RegisterUserAsync(WegesUserDTO model)
    {
        var response = await httpClient.PostAsJsonAsync("/register", model);
        return response.IsSuccessStatusCode;
    }


    public async Task<string> LoginAsync(LoginModel model)
    {
        var response = await httpClient.PostAsJsonAsync("/login", model);
        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadFromJsonAsync<LoginResponseModel>();
            return result?.Token;
        }
        return null;
    }

    public async Task<bool> LogoutAsync()
    {
        var response = await httpClient.PostAsync("/logout", null);
        return response.IsSuccessStatusCode;
    }
}

public class LoginResponseModel
{
    public string? Token { get; set; }
}
