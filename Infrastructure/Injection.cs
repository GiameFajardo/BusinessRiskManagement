using Core.Application.Contracts.Data;
using Core.Application.Contracts.Services;
using Core.Domain.Model;
using Infrastructure.Data;
using Infrastructure.DTO;
using Infrastructure.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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
           IConfiguration configuration,
           IWebHostEnvironment env)

        {
           

            #region Seting Env
            if (env.IsStaging())
            {
                service.AddDbContext<Infrastructure.Data.BRMContext>(option =>
                    option.UseSqlServer(configuration.GetConnectionString("StagingConnection"),
                assembly => assembly.MigrationsAssembly(typeof(BRMContext).Assembly.FullName)));

            }
            else if (env.IsEnvironment("Quality&Assurance"))
            {
                service.AddDbContext<Infrastructure.Data.BRMContext>(option =>
                    option.UseSqlServer(configuration.GetConnectionString("Quality&AssuranceConnection"),
                assembly => assembly.MigrationsAssembly(typeof(BRMContext).Assembly.FullName)));
            }
            else if (env.IsDevelopment())
            {
                service.AddDbContext<Infrastructure.Data.BRMContext>(option =>
                    option.UseSqlServer(configuration.GetConnectionString("LocalConnection"),
                assembly => assembly.MigrationsAssembly(typeof(BRMContext).Assembly.FullName)));
            }
            else
            {
                service.AddDbContext<Infrastructure.Data.BRMContext>(option =>
                    option.UseSqlServer(configuration.GetConnectionString("ProductionConnection"),
                assembly => assembly.MigrationsAssembly(typeof(BRMContext).Assembly.FullName)));
            }
            #endregion

            service.AddSingleton<ICloudStorage, AzureStorage>();
            service.AddSingleton<IStorageConnectionFactory, StorageConnectionFactory>(serviceProvider =>
            {
                CloudStorageOptionsDTO storageOptions = new CloudStorageOptionsDTO
                {
                    ConnectionString = configuration["AzureBMRBlobStorage:ConnectionString"],
                    OrganizationPhotoContainer = configuration["AzureBMRBlobStorage:OrganizationPhotoContainer"]
                };
                return new StorageConnectionFactory(storageOptions);
            });
            service.AddScoped<IWorkingAreaService, WorkingAreaService>();
            service.AddScoped<IDepartmentService, DepartmentService>();
            service.AddScoped<IUserService, UserService>();
            service.AddScoped<IIdentityService, IdentityService>();
            service.AddScoped<IOrganizationService, OrganizationService>();
            service.AddScoped<IStorageService, StorageService>();

            service.AddScoped<IBRMContext>(optiont => optiont.GetService<BRMContext>());
            service.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<BRMContext>()
                .AddDefaultTokenProviders();
            //service.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddEntityFrameworkStores<ApplicationDbContext>();
            service.AddTransient<UserManager<ApplicationUser>>();
            return service;
        }
    }
}
