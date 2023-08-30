using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.Extensions.Configuration;


namespace InsightsManager.Configuration
{
    public class CloudRoleNameTelemetryInitializer : ITelemetryInitializer
    {
        private readonly IConfiguration _configuration;

        public CloudRoleNameTelemetryInitializer(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Initialize(ITelemetry telemetry)
        {
            string roleName = _configuration["CloudRoleName"];
            if (!string.IsNullOrEmpty(roleName))
            {
                telemetry.Context.Cloud.RoleName = roleName;
            }
        }
    }
}