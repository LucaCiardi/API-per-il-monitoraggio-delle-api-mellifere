namespace API_per_il_monitoraggio_delle_api_mellifere.Services.Monitoring
{
    public class TemperatureMonitor
    {
        public const double MinOptimalTemp = 34.0;
        public const double MaxOptimalTemp = 36.0;

        public static (double AverageTemperature, string Alert) MonitorTemperature(List<double> temperatures)
        {
            if (temperatures.Count == 0)
            {
                return (0, "Alert: No temperature data available for the last 24 hours!");
            }

            double averageTemperature = temperatures.Average();
            string alert = (averageTemperature < MinOptimalTemp || averageTemperature > MaxOptimalTemp)
                ? $"Alert: Average temperature {averageTemperature:F2}°C is outside the optimal range ({MinOptimalTemp}-{MaxOptimalTemp}°C)!"
                : $"Average temperature {averageTemperature:F2}°C is within the optimal range.";

            return (averageTemperature, alert);
        }
    }

}
