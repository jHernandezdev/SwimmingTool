using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwimmingTool.Api.HostedServices
{
    public class CollectMetricsHostedService : IHostedService, IDisposable
    {
        private Timer? timer = null;
        public ILogger<CollectMetricsHostedService> Logger { get; }

        public CollectMetricsHostedService(ILogger<CollectMetricsHostedService> logger)
        {
            this.Logger = logger;                        
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            timer = new Timer(CollectMetrics, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        private void CollectMetrics(object? state)
        {

        }
    }
}