using BlazorDemo.Components;
using BlazorDemo.Data.DataContext;
using Microsoft.EntityFrameworkCore;

namespace BlazorDemo;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddDbContextFactory<BlazorDemoContext>(options =>
            options.UseSqlite(builder.Configuration.GetConnectionString("BlazorDemoContext")));
        builder.AddServiceDefaults();

        // Add services to the container.
        builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents();

        builder.Services.AddQuickGridEntityFrameworkAdapter();
        builder.Services.AddDatabaseDeveloperPageExceptionFilter();

        var app = builder.Build();

        app.MapDefaultEndpoints();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
    app.UseMigrationsEndPoint();
        }

        app.UseHttpsRedirection();

        app.UseStaticFiles();
        app.UseAntiforgery();

        app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode();

        app.Run();
    }
}