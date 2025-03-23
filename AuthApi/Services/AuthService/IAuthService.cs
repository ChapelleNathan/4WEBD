using AuthApi.DTO;

namespace AuthApi.Services.AuthService;

public interface IAuthService
{
    public Task<string> Login(ConnectUserDto userDto);
}