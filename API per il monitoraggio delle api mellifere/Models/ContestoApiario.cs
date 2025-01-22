using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace API_per_il_monitoraggio_delle_api_mellifere.Models
{
    public class ContestoApiario : DbContext
    {
        public ContestoApiario(DbContextOptions<ContestoApiario> options) : base(options) { }

        public DbSet<Alveare> Alveari { get; set; }
        public DbSet<Misurazione> Misurazioni { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }
    }

}
