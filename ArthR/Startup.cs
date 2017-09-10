using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Nancy.Owin;
using ArthR.Hubs;

namespace ArthR
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // TODO: AddSockets prevents exception, but I DON'T GET IT
            // "No service for type 'Microsoft.AspNetCore.Sockets.HttpConnectionDispatcher' has been registered."
            services.AddSockets();
            services.AddSignalRCore();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseOwin(x => x.UseNancy());
            app.UseSignalR(routes =>
            {
                //TODO: what is "path" argument?
                routes.MapHub<Broadcaster>("broadcaster");
            });
        }
    }
}
