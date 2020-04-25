using FindMyPet.Models;
using Microsoft.EntityFrameworkCore;

namespace FindMyPet.Data
{

    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<GeoLocation> GeoLocations { get; set; }
    }
}