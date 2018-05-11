using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PH.Site.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

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
                List<ErrorResult> list = new List<ErrorResult>();
                int i = 0;
                foreach (var item in context.ModelState.Values)
                {
                    foreach (var error in item.Errors)
                    {
                        ErrorResult result = new ErrorResult();
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
