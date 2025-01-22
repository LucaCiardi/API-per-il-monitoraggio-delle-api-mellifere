namespace API_per_il_monitoraggio_delle_api_mellifere.Models
{
    public class Alveare
    {
        public int Id { get; set; }
        public string Posizione { get; set; }
        public double Temperatura { get; set; }
        public double Umidita { get; set; }
        public double Peso { get; set; }
        public int AttivitaApi { get; set; }
        public DateTime UltimoAggiornamento { get; set; }
    }

}
