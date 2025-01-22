using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace API_per_il_monitoraggio_delle_api_mellifere.Models
{
    public class ContestoApiario : DbContext
    {
        public ContestoApiario(DbContextOptions<ContestoApiario> options) : base(options) { }

        public DbSet<Alveare> Alveari { get; set; }
        public DbSet<Misurazione> Misurazioni { get; set; }
    }

}
