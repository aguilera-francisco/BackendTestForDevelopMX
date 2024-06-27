
using BackendTest.Controllers;
using BackendTest.DTOs;
using BackendTest.Models;
using BackendTest.Repositories;
using BackendTest.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddHttpClient<IRepository<Customer>, Repository>(c => { 
//    c.BaseAddress = new Uri(builder.Configuration["Base"])
//});
//REPOSITORY
builder.Services.AddScoped<IRepository<Customer>, Repository>();
builder.Services.AddScoped<ICustomerService<CustomerDTO, AddressDTO>, CustomerService>(); 


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
