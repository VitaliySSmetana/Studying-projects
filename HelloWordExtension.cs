using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmptyCoreApp
{
    public static class HelloWordExtension
    {
        public static IApplicationBuilder UseHelloWord(this IApplicationBuilder app)
        {
            return app.UseMiddleware<HelloWordMiddleware>();
        }
    }
}
