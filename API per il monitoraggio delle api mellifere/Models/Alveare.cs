using System.ComponentModel.DataAnnotations;

namespace API_per_il_monitoraggio_delle_api_mellifere.Models
{
    public class Alveare
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Posizione { get; set; }

        [Range(0, 50)]
        public double Temperatura { get; set; }

        [Range(0, 100)]
        public double Umidita { get; set; }

        [Range(0, 100)]
        public double Peso { get; set; }

        [Range(0, 1000)]
        public int AttivitaApi { get; set; }

        public DateTime UltimoAggiornamento { get; set; }
    }

}
