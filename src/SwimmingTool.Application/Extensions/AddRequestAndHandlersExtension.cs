using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace SwimmingTool.Application.Extensions;

public static class AddCommandsExtension
{
  public static IServiceCollection AddCommandsAndQueries(this IServiceCollection services)
  {
    services.AddMediatR(Assembly.GetExecutingAssembly());
    return services;
  }
}