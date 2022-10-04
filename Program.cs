using FreshMarket.Data;
using FreshMarket.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(o => o.UseNpgsql(builder.Configuration.GetConnectionString("Local_FreshMarket")));

// Register custom Dependency Injection
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

if(app.Environment.IsDevelopment())
    app.Seed();

app.MapControllers();

app.Run();
