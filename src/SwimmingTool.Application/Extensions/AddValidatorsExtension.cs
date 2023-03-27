using System;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace SwimmingTool.Application.Extensions;

public static class AddValidatorsExtension
{
	public static IServiceCollection AddValidators(this IServiceCollection services)
	{
		services.AddValidatorsFromAssembly(typeof(AddValidatorsExtension).Assembly);
		return services;
	}
}

