using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmptyCoreApp
{
    public class TokenMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _pattern;

        public TokenMiddleware(RequestDelegate next, string pattern)
        {
            _next = next;
            _pattern = pattern;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var token = context.Request.Query["token"];
            var query = context.Request.QueryString;

            if (!token.Equals(_pattern))
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync($"{query}");
            }
            else
            {
                await _next.Invoke(context);
            }
        }
    }
}
