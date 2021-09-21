using Core.Application.Contracts.Services;
using Core.Application.Data.Services;
using Core.Application.Options;
using Core.Application.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
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
            var jwtSettings = new JwtSettings();
            configuration.Bind(nameof(jwtSettings), jwtSettings);
            service.AddSingleton(jwtSettings);

            service.AddScoped<IIdentityService, IdentityService>();
            service.AddScoped<IOrganizationService, OrganizationService >();

            service.AddAuthentication(c =>
            {
                c.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                c.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                c.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(c =>
            {
                c.SaveToken = true;
                c.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.Secret)),
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidateLifetime = true,
                    RequireExpirationTime = false
                };
            });
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
