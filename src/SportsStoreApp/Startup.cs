using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SportsStoreApp.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
namespace SportsStoreApp
{
    public class Startup
    {
        IConfigurationRoot Configuration;
        public Startup(IHostingEnvironment env)
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json").Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration["Data:SportsStoreProducts:ConnectionString"]));
            services.AddTransient<IProductRepository, EFProductRepository>();

            //services.AddTransient<IProductRepository, FakeProductRepository>();
            // This tells asp.net that when a component such as a controller, needs an implementation of the IProductRepository
            // it should receive an instance of the EFProductRepository class.
            // The AddTransient method specifies that a new FakeProductRepository obj should be created each time the IProductRepository interface is needed.
            //
            // this service will be registered so that it will update the IProdRepo interface which gets data from the FakEpROdRepo
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            app.UseDeveloperExceptionPage();// must disable when deployed
            app.UseStatusCodePages(); // error 404
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();

            // setup default routing:
            app.UseMvc(routes =>
            { routes.MapRoute(name: "default", template: "{controller=Product}/{action=list}/{id?}"); });

            SeedData.EnsurePopulated(app);
            // {controller=Product} is referencing the productcontroller.  by name conventions, you should use Product without Controller
            //
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("This is an error");
            //});
        }
    }
}
