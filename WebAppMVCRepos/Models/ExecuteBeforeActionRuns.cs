using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebAppMVCRepos.Models
{
    public class ExecuteBeforeActionRuns : ActionFilterAttribute

    {

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var res = context.HttpContext.Session.GetString("useremail");
            if (res == null)
            {
                context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary
                    {
                        { "controller", "UsersOps" },
                        { "action", "Login" }
                    }
                    );
                // goback to login 
            }
        }
    }
}
