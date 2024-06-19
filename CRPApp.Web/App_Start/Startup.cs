using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin;
using Owin;
using Microsoft.Extensions.DependencyInjection;
using System.Web.Mvc;
using AutoMapper;
using Microsoft.AspNet.SignalR;
using CRPApp.Web.Hubs;

[assembly: OwinStartup(typeof(CRPApp.Web.App_Start.Startup))]
namespace CRPApp.Web.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            var resolver = new DefaultDependencyResolver(services.BuildServiceProvider());
            DependencyResolver.SetResolver(resolver);

           app.MapSignalR();


        }

        public void ConfigureServices(IServiceCollection services)
        {
            //add controller services to DI container
            services.AddControllersAsServices(typeof(Startup).Assembly.GetExportedTypes()
               .Where(t => !t.IsAbstract && !t.IsGenericTypeDefinition)
               .Where(t => typeof(IController).IsAssignableFrom(t)
                  || t.Name.EndsWith("Controller", StringComparison.OrdinalIgnoreCase)));

            //add automapper profiles as services to DI container
            services.AddAutoMapper(typeof(Service.Mappings.DomainToViewModelMappingProfile).Assembly);


            //add application services to DI container
            services.AddApplicationServices(typeof(Service.OnsiteStatusService).Assembly.GetExportedTypes()
                .Where(t => !t.IsAbstract && !t.IsGenericTypeDefinition && t.Name.EndsWith("Service",StringComparison.OrdinalIgnoreCase)));

        }
    }
}