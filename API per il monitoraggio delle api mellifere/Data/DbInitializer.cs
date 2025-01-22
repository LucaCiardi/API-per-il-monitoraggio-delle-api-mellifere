using API_per_il_monitoraggio_delle_api_mellifere.Models;

namespace API_per_il_monitoraggio_delle_api_mellifere.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ContestoApiario context)
        {
            // Ensure the database is created
            context.Database.EnsureCreated();

            // Check if any alveari exist
            if (context.Alveari.Any())
            {
                return;   // Database has already been seeded
            }

            // Seed initial data
            var alveari = new Alveare[]
            {
                new Alveare { Posizione = "Posizione 1", Temperatura = 35.5, Umidita = 60.0, Peso = 12.5, AttivitaApi = 100, UltimoAggiornamento = DateTime.Now },
                new Alveare { Posizione = "Posizione 2", Temperatura = 32.0, Umidita = 55.0, Peso = 10.0, AttivitaApi = 80, UltimoAggiornamento = DateTime.Now },
                new Alveare { Posizione = "Posizione 3", Temperatura = 30.0, Umidita = 50.0, Peso = 15.0, AttivitaApi = 120, UltimoAggiornamento = DateTime.Now },
                new Alveare { Posizione = "Posizione 4", Temperatura = 28.5, Umidita = 65.0, Peso = 8.0, AttivitaApi = 90, UltimoAggiornamento = DateTime.Now },
                new Alveare { Posizione = "Posizione 5", Temperatura = 33.0, Umidita = 70.0, Peso = 11.0, AttivitaApi = 110, UltimoAggiornamento = DateTime.Now }
            };

            context.Alveari.AddRange(alveari);
            context.SaveChanges();
        }
    }
}
