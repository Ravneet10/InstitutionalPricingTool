using Autofac;
using Autofac.Core;
using InstitutionalPricing.Business.Handlers;
using InstitutionalPricing.Entity;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Reflection;

namespace InstitutionalPricingTool
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

            services.AddControllersWithViews();
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });
        }
        public void ConfigureContainer(ContainerBuilder builder)
        {
            // Register your own things directly with Autofac here. Don't
            // call builder.Populate(), that happens in AutofacServiceProviderFactory
            // for you.

            builder.RegisterAssemblyTypes(typeof(IMediator).Assembly).AsImplementedInterfaces();
            DbContextOptionsBuilder<InstitutionalPricingContext> optionsBuilder = new DbContextOptionsBuilder<InstitutionalPricingContext>();
            optionsBuilder.UseSqlServer("Server=localhost;Database=Zenith.Visits;Trusted_Connection=True;MultipleActiveResultSets=True;");
            var dbContextOptions = optionsBuilder.Options;
            builder.RegisterInstance(dbContextOptions);

            builder
                .RegisterType<InstitutionalPricingContext>()
                .As<IInstitutionalPricingContext>()
                .WithParameter(new ResolvedParameter(
                    (pi, ctx) => pi.ParameterType == typeof(DbContextOptions<InstitutionalPricingContext>),
                    (pi, ctx) => ctx.Resolve<DbContextOptions<InstitutionalPricingContext>>()));
            var openHandlerTypes = new[]
           {
                typeof(IRequestHandler<,>),
                typeof(IAsyncRequestHandler<,>)
            };

            var mediatorHandlersAssembly = typeof(GetProposalsQueryHandler).Assembly;
            foreach (var type in openHandlerTypes)
            {
                builder
                    .RegisterAssemblyTypes(mediatorHandlersAssembly)
                    .AsClosedTypesOf(type);
            }
            builder.Register<SingleInstanceFactory>(ctx =>
            {
                var c = ctx.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}
