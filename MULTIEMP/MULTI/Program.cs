using MULTI.Models;
using MULTI.Util;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MULTI.Areas.Identity.Data;
using MULTI.Services;


var builder = WebApplication.CreateBuilder(args);
//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'MULTIContextConnection' not found.");


// Add services to the container.

//AUT 2EF
//services.AddScoped<IBlogEmailSender, EmailService>();
builder.Services.AddScoped<TenantService>();

// solo para aplicar la migraciòn quitar para producciòn
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

//*** ServiceLifetime.Transient garantiza que en cada request se instancie el Multicontext
builder.Services.AddDbContext<MULTIContext>(options =>
                options.UseSqlServer(connectionString));

//****OJOOO  ServiceLifetime.Transient   HABILITAR PARA EL MULTITENAT CON VARIAS BASES DE DATOS.


// CONTEXTO DB DE IDENTITY
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<MULTIContext>()

.AddDefaultTokenProviders().AddDefaultUI();// DISBLED ESTA LINEA PARA AUTENTICAR CON DOBLE FACTOR

// asigna a la clase "TenantSettings"  la configuracion de la seccion "Tenat" del appseting.json
// propiedad Sites diccionario T1,t2..= TenantSettings (conectionstring..) 
builder.Services.Configure<TenantSettings>((settings) => {
    builder.Configuration.GetSection("Tenants").Bind(settings);
});

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddMvc();
builder.Services.AddRazorPages();
// Pendiente validar que
builder.Services.ConfigureApplicationCookie(options =>
{
    // Cookie settings
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(2);

    options.LoginPath = "/Identity/Account/Login";
    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
    options.SlidingExpiration = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
app.Run();


