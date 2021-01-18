
namespace Zoo.Application.Repository
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Zoo.Application.Entities;
    using Zoo.Domain.Animals;
    

    public interface IAnimalRepository
    {
        Task<Animal> Add(Animal _animal);
        Task<AnimalResul> Get(int id);
        Task<AnimalResul> Update(Animal _animal);
        Task<bool> Delete(int id);
        Task<IEnumerable<AnimalResul>> GetAll(string search, int skip, int  pageSize);
    }
}
