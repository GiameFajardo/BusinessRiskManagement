using Core.Application.Contracts.Data;
using Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class Injection
    {
        public static IServiceCollection RegisterInfrastructerServices(
           this IServiceCollection service,
           IConfiguration configuration)
        {
            service.AddScoped<IBRMContext>(optiont => optiont.GetService<Infrastructure.Data.BRMContext>());
            service.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<BRMContext>()
                .AddDefaultTokenProviders();

            return service;
        }
    }
}
