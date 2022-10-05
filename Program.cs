using FreshMarket.Data;
using FreshMarket.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(o => o.UseNpgsql(builder.Configuration.GetConnectionString("Local_FreshMarket")));
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

if(app.Environment.IsProduction())
    app.UseHttpsRedirection(); 

else if(app.Environment.IsDevelopment())
    app.Seed();

app.MapControllers();

app.Run();
