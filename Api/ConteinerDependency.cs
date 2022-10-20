using Business;
using Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api
{
    public static class ConteinerDependency
    {
        public static IServiceCollection AddDependencyBicode(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDependencyBusiness();
            services.AddDependencyData(configuration);
            return services;
        }
    }
}
