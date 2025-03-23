using AuthApi.DTO;

namespace AuthApi.Services.web.UserWebService;

public interface IUserWebService
{
    Task<UserDto?> GetUser(ConnectUserDto connectUserDto);
}