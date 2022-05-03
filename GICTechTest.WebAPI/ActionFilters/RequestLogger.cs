using Microsoft.AspNetCore.Mvc.Filters;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GICTechTest.WebAPI.ActionFilters
{
    public class RequestLogger : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Log.Information("API endpoint called - " + context.HttpContext.Request.Path.Value + context.HttpContext.Request.QueryString);
        }
    }
}
