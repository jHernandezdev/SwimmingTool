using MinimalApi.Endpoint.Extensions;
using SwimmingTool.Infrastructure.DataAccess;
using SwimmingTool.Domain;
using SwimmingTool.Application.Extensions;
using Microsoft.ApplicationInsights.Extensibility;
using SwimmingTool.Api.AppInsight;

var builder = WebApplication.CreateBuilder(args);

// MinimalApi.Endpoint registration
builder.Services.AddEndpoints();

builder.Services.AddDataAccessServices(builder.Configuration["DefaultConnection"]);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddScoped(typeof(IAsyncRepository<,>), typeof(EfRepository<,>));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(config => config.EnableAnnotations());
builder.Services.AddCommandsAndQueries();
builder.Services.AddValidators();
builder.Services.AddValidationPipelineBehaviour();


var aiOptions = new Microsoft.ApplicationInsights.AspNetCore.Extensions.ApplicationInsightsServiceOptions
{
    EnableAdaptiveSampling = false,
    EnablePerformanceCounterCollectionModule = false,
};
builder.Services.AddApplicationInsightsTelemetry(aiOptions);
builder.Services.AddSingleton<ITelemetryInitializer, CloudRoleNameTelemetryInitializer>();
builder.Services.AddSingleton<ITelemetryInitializer, StockTelemetryInitializer>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapEndpoints();

app.Run();
