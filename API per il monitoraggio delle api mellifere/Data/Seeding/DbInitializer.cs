using API_per_il_monitoraggio_delle_api_mellifere.Models;
using System;
using System.Linq;
using System.Collections.Generic;

namespace API_per_il_monitoraggio_delle_api_mellifere.Data.Seeding
{
    public static class DbInitializer
    {
        public static void Initialize(ContestoApiario context)
        {
            context.Database.EnsureCreated();

            SeedAlveari(context);
            SeedMisurazioni(context);
        }

        private static void SeedAlveari(ContestoApiario context)
        {
            if (context.Alveari.Any())
            {
                return;   // Alveari have already been seeded
            }

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

        private static void SeedMisurazioni(ContestoApiario context)
        {
            if (context.Misurazioni.Any())
            {
                return;   // Misurazioni have already been seeded
            }

            var alveari = context.Alveari.ToList();
            var random = new Random();
            var misurazioni = new List<Misurazione>();
            var now = DateTime.Now;

            foreach (var alveare in alveari)
            {
                for (int i = 0; i < 24; i++) // 24 measurements for each hive (1 per hour for the last 24 hours)
                {
                    misurazioni.Add(new Misurazione
                    {
                        AlveareId = alveare.Id,
                        Timestamp = now.AddHours(-i),
                        Temperatura = alveare.Temperatura + random.Next(-2, 3),
                        Umidita = alveare.Umidita + random.Next(-5, 6),
                        AttivitaApi = alveare.AttivitaApi + random.Next(-10, 11)
                    });
                }
            }

            context.Misurazioni.AddRange(misurazioni);
            context.SaveChanges();
        }
    }
}
