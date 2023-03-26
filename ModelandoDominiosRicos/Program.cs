using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ModelandoDominiosRicos.API.Controllers;
using ModelandoDominiosRicos.Application.ClienteContext.Commands;
using ModelandoDominiosRicos.CrossCutting.Interfaces;
using ModelandoDominiosRicos.Domain.Interfaces.Repositories;
using ModelandoDominiosRicos.Domain.Validations;
using ModelandoDominiosRicos.Infra.Data;
using ModelandoDominiosRicos.Infra.Externals;
using ModelandoDominiosRicos.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DataContext>(opt => opt.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddMediatR(typeof(CadastrarClienteCommand));
builder.Services.AddMediatR(typeof(ClienteController));

builder.Services.AddTransient<ISendMailExternal, SendMailExternal>();
builder.Services.AddTransient<IClienteRepository, ClienteRepository>();
builder.Services.AddTransient<IProdutoRepository, ProdutoRepository>();
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
