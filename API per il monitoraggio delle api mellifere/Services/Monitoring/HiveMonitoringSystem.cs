using API_per_il_monitoraggio_delle_api_mellifere.Services.DTOs;

namespace API_per_il_monitoraggio_delle_api_mellifere.Services.Monitoring
{
    public class HiveMonitoringSystem
    {
        public static HiveStatus MonitorHive(List<double> temperatures, List<double> humidityLevels, List<double> beeActivity)
        {
            var tempResult = TemperatureMonitor.MonitorTemperature(temperatures);
            var humidityResult = HumidityMonitor.MonitorHumidity(humidityLevels);
            var activityResult = BeeActivityMonitor.MonitorBeeActivity(beeActivity);

            return new HiveStatus
            {
                AverageTemperature = tempResult.AverageTemperature,
                TemperatureAlert = tempResult.Alert,
                AverageHumidity = humidityResult.AverageHumidity,
                HumidityAlert = humidityResult.Alert,
                AverageBeeActivity = activityResult.AverageActivity,
                BeeActivityAlert = activityResult.Alert,
                Timestamp = DateTime.Now
            };
        }
    }
}
