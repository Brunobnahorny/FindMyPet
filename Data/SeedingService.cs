using System.Linq;
using FindMyPet.Models;

namespace FindMyPet.Data
{
    public class SeedingService
    {
        private DataContext _context;

        public SeedingService(DataContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Owners.Any() ||
                _context.Pets.Any())
            {
                return; // DB has been seeded
            }

            Owner o1 = new Owner("Bruno Bee Nahorny", "(48) 9999-9999", "bruno@gmail.com");
            Owner o2 = new Owner("James Brown", "(48) 9842-8878", "bruno@gmail.com");


            Pet p1 = new Pet("Johnnie Piazza", ".jpeg", o1);
            Pet p2 = new Pet("Jabé domal", ".png", o1);
            Pet p3 = new Pet("Jabba Hut", ".png", o1);

            Pet p4 = new Pet("Jabé doBem", ".png", o2);
            Pet p5 = new Pet("Obi Wan Kenobi", ".png", o2);


            GeoLocation g1 = new GeoLocation(30, "-27.5881625", "-48.5197954", "1587855323538", p1);
            GeoLocation g2 = new GeoLocation(30, "-27.5881625", "-48.5197954", "1587855323538", p2);
            GeoLocation g3 = new GeoLocation(30, "-27.5881625", "-48.5197954", "1587855323538", p3);
            GeoLocation g4 = new GeoLocation(30, "-27.5881625", "-48.5197954", "1587855323538", p4);
            GeoLocation g5 = new GeoLocation(30, "-27.5881625", "-48.5197954", "1587855323538", p5);


            _context.Owners.AddRange(o1, o2);
            _context.Pets.AddRange(p1, p2, p3, p4, p5);
            _context.GeoLocations.AddRange(g1, g2, g3, g4, g5);

            _context.SaveChanges();
        }
    }
}