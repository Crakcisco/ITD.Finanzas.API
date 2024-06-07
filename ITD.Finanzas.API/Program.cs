using ITD.Finanzas.Application;
using ITD.Finanzas.Application.Interfaces.Context;
using ITD.Finanzas.Application.Interfaces.Presenters;
using ITD.Finanzas.Application.Presenters;
using ITD.Finanzas.Infraestructure;
using ITD.Finanzas.Infraestructure.Repository;
using ITD.Finanzas.Infraestructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// .AddJsonOptions(opciones => opciones.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication(builder.Configuration);
builder.Services.AddCors();

// Register ILoginLogic with its implementation LoginLogic
builder.Services.AddScoped<ILoginLogic, LoginLogic>();
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
