using Microsoft.EntityFrameworkCore;
using UserApi.Data;
using UserApi.Models;

namespace UserApi.Repositories.UserRepositories;

public class UserRepository(DataContext context) : IUserRepository
{
    public async Task<User> CreateUser(User user)
    {
        var newUser = await context.Users.AddAsync(user);
        return newUser.Entity;
    }

    public async Task<User?> GetOneUserById(string id)
    {
        return await context.Users.FindAsync(id);
    }

    public User DeleteUserById(User user)
    {
        var deletedUser = context.Users.Remove(user);
        Save();
        return deletedUser.Entity;
    }

    public User UpdateUser(User user)
    {
        var updatedUser = context.Users.Update(user);
        Save();
        return updatedUser.Entity;
    }

    public async Task<List<User>> GetAllUsers()
    {
        return await context.Users.ToListAsync();
    }

    public async Task<User?> GetUserByEmail(string email)
    {
        return await context.Users.FirstOrDefaultAsync(u => u.Email.Equals(email));
    }

    public void Save()
    {
        context.SaveChanges();
    }
}