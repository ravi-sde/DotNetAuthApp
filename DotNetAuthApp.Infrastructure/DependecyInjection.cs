using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DotNetAuthApp.Application.Common.Interfaces;
using DotNetAuthApp.Core.Repositories.Command;
using DotNetAuthApp.Core.Repositories.Command.Base;
using DotNetAuthApp.Core.Repositories.Query;
using DotNetAuthApp.Core.Repositories.Query.Base;
using DotNetAuthApp.Infrastructure.Data;
using DotNetAuthApp.Infrastructure.Identity;
using DotNetAuthApp.Infrastructure.Repository.Command;
using DotNetAuthApp.Infrastructure.Repository.Command.Base;
using DotNetAuthApp.Infrastructure.Repository.Query;
using DotNetAuthApp.Infrastructure.Repository.Query.Base;
using DotNetAuthApp.Infrastructure.Services;

namespace DotNetAuthApp.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<DotNetAuthAppContext>(options => options.UseSqlite(configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(DotNetAuthAppContext).Assembly.FullName)
                ));

            services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<DotNetAuthAppContext>()
            .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                // Default Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;
                // Default Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false; // For special character
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;
                // Default SignIn settings.
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;
                options.User.RequireUniqueEmail = true;
            });


            services.AddScoped<IIdentityService, IdentityService>();

            services.AddScoped(typeof(IQueryRepository<>), typeof(QueryRepository<>));
            services.AddTransient<ICustomerQueryRepository, CustomerQueryRepository>();
            services.AddScoped(typeof(ICommandRepository<>), typeof(CommandRepository<>));
            services.AddTransient<ICustomerCommandRepository, CustomerCommandRepository>();


            return services;
        }
    }
}
