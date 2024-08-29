using Microsoft.EntityFrameworkCore;
using QuranApi.Models;

namespace QuranApi
{
    public class QuranDbContext : DbContext
    {
        public QuranDbContext(DbContextOptions<QuranDbContext> options) : base(options)
        {

        }

        // Define the DbSet for the tayah table
        public DbSet<Ayah> Ayahs { get; set; }
        public DbSet<Surah> Surahs { get; set; }

    }
}
