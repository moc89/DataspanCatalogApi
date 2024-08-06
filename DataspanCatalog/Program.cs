using Dataspan.Api.Application.Interfaces;
using Dataspan.Api.Application.Services;
using Dataspan.Api.Repository;
using Dataspan.Api.Repository.Interfaces;
using Dataspan.Api.Repository.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IAuthorServices, AuthorServices>();
builder.Services.AddScoped<IBookServices, BookServices>();
builder.Services.AddScoped<ICatalogRepo, CatalogRepo>();

builder.Services.AddDbContext<CatalogContext>(options =>
    options.UseInMemoryDatabase("CatalogDB"));

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
