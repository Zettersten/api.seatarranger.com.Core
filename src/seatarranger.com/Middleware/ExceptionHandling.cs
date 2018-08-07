using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace seatarranger.com.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ExceptionHandling
    {
        private readonly RequestDelegate _next;

        public ExceptionHandling(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
			{            
				await _next(httpContext);
			}
			catch (Exception ex)
			{
				if(httpContext.Response.HasStarted)
                {
                    throw;
                }

				httpContext.Response.Clear();
				httpContext.Response.StatusCode = 400;
				httpContext.Response.ContentType = "application/json";

				await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(new { error = ex.Message }));
			}
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ExceptionHandlingExtensions
    {
        public static IApplicationBuilder UseExceptionHandling(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandling>();
        }
    }
}
