using UserApi.DTO;
using UserApi.Models;

namespace UserApi.Services.UserService;

public interface IUserService
{
    public Task<User> CreateUser(CreateUserDto createdUser);
    public Task<User> GetUserById(string id, AppUserDto appUserDto);
    public Task<User> DeleteUserById(string id, AppUserDto appUserDto);
    public Task<User> UpdateUser(UpdatedUserDto updatedUserDto, AppUserDto appUserDto);
    public Task<List<User>> GetAllUsers();
}