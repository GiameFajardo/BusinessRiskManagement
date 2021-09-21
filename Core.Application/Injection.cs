using Core.Application.Contracts.Services;
using Core.Application.Data.Services;
using Core.Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application
{
    public static class Injection
    {
        public static IServiceCollection RegisterApplicationServices(
            this IServiceCollection service,
            IConfiguration configuration)
        {
            service.AddScoped<IIdentityService, IdentityService>();
            service.AddScoped<IOrganizationService, OrganizationService >();

            return service;
        }
        //public static IServiceCollection RegisterApplicationServices(
        //    this IServiceCollection service,
        //    IConfiguration configuration, JwtSettings jwtSettings)
        //{
        //    service.AddScoped<IOrganizationService, OrganizationService>();
        //    service.AddScoped<IIdentityService, IdentityService>();
        //    configuration.Bind(nameof(jwtSettings), jwtSettings);
        //    service.AddSingleton(jwtSettings);
        //    return service;
        //}
    }
}
