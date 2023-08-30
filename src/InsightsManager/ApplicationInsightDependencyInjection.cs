using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InsightsManager.Configuration;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.Extensions.DependencyInjection;

namespace InsightsManager;

public static class ApplicationInsightDependencyInjection
{
    public static IServiceCollection AddCustomApplicationInsightsTelemetry(this IServiceCollection services)
    {
        var aiOptions = new Microsoft.ApplicationInsights.AspNetCore.Extensions.ApplicationInsightsServiceOptions
        {
            EnableAdaptiveSampling = false,
            EnablePerformanceCounterCollectionModule = false,
        };
        services.AddApplicationInsightsTelemetry(aiOptions);
        services.AddSingleton<ITelemetryInitializer, CloudRoleNameTelemetryInitializer>();

        return services;
    }
}
