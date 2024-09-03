using Microsoft.EntityFrameworkCore;
using ProductManagementApp.HostedServices;
using ProductManagementApp.Models;
using ProductManagementApp.Repositories;
using ProductManagementApp.Repositories.Interfaces;



var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ProductDbContext>(op => op.UseSqlServer(builder.Configuration.GetConnectionString("db")));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ApplyMigrationService>();
builder.Services.AddHostedService<MigrationCheckHostedService>();
builder.Services.AddControllersWithViews();
var app = builder.Build();
app.UseStaticFiles();
app.MapDefaultControllerRoute();

app.Run();
