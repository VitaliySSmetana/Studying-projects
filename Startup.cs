using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace EmptyCoreApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            //app.UseToken("111");
            app.UseHelloWord();

            app.Map("/index", IndexPage);

            app.Run(async (context) =>
            {
                context.Response.StatusCode = 200;
                await context.Response.WriteAsync($"{context.Items["greetings"]}");
            });
        }

        private void IndexPage(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                context.Response.StatusCode = 200;
                await context.Response.WriteAsync("Index");
            });
        }
    }
}