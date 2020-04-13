using System.Linq;
using System.Threading.Tasks;
using findmypet.Models;
using Microsoft.EntityFrameworkCore;

namespace findmypet.Data
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
            query = query.AsNoTracking().OrderBy(a => a.Id);
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
            query = query.Include(q => q.Pets);
            query = query.Where(a => a.Id == ownerId).AsNoTracking();
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Pet> GetPetByIdAsync(int petId)
        {
            IQueryable<Pet> query = _context.Pets;
            query = query.Where(a => a.PetId == petId).AsNoTracking();
            return await query.FirstOrDefaultAsync();
        }
    }
}