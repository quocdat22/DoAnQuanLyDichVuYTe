using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
namespace DoAn.Models
{
    public class Authentication:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if(context.HttpContext.Session.GetString("TenTk") == null)
            {
                context.Result = new RedirectResult("/Access/Login");
            }
            base.OnActionExecuting(context);
        }
    }
}
