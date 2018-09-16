using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmptyCoreApp
{
    public class HelloWordMiddleware
    {
        private readonly RequestDelegate _next;

        public HelloWordMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            context.Items["greetings"] = "Hello Word!";

            await _next.Invoke(context);
        }
    }
}
