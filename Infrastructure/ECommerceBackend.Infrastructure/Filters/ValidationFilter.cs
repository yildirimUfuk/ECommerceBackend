using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceBackend.Infrastructure.Filters
{
    public class ValidationFilter : IAsyncActionFilter
    {
        //custom filter.
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var errors= context.ModelState
                    .Where(x => x.Value.Errors.Any())
                    .ToDictionary(e => e.Key, e => e.Value.Errors.Select(e => e.ErrorMessage))
                    .ToArray();
                context.Result = new BadRequestObjectResult(errors);

                //next filter musn't be triggered because of the error.
                return;
            }
            // next filter must be triggered.
            await next();
        }
    }
}
