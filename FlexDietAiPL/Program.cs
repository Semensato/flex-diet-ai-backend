using FlexDietAiBAL.Services;
using FlexDietAiDAL.Data;
using FlexDietAiDAL.Interfaces;
using FlexDietAiDAL.Models;
using FlexDietAiDAL.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
ConfigurationManager configuration = builder.Configuration;

// For Entity Framework.
builder.Services.AddDbContext<FlexDietAiDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

// Dependecy Injection.
builder.Services.AddTransient<IRepository<User>, RepositoryUser>();
builder.Services.AddTransient<UserService, UserService>();

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
