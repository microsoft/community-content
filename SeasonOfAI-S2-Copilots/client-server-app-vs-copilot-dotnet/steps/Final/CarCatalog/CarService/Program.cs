using Azure.Data.Tables;

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

app.MapGet("/api/cars", async () =>
{
    var connectionString = builder.Configuration.GetConnectionString("AzureTableStorage");
    string tableName = "Cars";

    var tableClient = new TableClient(connectionString, tableName);
    var cars = new List<Car>();

    await foreach (var car in tableClient.QueryAsync<Car>())
    {
        cars.Add(car);
    }

    return Results.Ok(cars);
})
.WithName("GetCars")
.WithOpenApi();

app.Run();
