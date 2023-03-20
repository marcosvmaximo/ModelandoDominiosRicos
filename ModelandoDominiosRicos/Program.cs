using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using ModelandoDominiosRicos.API.Controllers;
using ModelandoDominiosRicos.Application.Commands;
using ModelandoDominiosRicos.CrossCutting.Interfaces;
using ModelandoDominiosRicos.Domain.Entities;
using ModelandoDominiosRicos.Domain.Interfaces.Repositories;
using ModelandoDominiosRicos.Domain.Validations;
using ModelandoDominiosRicos.Infra.Data;
using ModelandoDominiosRicos.Infra.Externals;
using ModelandoDominiosRicos.Infra.Repositories;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DataContext>(opt => opt.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddMediatR(typeof(CadastrarClienteCommand));
builder.Services.AddMediatR(typeof(ClienteController));

builder.Services.AddTransient<ISendMailExternal, SendMailExternal>();
builder.Services.AddTransient<IClienteRepository, ClienteRepository>();
builder.Services.AddValidatorsFromAssemblyContaining<ClienteValidation>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
