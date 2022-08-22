using MULTI.Models;
using MULTI.Util;
using Microsoft.Extensions.Configuration;



var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<TenantSettings>((settings) => {
    builder.Configuration.GetSection("Tenants").Bind(settings);
});

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


