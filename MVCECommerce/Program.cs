var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();//wwwroot dosyasýný kullanabilmek için

app.MapControllerRoute(
    name:"Default",
    pattern:"{controller=Home}/{action=Index}/{id?}");

app.Run();
