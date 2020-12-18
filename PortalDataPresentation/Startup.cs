using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PortalData.Services;
using PortalData.Services.AnalysisComponents;
using PortalDataPresentation.Controllers;
using PortalDataPresentation.DAL;

namespace PortalDataPresentation
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<PortalContext>(options =>
                options.UseMySql(Configuration.GetConnectionString("DefaultConnection")));
            services.AddMvc();

            services.AddAutoMapper(typeof(Startup));

            services.AddSingleton<IAnalysisComputationService, AnalysisService>();
            services.AddScoped<IMeasurementDataService,MeasurementsDataService>();

            services.AddTransient<IComputable, AverageComponent>();
            services.AddTransient<IComputable, MaxComponent>();
            services.AddTransient<IComputable, PredictionComponent>();
            services.AddTransient<IComputable, TrendComponent>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            //app.UseForwardedHeaders(new ForwardedHeadersOptions
            //{
            //    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            //});
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                //MeasurementDatas/MapLocation  {controller=Home}/{action=Index}
                routes.MapRoute(
                    name: "default",
                    template: "portal/{controller=MeasurementDatas}/{action=MapLocation}/{id?}");
            });
        }
    }
}
