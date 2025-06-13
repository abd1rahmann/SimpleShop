using AutoMapper;
using BusinessLogicLayer.Repositories.Orders;
using BusinessLogicLayer.Repositories.Products;
using BusinessLogicLayer.Services.Orders;
using BusinessLogicLayer.Services.Products;
using DataAccessLayer;
using DataAccessLayer.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddDbContext<SimpleShopDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Repositories
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

// Services
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Controllers
builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        options.SuppressModelStateInvalidFilter = false;
    });

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "SimpleShop API",
        Version = "v1",
        Description = "En enkel order- och produkt-API byggd med .NET 8"
    });
});

var app = builder.Build();

DataInitializer.Initialize(app);

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection(); 

app.UseAuthorization();

app.MapControllers();

app.Run();
