using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.ApplicationInsights;

namespace SwimmingTool.Api.HostedServices
{
    public class CollectMetricsHostedService : IHostedService, IDisposable
    {
        private Timer? timer = null;
        private TelemetryClient telemetryClient;
        private ILogger<CollectMetricsHostedService> logger { get; }
        private Metric metric;


        public CollectMetricsHostedService(ILogger<CollectMetricsHostedService> logger, TelemetryClient telemetryClient)
        {
            this.logger = logger;
            this.telemetryClient = telemetryClient;
        }

        public void Dispose()
        {
            timer?.Dispose();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            metric = telemetryClient.GetMetric("MetricName", "Dimendion1");
            timer = new Timer(CollectMetrics, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        private void CollectMetrics(object? state)
        {
            int metricValue1 = Random.Shared.Next(0, 100);
            int metricValue2 = Random.Shared.Next(0, 100);
            int metricValue3 = Random.Shared.Next(0, 100);
            
            logger.LogInformation($"1: {metricValue1}, 2: {metricValue2}, 3: {metricValue3}");
            
            metric.TrackValue(metricValue1, "DimensionValue1");
            metric.TrackValue(metricValue2, "DimensionValue2");
            metric.TrackValue(metricValue3, "DimensionValue3");
            
        }
    }
}