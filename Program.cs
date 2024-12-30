using WhiteBrookAPI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WhiteBrookAPI.Services.InmateService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IInmateService, InmateService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Enables cors from 5000 to 5001.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost5000", policy =>
    {
        policy.WithOrigins("http://localhost:5000")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});


var app = builder.Build();

// Use CORS middleware.
app.UseCors("AllowLocalhost5000");

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "WhiteBrookAPI V1");
        c.RoutePrefix = string.Empty;  // Serves Swagger UI at the root If you want Swagger to be available at /swagger instead of the root, change the RoutePrefix: c.RoutePrefix = "swagger";With this, Swagger UI would be accessible at http://localhost:5000/swagger or https://localhost:5001/swagger
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();




