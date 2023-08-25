using MinimalApi.Endpoint.Extensions;
using SwimmingTool.Infrastructure.DataAccess;
using SwimmingTool.Domain;
using SwimmingTool.Application.Extensions;

var builder = WebApplication.CreateBuilder(args);

// MinimalApi.Endpoint registration
builder.Services.AddEndpoints();

builder.Services.AddDataAccessServices(builder.Configuration.GetConnectionString("DefaultConnection"));

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddScoped(typeof(IAsyncRepository<,>), typeof(EfRepository<,>));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(config => config.EnableAnnotations());
builder.Services.AddCommandsAndQueries();
builder.Services.AddValidators();
builder.Services.AddValidationPipelineBehaviour();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.MapEndpoints();

app.Run();
