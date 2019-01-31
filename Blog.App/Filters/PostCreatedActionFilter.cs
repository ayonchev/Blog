using Blog.Data.Entities;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.App.Filters
{
    public class PostCreatedActionFilter : IActionFilter
    {
        private readonly ILogger<PostCreatedActionFilter> logger;

        public PostCreatedActionFilter(ILogger<PostCreatedActionFilter> logger)
        {
            this.logger = logger;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            logger.LogInformation($"New post was created!!!");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
        }
    }
}
