using Microsoft.EntityFrameworkCore;
using MVCECommerceData;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder
    .Services
    .AddCors();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<MVCECommerceDbContext>(config =>
{
    //config.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
    AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    config.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"), p =>
    {
        p.MigrationsAssembly("MVCECommerceMigrationPostgreSql");
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseCors(config=>config.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());//bir web API’sine farklý bir origin’den (alan adý, port veya protokol farký) yapýlan isteklerin izinli olup olmayacaðýný belirler.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapScalarApiReference(config =>
{
    config.Theme=ScalarTheme.Purple;
});
app.Run();
