using Microsoft.EntityFrameworkCore;
using WebApplication1AGRO.Context;
using WebApplication1AGRO.Repositories;
using WebApplication1AGRO.Repositories.InterfacesRepository;
using WebApplication1AGRO.Services;
using WebApplication1AGRO.Services.InterfacesServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("Connection");
builder.Services.AddDbContext<AgroDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

//Record of repositories and services
builder.Services.AddScoped<ICollectionsRepository, CollectionsRepository>();
builder.Services.AddScoped<ICollectionsService, CollectionsService>();

builder.Services.AddScoped<IOffersRepository, OffersRepository>();
builder.Services.AddScoped<IOffersService, OffersService>();

builder.Services.AddScoped<IProductCategoriesRepository, ProductCategoriesRepository>();
builder.Services.AddScoped<IProductCategoriesService, ProductCategoriesService>();

builder.Services.AddScoped<IProductDetailsRepository, ProductDetailsRepository>();
builder.Services.AddScoped<IProductDetailsService, ProductDetailsService>();

builder.Services.AddScoped<IProductsRepository, ProductsRepository>();
builder.Services.AddScoped<IProductsService, ProductsService>();




