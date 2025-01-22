namespace API_per_il_monitoraggio_delle_api_mellifere.Services.Monitoring
{
    public class BeeActivityMonitor
    {
        public const double LowActivityThreshold = 100;

        public static (double AverageActivity, string Alert) MonitorBeeActivity(List<double> beeActivity)
        {
            if (beeActivity.Count == 0)
            {
                return (0, "Alert: No bee activity data available for the last 24 hours!");
            }

            double averageActivity = beeActivity.Average();
            string alert = (averageActivity < LowActivityThreshold)
                ? $"Alert: Average bee activity {averageActivity:F2} is below the threshold of {LowActivityThreshold}!"
                : $"Average bee activity {averageActivity:F2} is above the threshold.";

            return (averageActivity, alert);
        }
    }

}
