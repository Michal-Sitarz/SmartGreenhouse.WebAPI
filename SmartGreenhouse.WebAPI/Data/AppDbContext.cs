using Microsoft.EntityFrameworkCore;
using SmartGreenhouse.WebAPI.Models;

namespace SmartGreenhouse.WebAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Plant> Plants { get; set; }
        public DbSet<SensorNode> SensorNodes { get; set; }
        public DbSet<ConditionsReading> Readings { get; set; }
    }
}
