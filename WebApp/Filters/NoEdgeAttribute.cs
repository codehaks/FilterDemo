using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Filters
{
    public class NoEdgeAttribute : Attribute, IResourceFilter
    {
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            //throw new NotImplementedException();
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            var userAgent = context.HttpContext.Request.Headers["user-agent"].FirstOrDefault();
            if (userAgent.Contains("Edge"))
            {
                context.Result = new ContentResult()
                {
                    Content = "Do not use Edge for this website !"
                };
            }
        }
    }
}