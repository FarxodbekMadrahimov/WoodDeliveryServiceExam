using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Wood.Application;
using Request.Infrastructure;
using Request.Application.Absreactions;
using Request.Infrastructure.Persistance;
using FluentAssertions.Common;
using System.Reflection;
using MediatR;
var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddInfrastructure(builder.Configuration);
    
// Add services to the container.
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddAplications();

builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddDbContext<DeliveryDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
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
