using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.ApplicationInsights.Extensibility;

namespace SwimmingTool.Api.AppInsight
{
    public class StockTelemetryInitializer : ITelemetryInitializer
    {
        public void Initialize(ITelemetry telemetry)
        {
            if (telemetry is not RequestTelemetry requestTelemetry) return;

            requestTelemetry.Properties["Stock"] = DateTime.Now.Millisecond.ToString();
        }
    }
}