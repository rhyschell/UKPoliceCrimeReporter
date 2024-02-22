using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using UKPoliceCrimeReporter.Client.Interfaces;
using UKPoliceCrimeReporter.Client.Services;
using UKPoliceCrimeReporter.Client.Options;

namespace UKPoliceCrimeReporter.UI;

//Note: I personally prefer the explicit program class and main method so have opted to not use top level statements

public class Program
{    
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var environment = builder.Environment;

        //add config files - personally I like to keep them grouped together in a Config folder rather than the default of storing them at root of the project
        builder.Configuration.AddJsonFile("Config/appSettings.json", optional: false, reloadOnChange: true);
        builder.Configuration.AddJsonFile($"Config/appSettings.{environment.EnvironmentName}.json", optional: true, reloadOnChange: true);

        //configure logging - use appSettings to drive the config
        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(builder.Configuration)
            .CreateLogger();

        builder.Host.UseSerilog();

        try
        {
            //add services to the container.
            ConfigureServices(builder.Services, builder.Configuration, environment);

            //now configure the pipeline
            var app = builder.Build();
            ConfigurePipeline(app);

            app.Run();
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Error caught in app startup");
        }
        finally
        {
            Log.CloseAndFlush();
        }

    }


    private static void ConfigureServices(IServiceCollection services, IConfiguration config, IWebHostEnvironment environment)
    {
        services.AddControllersWithViews();

        //configure the client options
        services.Configure<UKCrimeClientOptions>(config.GetRequiredSection(nameof(UKCrimeClientOptions)));

        //register the client (scoped because it's disposable)
        services.AddScoped<IUKCrimeClient, UKCrimeClient>();
    }

    private static void ConfigurePipeline(WebApplication app)
    {
        IConfiguration config = app.Configuration;
        IWebHostEnvironment environment = app.Environment;
        IServiceProvider serviceProvider = app.Services;

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}
