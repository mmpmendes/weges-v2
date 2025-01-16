using SharedKernel.DTO;

using System.Net.Http.Json;

namespace Services;
public class IdentityService(HttpClient httpClient)
{
    public async Task<bool> RegisterUserAsync(WegesLoginDTO model)
    {
        if (model.Password == model.ConfirmPassword)
        {
            var response = await httpClient.PostAsJsonAsync("/register", model);

            return response.IsSuccessStatusCode;
        }
        return false;
    }


    public async Task<string> LoginAsync(WegesLoginDTO model)
    {

        var response = await httpClient.PostAsJsonAsync("/login", model);
        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadFromJsonAsync<LoginResponseModel>();
            return result?.Token;

        }
        return String.Empty;
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
