using AuthApi.DTO;
using AuthApi.HttpResponse;
using AuthApi.Services.AuthService;
using Microsoft.AspNetCore.Mvc;

namespace AuthApi.Controller;

[ApiController]
[Route("api/authentication/")]
public class AuthController(IAuthService authService) : ControllerBase
{
    [HttpPost("login")]
    public async Task<ActionResult<HttpResponse<string>>> Login(ConnectUserDto userDto)
    {
        var response = new HttpResponse<string>();

        try
        {
            response.Response = await authService.Login(userDto);
        }
        catch (HttpResponseException e)
        {
            response.HttpCode = e.StatusCode;
            response.ErrorMessage = e.Message;
        }

        return new HttpResponseHandler().Handle(response);
    } 
}