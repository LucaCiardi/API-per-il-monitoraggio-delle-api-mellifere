namespace API_per_il_monitoraggio_delle_api_mellifere.Services.Monitoring
{
    public class HumidityMonitor
    {
        public const double MinOptimalHumidity = 50.0;
        public const double MaxOptimalHumidity = 75.0;

        public static (double AverageHumidity, string Alert) MonitorHumidity(List<double> humidityLevels)
        {
            if (humidityLevels.Count == 0)
            {
                return (0, "Alert: No humidity data available for the last 24 hours!");
            }

            double averageHumidity = humidityLevels.Average();
            string alert = (averageHumidity < MinOptimalHumidity || averageHumidity > MaxOptimalHumidity)
                ? $"Alert: Average humidity {averageHumidity:F2}% is outside the optimal range ({MinOptimalHumidity}-{MaxOptimalHumidity}%)!"
                : $"Average humidity {averageHumidity:F2}% is within the optimal range.";

            return (averageHumidity, alert);
        }
    }

}
