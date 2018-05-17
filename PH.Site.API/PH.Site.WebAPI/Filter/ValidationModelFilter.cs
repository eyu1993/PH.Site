using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PH.Site.WebAPI.Models;
using System.Collections.Generic;
using System.Net;

namespace PH.Site.WebAPI.Filter
{
    public class ValidationModelFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                List<Result> list = new List<Result>();
                int i = 0;
                foreach (var item in context.ModelState.Values)
                {
                    foreach (var error in item.Errors)
                    {
                        Result result = new Result();
                        result.Error = ++i;
                        result.Message = error.ErrorMessage;
                        list.Add(result);
                    }
                }
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.HttpContext.Response.ContentType = "application/json";
                context.Result = new JsonResult(list);
            }
        }
    }
}
