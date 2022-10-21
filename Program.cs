using AutoMapper;
using FreshMarket.Data;
using FreshMarket.Repositories;
using FreshMarket.Services;
using FreshMarket.Utils;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddNewtonsoftJson();

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(o => o.UseNpgsql(builder.Configuration.GetConnectionString("Local_FreshMarket")));
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<DishService>();
builder.Services.AddScoped<SubscriptionService>();
builder.Services.AddScoped<TierService>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddSingleton<Mapper>(FreshMarketMapper.GetMapper());

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

if(app.Environment.IsProduction())
    app.UseHttpsRedirection();

else if(app.Environment.IsDevelopment())
    app.Seed();

app.MapControllers();

app.Run();
