using Api.Domain.Repositories;
using Api.Service;
using Api.Services.Contracts;
using Ecommerce.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Options;
using Presistence.Repositories;
using Serilog;
using Serilog.Events;

namespace Ecommerce
{
    public class Program
    {
        public static NewtonsoftJsonPatchInputFormatter GetJsonPatchInputFormatter() =>
            new ServiceCollection().AddLogging().AddMvc().AddNewtonsoftJson()
            .Services.BuildServiceProvider()
            .GetRequiredService<IOptions<MvcOptions>>().Value.InputFormatters
            .OfType<NewtonsoftJsonPatchInputFormatter>().First();
        public static void Main(string[] args)
        {

            Log.Logger = new LoggerConfiguration() // for startup
                 //.MinimumLevel.Information()
                .WriteTo.Console().CreateBootstrapLogger();



            Log.Information("Starting the application");

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddGlobalExceptionHandler();

            builder.Host.UseSerilog((context, services, configuration) => // after the startup
            configuration.ReadFrom.Configuration(context.Configuration)
            .ReadFrom.Services(services));


            builder.Services.ConfigureSqlContext(builder.Configuration);
            builder.Services.ConfigureAuthenticationService();
            builder.Services.ConfigureUserService();
            builder.Services.ConfigureProductService();
            builder.Services.ConfigureCartService();
            builder.Services.ConfigureOrderService();



            builder.Services.AddAuthentication();
            builder.Services.ConfigureIdentity();
            builder.Services.ConfigureJWT(builder.Configuration);
            builder.Services.AddJwtConfiguration(builder.Configuration);

            
            builder.Services.ConfigureUnitOfWork();
           
            builder.Services.AddAutoMapper(typeof(Mapping.UserProfile));

            builder.Services.AddControllers(config =>
            {
                config.RespectBrowserAcceptHeader = true;
                config.ReturnHttpNotAcceptable = true;
                config.InputFormatters.Insert(0, GetJsonPatchInputFormatter());
                config.CacheProfiles.Add("120SecondsDuration", new CacheProfile
                {
                    Duration = 120
                });
            }).AddNewtonsoftJson(
                      options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
            .AddXmlDataContractSerializerFormatters()
            //.AddCustomCSVFormatter()
            .AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly);

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseExceptionHandler( _ => { });

            app.UseSerilogRequestLogging(opts =>
            {
                opts.GetLevel = (httpContext, elapsed, ex) =>
                {
                    // Don't log anything if there's an exception
                    return ex == null ? LogEventLevel.Information : LogEventLevel.Debug; // workaround to preevnt logging the errors...check it again.
                };
            });
            

            app.UseHttpsRedirection(); // will log the request too

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
