using bookapi.Controllers;
using bookapi.Repository;
using bookapi.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddScoped<IbookRepository, bookRepository>();
builder.Services.AddScoped<IbookRepository, bookRepository>();
builder.Services.AddScoped<IbookService, bookService>();
builder.Services.AddDbContext<bookDBContext>(b => b.UseSqlServer(builder.Configuration.GetConnectionString("BookDb")));


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
