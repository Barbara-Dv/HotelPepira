using Microsoft.EntityFrameworkCore;
using HotelPepira.Models;

namespace HotelPepira.Data
{
    public class HotelDbContext : DbContext
    {
        public DbSet<Quarto> Quartos { get; set; }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            string caminhoBanco = Path.Combine(
                FileSystem.AppDataDirectory,
                "hotelpepira.db3"
            );

            optionsBuilder.UseSqlite(
                $"Filename={caminhoBanco}"
            );
        }
    }
}