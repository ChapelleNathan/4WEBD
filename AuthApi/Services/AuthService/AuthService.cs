using AuthApi.DTO;
using AuthApi.Enum;
using AuthApi.Helper;
using AuthApi.HttpResponse;
using AuthApi.Services.web.UserWebService;

namespace AuthApi.Services.AuthService;

public class AuthService(AuthHelper authHelper, IUserWebService userWebService) : IAuthService
{
    public async Task<string> Login(ConnectUserDto userDto)
    {
        var user = await userWebService.GetUser(userDto);
        if (user is null || !BCrypt.Net.BCrypt.Verify(userDto.Password, user.Password))
            throw new HttpResponseException(401, ErrorHelper.GetErrorMessage(ErrorEnum.Sup401WrongCredential));

        return authHelper.GenerateToken(user);
    }
}