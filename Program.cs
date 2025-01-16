using Phoenix.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
DependencyInjection.AddServices(builder.Services);

var app = builder.Build();

app.UseStaticFiles();

app.MapDefaultControllerRoute();

app.Run();
