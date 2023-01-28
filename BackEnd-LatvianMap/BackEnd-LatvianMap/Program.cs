using BackEnd_LatvianMap.LatvianPlaces.Infrastructure.Persistence.csv;
using BackEnd_LatvianMap.LatvianPlaces.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(option =>
{
    option.AddPolicy("CorsPolicy",
        builder => builder.WithOrigins("http://localhost:8080")
            .AllowAnyHeader()
            .AllowAnyHeader()
            .AllowCredentials()
    );
});

// Dependency Injection
builder.Services.AddScoped<IPlacesCentroidRepository, CsvPlacesCentroidRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
