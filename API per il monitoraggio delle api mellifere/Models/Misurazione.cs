namespace API_per_il_monitoraggio_delle_api_mellifere.Models
{
    public class Misurazione
    {
        public int Id { get; set; }
        public int AlveareId { get; set; }
        public DateTime Timestamp { get; set; }
        public double Temperatura { get; set; }
        public double Umidita { get; set; }
        public double AttivitaApi { get; set; }
    }

}
