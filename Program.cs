
using BackendTest.Controllers;
using BackendTest.DTOs;
using BackendTest.Models;
using BackendTest.Repositories;
using BackendTest.Services;
using BackendTest.Validators;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//REPOSITORY
builder.Services.AddScoped<IRepository<Customer>, Repository>();
builder.Services.AddScoped<ICustomerService<CustomerDTO, AddressDTO>, CustomerService>(); 
//VALIDATORS
builder.Services.AddScoped<IValidator<string>, PostalCodeValidator>();
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
