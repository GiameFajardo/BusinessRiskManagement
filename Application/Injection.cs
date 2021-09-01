using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class Injection
    {
        public static IServiceCollection RegisterApplicationServices(
          this IServiceCollection service,
          IConfiguration configuration)
        {
            return service;
        }
    }
}
