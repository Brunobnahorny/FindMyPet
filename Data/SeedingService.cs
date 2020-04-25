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

            Pet p1 = new Pet("Johnnie Piazza", "Rua Professor Bento Águido Vieira, 144 - Trindade - Florianópolis", ".jpeg");
            Pet p2 = new Pet("Jabé domal", "Rua Professor Bento Águido Vieira, 144 - Trindade - Florianópolis", ".png");
            Pet p3 = new Pet("Jabba Hut", "Rua Delminda Silveira, 144 - Trindade - Florianópolis", ".png");


            _context.Owners.AddRange(o1, o2);
            _context.Pets.AddRange(p1, p2, p3);

            _context.SaveChanges();
        }
    }
}