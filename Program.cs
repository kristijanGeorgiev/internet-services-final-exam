using Microsoft.EntityFrameworkCore;
using ProductStore.Application.Interfaces;
using ProductStore.Application.Services;
using ProductStore.Infrastructure.Data;
using ProductStore.Infrastructure.Repositories;
using ProductStore.API.Mappings;
using ProductStore.Infrastructure.Services;
using Core.Application.Services;
using Infrastructure.Services;
using Core.Domain.Interfaces;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<JsonLoaderService>();

// Add services to the container

// Register DbContext (make sure appsettings.json contains DefaultConnection)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

// Register services
builder.Services.AddScoped<IStockImportService, StockImportService>();
builder.Services.AddScoped<IStockRepository, StockRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IDiscountCalculatorService, DiscountCalculatorService>();

// Add controllers and Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Product Store API",
        Version = "v1"
    });
});

var app = builder.Build();

// Configure HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Product Store API v1");
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
public partial class Program { }