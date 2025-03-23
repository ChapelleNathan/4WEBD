using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserApi.DTO;
using UserApi.HttpResponse;
using UserApi.Services.UserService;

namespace UserApi.Controllers;

[ApiController]
[Route("/api/user")]
public class UserController(IMapper mapper, IUserService userService) : ControllerBase
{
    [HttpGet("{id}")]
    [Authorize]
    public async Task<ActionResult<HttpResponse<UserDto>>> GetUser(string id, AppUserDto user)
    {
        var httpResponse = new HttpResponse<UserDto>();
        try
        {
            httpResponse.Response = mapper.Map<UserDto>(await userService.GetUserById(id, user));
        }
        catch (HttpResponseException e)
        {
            httpResponse.ErrorMessage = e.Message;
            httpResponse.HttpCode = e.StatusCode;
        }
        
        return new HttpResponseHandler().Handle(httpResponse);
    }

    [HttpPost]
    public async Task<ActionResult<HttpResponse<UserDto>>> CreateUser(CreateUserDto createUserDto)
    {
        var httpResponse = new HttpResponse<UserDto>();
        try
        {
            httpResponse.Response = mapper.Map<UserDto>(await userService.CreateUser(createUserDto));
        }
        catch (HttpResponseException e)
        {
            httpResponse.ErrorMessage = e.Message;
            httpResponse.HttpCode = e.StatusCode;
        }

        return new HttpResponseHandler().Handle(httpResponse);
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult<HttpResponse<UserDto>>> DeleteUser(string id, AppUserDto user)
    {
        var httpResponse = new HttpResponse<UserDto>();
        try
        {
            httpResponse.Response = mapper.Map<UserDto>(await userService.DeleteUserById(id, user));
        }
        catch (HttpResponseException e)
        {
            httpResponse.HttpCode = e.StatusCode;
            httpResponse.ErrorMessage = e.Message;
        }

        return new HttpResponseHandler().Handle(httpResponse);
    }

    [HttpPut("update")]
    [Authorize]
    public async Task<ActionResult<HttpResponse<UserDto>>> UpdateUser([FromBody]UpdatedUserDto updatedUserDto,[FromHeader] AppUserDto user)
    {
        var httpResponse = new HttpResponse<UserDto>();
        try
        {
            httpResponse.Response = mapper.Map<UserDto>(await userService.UpdateUser(updatedUserDto, user));
        }
        catch (HttpResponseException e)
        {
            httpResponse.HttpCode = e.StatusCode;
            httpResponse.ErrorMessage = e.Message;
        }

        return new HttpResponseHandler().Handle(httpResponse);
    }

    [HttpGet]
    public async Task<ActionResult<HttpResponse<List<UserDto>>>> GetAllUsers()
    {
        var httpResponse = new HttpResponse<List<UserDto>>();
        try
        {
            var users = await userService.GetAllUsers();
            httpResponse.Response = users.Select(mapper.Map<UserDto>).ToList();
        }
        catch (Exception e)
        {
            httpResponse.ErrorMessage = e.Message;
            httpResponse.HttpCode = 500;
        }

        return new HttpResponseHandler().Handle(httpResponse);
    }
}