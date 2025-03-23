using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using UserApi.Enum;
using UserApi.Helper;
using UserApi.HttpResponse;

namespace UserApi.Filter;

public class AdminFilter : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var httpContext = context.HttpContext;
        var role = httpContext.User.FindFirst(ClaimTypes.Role)?.Value;
        if (role is null || RoleEnum.User.ToString().Equals(role))
        {
            var response = new HttpResponse<object>()
            {
                Response = null,
                HttpCode = 401,
                ErrorMessage = ErrorHelper.GetErrorMessage(ErrorEnum.Sup401Authorization)
            };
            context.Result = new ObjectResult(response)
            {
                StatusCode = StatusCodes.Status401Unauthorized
            };
            return;
        }
        
        base.OnActionExecuting(context);
    }
}