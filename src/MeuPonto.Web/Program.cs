using MeuPonto.Cache;
using MeuPonto.Data;
using MeuPonto.Infrastructure;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Transactions;

namespace MeuPonto;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddInfrastructure(builder.Configuration);

        builder.Services.AddDatabaseDeveloperPageExceptionFilter();

        builder.Services
            .AddRazorPages(options =>
            {
                //options.RootDirectory = "/Modules";
            })
            .AddViewOptions(options =>
            {
                options.HtmlHelperOptions.ClientValidationEnabled = false;
            });

        // Add the localization services to the services container
        builder.Services.AddLocalization();

        builder.Services.Configure<RequestLocalizationOptions>(options =>
        {
            var supportedCultures = new[] { "pt-BR", "en" };

            options.SetDefaultCulture(supportedCultures[0])
                .AddSupportedCultures(supportedCultures)
                .AddSupportedUICultures(supportedCultures);
        });

        builder.Services.AddTransient(p => new DateTimeSnapshot(() => DateTime.Now));

        var app = builder.Build();

        app.UseMiddleware<CacheMiddleware>();

        var localizationOptions = app.Services.GetService<IOptions<RequestLocalizationOptions>>();

        app.UseRequestLocalization(localizationOptions.Value);

        app.UseMiddleware<RequestLocalizationMiddleware>();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");

            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        //app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapStaticAssets();
        app.MapRazorPages()
           .WithStaticAssets();

        app.Services.EnsureDatabaseExists();

        app.Run();
    }
}
