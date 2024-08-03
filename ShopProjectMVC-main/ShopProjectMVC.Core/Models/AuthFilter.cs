using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public class AuthFilter : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var user = context.HttpContext.Session.GetString("user");

        if (string.IsNullOrEmpty(user))
        {
            context.Result = new RedirectToActionResult("Login","User",null);
        }

        base.OnActionExecuting(context);
    }
}
