namespace API_per_il_monitoraggio_delle_api_mellifere.Services.DTOs
{
        public class HiveStatus
    {
        public double AverageTemperature { get; set; }
        public string TemperatureAlert { get; set; }
        public double AverageHumidity { get; set; }
        public string HumidityAlert { get; set; }
        public double AverageBeeActivity { get; set; }
        public string BeeActivityAlert { get; set; }
        public DateTime Timestamp { get; set; }
    }

}
