using UserApi.Enum;

namespace UserApi.DTO;

public class UserDto
{
    public required string Id { get; init; }
    public required string Firstname { get; set; }
    public required string Lastname { get; set; }
    public required string Email { get; set; }
    public required RoleEnum Role { get; set; }
}

public class CreateUserDto
{
    public required string Firstname { get; set; }
    public required string Lastname { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
}

public class UpdatedUserDto : CreateUserDto
{
    public required string Id { get; init; }
}

public class ConnectUserDto
{
    public required string Email { get; set; }
    public required string Password { get; set; }
}