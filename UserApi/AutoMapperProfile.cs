using AutoMapper;
using UserApi.DTO;
using UserApi.Models;

namespace UserApi;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<UserDto, User>()
            .ForMember(dest => dest.Password, opt => opt.Ignore())
            .ReverseMap();
        CreateMap<CreateUserDto, User>()
            .ReverseMap();
        CreateMap<User, UserDto>()
            .ReverseMap();
        CreateMap<UpdatedUserDto, User>()
            .ReverseMap();
    }
}