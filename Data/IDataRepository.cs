using System.Threading.Tasks;
using FindMyPet.Models;

namespace FindMyPet.Data
{
    public interface IDataRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        //Owners
        Task<Owner[]> GetAllOwnersAsync(bool includePets);
        Task<Owner> GetOwnerByIdAsync(int OwnerId, bool includePets);

        //Pets
        Task<Pet[]> GetAllPetsAsync();
        Task<Pet> GetPetByIdAsync(int PetId, bool ownerJoin = true);
    }
}