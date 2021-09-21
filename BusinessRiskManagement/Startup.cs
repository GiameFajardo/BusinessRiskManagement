
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Infrastructure;
using Core.Application;
using Core.Application.Contracts.Data;
using Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using BusinessRiskManagement.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;

namespace BusinessRiskManagement
{
    public class Startup
    {

        private readonly IWebHostEnvironment _env;
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            _env = env;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            

            services.RegisterApplicationServices(Configuration);
            services.RegisterInfrastructerServices(Configuration);

            services.AddControllers();
            #region Seting Env
            if (_env.IsStaging())
            {
                services.AddDbContext<Infrastructure.Data.BRMContext>(option =>
                    option.UseSqlServer(Configuration.GetConnectionString("StagingConnection"),
                assembly => assembly.MigrationsAssembly(typeof(BRMContext).Assembly.FullName)));

            }
            else if (_env.IsEnvironment("Quality&Assurance"))
            {
                services.AddDbContext<Infrastructure.Data.BRMContext>(option =>
                    option.UseSqlServer(Configuration.GetConnectionString("Quality&AssuranceConnection"),
                assembly => assembly.MigrationsAssembly(typeof(BRMContext).Assembly.FullName)));
            }
            else if (_env.IsDevelopment())
            {
                services.AddDbContext<Infrastructure.Data.BRMContext>(option =>
                    option.UseSqlServer(Configuration.GetConnectionString("ProductionConnection"),
                assembly => assembly.MigrationsAssembly(typeof(BRMContext).Assembly.FullName)));
            }
            else
            {
                services.AddDbContext<Infrastructure.Data.BRMContext>(option =>
                    option.UseSqlServer(Configuration.GetConnectionString("ProductionConnection"),
                assembly => assembly.MigrationsAssembly(typeof(BRMContext).Assembly.FullName)));
            }
            #endregion
           
            services.AddTransient<UserManager<IdentityUser>>();
            


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new() { Title = "APIBMR", Version = "v1" });

                var x = new OpenApiSecurityRequirement {
                    {new OpenApiSecurityScheme
                    {
                        Reference =  new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    }, new string[]{ }
                    }
                };
                var security = new Dictionary<string, IEnumerable<string>>
                {
                    {"Bearer", new string[0] }
                };
                c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    Description = "JWT Autorization header using the baerer scheme",
                    Name = "Authorization",
                    In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                    Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey
                });
                c.AddSecurityRequirement(x);
            });
              
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "APIBMR");
            });
        }
    }
}
