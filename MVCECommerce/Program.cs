using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MVCECommerce;
using MVCECommerce.Domain;
using System.Data.Common;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<MVCECommerceDbContext>(config =>
{
    config.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddIdentity<User,Role>(config =>
{
    config.Password.RequireDigit = builder.Configuration.GetValue<bool>("Identity:RequireDigit");
    config.Password.RequireLowercase = builder.Configuration.GetValue<bool>("Identity:RequireLowercase");
    config.Password.RequireUppercase = builder.Configuration.GetValue<bool>("Identity:RequireUppercase");
    config.Password.RequireNonAlphanumeric = builder.Configuration.GetValue<bool>("Identity:RequireNonAlphanumeric");
    config.Password.RequiredLength = builder.Configuration.GetValue<int>("Identity:RequiredLength");
    config.Password.RequiredUniqueChars = builder.Configuration.GetValue<int>("Identity:RequiredUniqueChars");

    config.User.RequireUniqueEmail = true;
    config.Lockout.MaxFailedAccessAttempts = 5;
    config.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);

    config.SignIn.RequireConfirmedEmail = true;
}).AddEntityFrameworkStores<MVCECommerceDbContext>()
.AddDefaultTokenProviders();//mail doðrulama veya þifre yenileme iþleminde kullanýcýya gönderilen token üretir

var app = builder.Build();

app.UseStaticFiles();//wwwroot dosyasýný kullanabilmek için
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "Default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

using var scope = app.Services.CreateScope();
using var dbContext = scope.ServiceProvider.GetRequiredService<MVCECommerceDbContext>();
dbContext.Database.Migrate();

app.Run();
