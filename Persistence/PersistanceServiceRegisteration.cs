using Domain.Entites;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories.Models;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;



namespace Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection ConfigureIdentityServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

            //services.AddDbContext<ContestCenterDbContext>(options =>
            //options.UseInMemoryDatabase("ContestCenterInMemory"));

            services.AddDbContext<ContestCenterDbContext>(options =>
      options.UseSqlServer(
          configuration.GetConnectionString("SqlConnection"),
          sqlServerOptions => sqlServerOptions
              .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()))
              .EnableSensitiveDataLogging();
  

            //services.AddDbContext<ContestCenterDbContext>(options =>
            //options.UseSqlServer(configuration.GetConnectionString("SqlConnection")), options.CommandTimeout(60));

              services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ContestCenterDbContext>().AddDefaultTokenProviders();

            services.AddTransient<IAuthRepository, AuthService>();
       

            return services;
        }
    }
}
