using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add CORS services
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");

app.MapGet("/api/cars", () =>
{
    var cars = new List<Car>
    {
        new Car { Make = "Toyota", Model = "Camry", Year = 2022 },
        new Car { Make = "Honda", Model = "Accord", Year = 2021 },
        new Car { Make = "Ford", Model = "Mustang", Year = 2020 }
    };

    return cars;
});

app.Run();

public class Car
{
    public string Make { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
}
