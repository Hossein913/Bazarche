﻿//using Microsoft.AspNetCore.Identity;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;


//namespace Infrastructure.IdentityConfigs
//{
//    public static class IdentityConfig
//    {
//        public static IServiceCollection AddIdentityDbContextService(this IServiceCollection services,
//            IConfiguration configuration)
//        {
//            services.AddDbContext<DatabaseContext>(option =>
//                option.UseSqlServer(configuration.GetConnectionString("sqlserver")));

//            services.AddIdentity<User, IdentityRole<int>>()
//                .AddEntityFrameworkStores<DatabaseContext>()
//                .AddDefaultTokenProviders()
//                .AddRoles<IdentityRole<int>>()
//                .AddErrorDescriber<CustomIdentityError>();
//            services.Configure<IdentityOptions>(options =>
//            {
//                options.Password.RequireDigit = false;
//                options.Password.RequiredLength = 1;
//                options.Password.RequireLowercase = false;
//                options.Password.RequireNonAlphanumeric = false;
//                options.Password.RequireUppercase = false;
//                options.Password.RequiredUniqueChars = 1;
//                options.Password.RequireNonAlphanumeric = false;
//                options.User.RequireUniqueEmail = true;
//                options.Lockout.MaxFailedAccessAttempts = 5;
//                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
//            });

//            return services;
//        }
//    }
//}
