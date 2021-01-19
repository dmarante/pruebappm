using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zoo.Application.Entities;
using Zoo.Application.Repository;
using Zoo.Domain.Animals;

namespace Zoo.Infrastructure.EntityFrameworkDataAccess.Repositories
{
    public class AnimalRepositoryFake : IAnimalRepository
    {
        private readonly DataContextFake _context = new DataContextFake();

        public async Task<Animal> Add(Animal _animal)
        {
            _context.Animals.Add(new Animal
            {
                Id = 22,
                Name = _animal.Name,
                Ege = _animal.Ege,
                NumberLegs = _animal.NumberLegs
            });
            

            return new Domain.Animals.Animal
            {
                Id= 22,
                Ege = _animal.Ege,
                Name = _animal.Name,
                NumberLegs = _animal.NumberLegs,
            };
        }

        public async Task<bool> Delete(int id)
        {
            _context.Animals.Remove(_context.Animals[0]);
            return true;
        }

        public async Task<AnimalResul> Get(int id)
        {
            var animal = _context.Animals[0];
            return new AnimalResul
            {
                Id = animal.Id,
                Ege = animal.Ege,
                Name = animal.Name,
                NumberLegs = animal.NumberLegs
            };
        }

        public Task<IEnumerable<AnimalResul>> GetAll(string search, int skip, int pageSize)
        {
            throw new NotImplementedException();
        }

        public async Task<AnimalResul> Update(Animal _animal)
        {
            return new AnimalResul
            {
                Id = 1,
                Ege = 4,
                Name = "Gato",
                NumberLegs = 4
            };
        }
    }
}
