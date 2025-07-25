using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MVCECommerce;
using MVCECommerce.Domain;
using NETCore.MailKit.Extensions;
using NETCore.MailKit.Infrastructure.Internal;
using System.Data.Common;
using System.Security.Claims;

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

builder
    .Services
    .AddMailKit(config =>
    {
        config.UseMailKit(new MailKitOptions
        {
            Server = builder.Configuration["Email:Server"],
            Port = builder.Configuration.GetValue<int>("Email:Port"),
            SenderName = builder.Configuration["Email:SenderName"],
            SenderEmail = builder.Configuration["Email:SenderEmail"],
            Account = builder.Configuration["Email:Account"],
            Password = builder.Configuration["Email:Password"],
            Security = builder.Configuration.GetValue<bool>("Email:Security")
        });
    });

var app = builder.Build();

app.UseStaticFiles();//wwwroot dosyasýný kullanabilmek için
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "Areas",
    pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");

app.MapControllerRoute(//defaýlt rota hep en sonda olsun. herþeye uyduðu için her zaman çalýþýr ve diðer alanlara inilmez
    name: "Default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



using var scope = app.Services.CreateScope();
using var dbContext = scope.ServiceProvider.GetRequiredService<MVCECommerceDbContext>();
using var roleManager=scope.ServiceProvider.GetRequiredService<RoleManager<Role>>();
using var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();

dbContext.Database.Migrate();

new[]
{
    new Role {DisplayName="Yöneticiler", Name="Administrators"},
    new Role {DisplayName="Ürün Yöneticileri", Name="ProductAdministrators"},
    new Role {DisplayName="Sipariþ Yöneticileri", Name="OrderAdministrators"},
    new Role {DisplayName="Üyeler", Name="Members"}
}.ToList()
.ForEach(p =>
{
    roleManager.CreateAsync(p).Wait();
});

var user = new User
{
    Date= DateTime.UtcNow,
    Gender=Genders.Male,
    GivenName="Builtin Admin",
    UserName="admin@mvc.com",
    Email="admin@mvc.com",
    EmailConfirmed=true
};
if(userManager.FindByNameAsync("admin@mvc.com").Result is null)
{
    userManager.CreateAsync(user, "Mvcadmin1?").Wait();
    userManager.AddToRoleAsync(user, "Administrators").Wait();
    userManager.AddClaimAsync(user, new Claim(ClaimTypes.GivenName, user.GivenName)).Wait();
}


app.Run();
