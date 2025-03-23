using System.Net;
using AuthApi.DTO;
using AuthApi.Enum;
using AuthApi.Helper;
using AuthApi.HttpResponse;

namespace AuthApi.Services.web.UserWebService;

public class UserWebService(HttpClient httpClient, ILogger<UserWebService> logger) : IUserWebService
{
    public async Task<UserDto?> GetUser(ConnectUserDto connectUserDto)
    {
        try
        {
            var response = await httpClient.PostAsJsonAsync("http://localhost/8000/api/user/by-email", connectUserDto.Email);
            if(response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<UserDto>();
            if(response.StatusCode == HttpStatusCode.NotFound)
                return null;
            
            logger.LogError("Erreur lors de la validation des credentials: {StatusCode}", response.StatusCode);
            throw new HttpResponseException(401, ErrorHelper.GetErrorMessage(ErrorEnum.Sup401WrongCredential));
        }
        catch (Exception e)
        {
            logger.LogError(e, "Exception lors de l'appel au UserService");
            throw;
        }
    }
}