using Domain.Entites;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories.Models;
using Persistence.Repositories;
using Application.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection ConfigureIdentityServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
  
            services.AddDbContext<ContestCenterDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("SqlConnection")));

              services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ContestCenterDbContext>().AddDefaultTokenProviders();

            services.AddTransient<IAuthRepository, AuthService>();
       

            return services;
        }
    }
}
