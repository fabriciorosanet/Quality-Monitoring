using Microsoft.EntityFrameworkCore;
using QualityMonitoring.Models;

namespace QualityMonitoring.Data.Contexts 
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }
        protected DatabaseContext()
        {
        }

        public DbSet<AirQuality> AirQuality { get; set; }
        public DbSet<WaterQuality> WaterQualities { get; set; }
    }
}



    

