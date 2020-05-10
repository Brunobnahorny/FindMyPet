using System.Linq;
using System.Threading.Tasks;
using FindMyPet.Models;
using Microsoft.EntityFrameworkCore;

namespace FindMyPet.Data
{
    public class DataRepository : IDataRepository
    {
        public DataContext _context { get; }
        public DataRepository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }

        public async Task<Owner[]> GetAllOwnersAsync(bool includePets)
        {
            IQueryable<Owner> query = _context.Owners;
            if (includePets)
            {
                query = query.Include(a => a.Pets);
            }
            query = query.AsNoTracking().OrderBy(a => a.OwnerId);
            return await query.ToArrayAsync();
        }

        public async Task<Pet[]> GetAllPetsAsync()
        {
            IQueryable<Pet> query = _context.Pets;
            query = query.Include(a => a.Owner);
            query = query.AsNoTracking().OrderBy(a => a.PetId);
            return await query.ToArrayAsync();
        }

        public async Task<Owner> GetOwnerByIdAsync(int ownerId, bool includePets)
        {
            IQueryable<Owner> query = _context.Owners;
            query = query.Include(q => q.Pets).ThenInclude(q => q.LastGeoLocations);
            query = query.Where(a => a.OwnerId == ownerId).AsNoTracking();
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Pet> GetPetByIdAsync(int petId, bool ownerJoin = true)
        {
            IQueryable<Pet> query = _context.Pets;
            if (ownerJoin == true)
            {
                query = query.Include(q => q.Owner);
            }
            query = query.Where(a => a.PetId == petId).AsNoTracking();
            return await query.FirstOrDefaultAsync();
        }
    }
}