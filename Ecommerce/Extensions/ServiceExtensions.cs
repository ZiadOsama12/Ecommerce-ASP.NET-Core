using Api.Domain.Entities;
using Api.Services.Contracts;
using Api.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Presistence;
using Api.Domain.Entities.ConfigrationModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Api.Domain.Repositories;
using Presistence.Repositories;
using AspNetCoreRateLimit;
using FluentValidation;
using Shared.DTOs;
using Validation;
using FluentValidation.AspNetCore;

namespace Ecommerce.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                    builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
                    //.WithExposedHeaders("X-Pagination"));

    });
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

        //public static void AddRepositories(this IServiceCollection services)
        //{
        //    services.AddScoped<IUserRepository, UserRepository>();
        //    services.AddScoped<IProductRepository, ProductRepository>();
        //}
        public static void ConfigureUnitOfWork(this IServiceCollection services)
            => services.AddTransient<IUnitOfWork, UnitOfWork>();

        public static void ConfigureUserService(this IServiceCollection services)
            => services.AddScoped<IUserService, UserService>();
        public static void ConfigureProductService(this IServiceCollection services)
            => services.AddScoped<IProductService, ProductService>();

        public static void ConfigureCartService(this IServiceCollection services)
           => services.AddScoped<ICartService, CartService>();
        public static void ConfigureOrderService(this IServiceCollection services)
          => services.AddScoped<IOrderService, OrderService>();
        public static void ConfigureReviewService(this IServiceCollection services)
          => services.AddScoped<IReviewService, ReviewService>();
        public static void ConfigureRateLimitingOptions(this IServiceCollection services)
        {
            var rateLimitRules = new List<RateLimitRule>
            {
                new RateLimitRule
                {
                    Endpoint = "*",
                    Limit = 1000,
                    Period = "5m"
                }
            };
            services.Configure<IpRateLimitOptions>(opt => {
                opt.GeneralRules = rateLimitRules;
            });
            services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
            services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
            services.AddSingleton<IProcessingStrategy, AsyncKeyLockProcessingStrategy>();
        }
        public static void ConfigureFluentValidation(this IServiceCollection services)
        {
            //services.AddScoped<IValidator<UserForAuthenticationDto>, LoginValidator>();
            //services.AddScoped<IValidator<UserForRegistrationDto>, RegisterValidator>();
            
            //services.AddFluentValidation(); // deprecated
            services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
            services.AddValidatorsFromAssemblyContaining<IAssemblyMarker>();

        }
    }
}

