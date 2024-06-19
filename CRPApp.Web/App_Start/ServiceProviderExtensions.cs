using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Extensions.DependencyInjection;

namespace CRPApp.Web.App_Start
{
    public static class ServiceProviderExtensions
    {
        public static IServiceCollection AddControllersAsServices(this IServiceCollection services,
            IEnumerable<Type> controllerTypes)
        {
            foreach (var type in controllerTypes)
            {
                services.AddTransient(type);
            }

            return services;
        }

        public static IServiceCollection AddApplicationServices(this IServiceCollection services,
            IEnumerable<Type> applicationServiceTypes)
        {
            foreach (var type in applicationServiceTypes)
            {
                services.AddTransient(type);
            }

            return services;
        }
    }
}