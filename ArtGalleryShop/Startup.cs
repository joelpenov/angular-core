using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArtGalleryShop.ArtGalleryContext;
using ArtGalleryShop.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ArtGalleryShop
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IArtGalleryContext, ArtGalleryContext.ArtGalleryContext>();
            services.AddMvc()
                .AddJsonOptions(jsonConf =>
                    {
                        jsonConf.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                        jsonConf.SerializerSettings.ContractResolver = new DefaultContractResolver();
                    });

            services.AddTransient<Seeder>();
            services.AddDbContext<ArtGalleryShopDbContext>(cfn=> 
            {
                cfn.UseSqlServer(_configuration.GetConnectionString("ArtGalleryShopConnectionString"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true,
                    HotModuleReplacementEndpoint = "/dist/__webpack_hmr"
                });
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes => {
                routes.MapRoute(
                        name: "default",
                        template: "{controller=Home}/{action=Index}/{id?}");
            });

            if (env.IsDevelopment())
            {
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var seeder = scope.ServiceProvider.GetService<Seeder>();
                    seeder.Seed();
                }
            }
            
        }
    }
}
