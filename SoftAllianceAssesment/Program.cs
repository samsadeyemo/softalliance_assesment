using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SoftAllianceAssesment.DB_Context;
using SoftAllianceAssesment.HelperClass;
using SoftAllianceAssesment.Interface;
using SoftAllianceAssesment.Services;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
IConfiguration Configuration = builder.Configuration;
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MovieContext>(x => x.UseSqlServer(Configuration.GetConnectionString("ConnectionString")));
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});
builder.Services.AddScoped<ValidationFilter>();
builder.Services.AddScoped<ICountry, CountryService>();
builder.Services.AddScoped<IMovie, MovieService>();
builder.Services.AddScoped<IGenre, GenreService>();
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
