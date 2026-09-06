using Microsoft.EntityFrameworkCore;
using MoviesApp.DataAccess.Data;
using MoviesApp.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// ===> Регистрација на базата
// AddDbContext го прави DbContext-от Scoped: нов по секое HTTP барање.
// Никогаш Singleton - DbContext ги памти вчитаните објекти,
// па споделувањето би протекувало податоци меѓу барања.
builder.Services.AddDbContext<MoviesAppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MoviesAppDb")));

// ===> Регистрација на сервисите
builder.Services.AddApplicationServices();

// ===> Регистрација на репозиториумите
builder.Services.AddRepositories();


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
