namespace Zoo.Infrastructure.EntityFrameworkDataAccess.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Zoo.Application.Entities;
    using Zoo.Application.Repository;
    using Zoo.Infrastructure.EntityFrameworkDataAccess.Entities;


    public sealed class AnimalRepository : IAnimalRepository
    {
        private readonly DataContext _context;

        public AnimalRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Domain.Animals.Animal> Add(Domain.Animals.Animal _animal)
        {
            var resul = await _context.Animal.AddAsync(new Animal
            {
                Name = _animal.Name,
                Ege = _animal.Ege,
                NumberLegs = _animal.NumberLegs
            }).ConfigureAwait(false);
            _context.SaveChanges();

            return new Domain.Animals.Animal
            {
                Id = resul.Entity.Id,
                Ege = resul.Entity.Ege,
                Name = resul.Entity.Name,
                //NumberLegs = resul.Entity.NumberLegs
            };
        }


        public async Task<bool> Delete(int id)
        {
            var animalDelete = _context.Animal.FirstOrDefault(x => x.Id == id);
            _context.Remove(animalDelete);
            return true;
        }

        public async Task<AnimalResul> Get(int id)
        {
            var resul = _context.Animal.FirstOrDefault(x => x.Id == id);

            return new AnimalResul
            {
                Id = resul.Id,
                Name = resul.Name,
                Ege = resul.Ege,
                NumberLegs = resul.NumberLegs,
            };

        }

        public async Task<IEnumerable<AnimalResul>> GetAll(string search, int PageNumber, int pageSize)
        {
            try
            {

                IEnumerable<Animal> rawDatas = _context.Animal;

                if (search != null && search != string.Empty)
                {
                    rawDatas = rawDatas.Where(x => x.Name.Contains(search));
                }
                else
                {
                    rawDatas = rawDatas.Where(x => x.Id != null);
                }
                var list = rawDatas.Skip((PageNumber - 1) * pageSize).Take(pageSize).Select(x => new AnimalResul
                {
                    Id = x.Id,
                    Ege = x.Ege,
                    Name = x.Name,
                })
                .ToList();
                
                return list;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<AnimalResul> Update(Domain.Animals.Animal data)
        {
            var animal = _context.Animal.FirstOrDefault(x => x.Id == data.Id);
            animal.Name = data.Name;
            animal.NumberLegs = data.NumberLegs;
            animal.Ege = data.Ege;
            _context.SaveChanges();

            return new AnimalResul
            {
                Id = animal.Id,
                Ege = animal.Ege,
                Name = animal.Name,
                NumberLegs = animal.NumberLegs
            };
        }
    }
}
