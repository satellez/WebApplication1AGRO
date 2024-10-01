using Microsoft.EntityFrameworkCore;
using WebApplication1AGRO.Context;
using WebApplication1AGRO.Repositories;
using WebApplication1AGRO.Repositories.InterfacesRepository;
using WebApplication1AGRO.Services;
using WebApplication1AGRO.Services.InterfacesRepository;
using WebApplication1AGRO.Services.InterfacesService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("Connection");
builder.Services.AddDbContext<AgroDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Record of repositories and services
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

builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped<IUsersService, UsersService>();

builder.Services.AddScoped<IUserTypesRepository, UserTypesRepository>();
builder.Services.AddScoped<IUserTypesService, UserTypesService>();

builder.Services.AddScoped<IBillsRepository, BillsRepository>();
builder.Services.AddScoped<IBillsService, BillsService>();

builder.Services.AddScoped<IBillDetailsRepository, BillDetailsRepository>();
builder.Services.AddScoped<IBillDetailsService, BillDetailsService>();

builder.Services.AddScoped<IContactsRepository, ContactsRepository>();
builder.Services.AddScoped<IContactsService, ContactsService>();

builder.Services.AddScoped<IDataTypesRepository, DataTypesRepository>();
builder.Services.AddScoped<IDataTypesService, DataTypesService>();

builder.Services.AddScoped<IDocumentsRepository, DocumentsRepository>();
builder.Services.AddScoped<IDocumentsService, DocumentsService>();

builder.Services.AddScoped<IPaymentMethodsRepository, PaymentMethodsRepository>();
builder.Services.AddScoped<IPaymentMethodsService, PaymentMethodsService>();

// Build the app
var app = builder.Build();

// Configure the HTTP request pipeline.

    app.UseSwagger();
    app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
