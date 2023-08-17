using NerdStore.Enterprise.Core.Application;
using NerdStore.Enterprise.Core.Application.Interfaces;
using NerdStore.Enterprise.Core.Domain.Interfaces;
using NerdStore.Enterprise.Core.Domain.Services;
using NerdStore.Enterprise.Core.Infrastructure.Context;
using NerdStore.Enterprise.Core.Infrastructure.Context.Interface;
using NerdStore.Enterprise.Core.Infrastructure.Repositories;
using NerdStore.Enterprise.Core.Infrastructure.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add dependency in injection
builder.Services.AddScoped<INerdStoreRepository, NerdStoreRepository>();
builder.Services.AddScoped<IDapperContext, DapperContext>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserApplication, UserApplication>();

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
