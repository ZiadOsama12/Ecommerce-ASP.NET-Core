﻿using Api.Domain.Entities;
using Api.Services.Contracts;
using Api.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Presistence;
using Api.Domain.Entities.ConfigrationModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Ecommerce.Extensions
{
    public static class ServiceExtensions
    {

        public static void ConfigureAuthenticationService(this IServiceCollection services)
            => services.AddScoped<IAuthenticationService, AuthenticationService>();

        public static void ConfigureSqlContext(this IServiceCollection services,
            IConfiguration configuration) =>
            services.AddDbContext<RepositoryDbContext>(opts =>
            opts.UseSqlServer(configuration.GetConnectionString("sqlConnection"))
                .EnableSensitiveDataLogging()); // options.EnableSensitiveDataLogging(); // for logging params in the queries. Remove it in production.

        public static void ConfigureIdentity(this IServiceCollection services)
        {
            var builder = services.AddIdentity<User, IdentityRole>(o =>
            {
                o.Password.RequireDigit = true;
                o.Password.RequireLowercase = false;
                o.Password.RequireUppercase = false;
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequiredLength = 5;
                o.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<RepositoryDbContext>()
            .AddDefaultTokenProviders();
        }
        public static void ConfigureJWT(this IServiceCollection services, IConfiguration
            configuration)
        {

            var jwtConfiguration = new JwtConfiguration();
            configuration.Bind(jwtConfiguration.Section, jwtConfiguration);

            var secretKey = jwtConfiguration.Secret;

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = jwtConfiguration.ValidIssuer,
                    ValidAudience = jwtConfiguration.ValidAudience,
                    IssuerSigningKey = new
                            SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
                };
            });
        }


        // This lets you inject IOptions<JwtConfiguration> into services anywhere in the app.
        public static void AddJwtConfiguration(this IServiceCollection services,
            IConfiguration configuration) =>
            services.Configure<JwtConfiguration>(configuration.GetSection("JwtSettings"));


        //public static IMvcBuilder AddCustomCSVFormatter(this IMvcBuilder builder) =>
        //        builder.AddMvcOptions(config => config.OutputFormatters.Add(new
        //        CsvOutputFormatter()));


        public static void AddGlobalExceptionHandler(this IServiceCollection services)
            => services.AddExceptionHandler<GlobalExceptionHandler>();
    }
}
