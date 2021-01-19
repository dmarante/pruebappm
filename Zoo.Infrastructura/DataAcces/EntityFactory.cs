using Zoo.Domain;
using Zoo.Domain.Animals;

namespace Zoo.Infrastructure.DataAcces
{
    public sealed class EntityFactory : IAnimalFactory
    {
        public Animal NewAnimal(int Id, string Name, int Ege, int NumberLegs) => new Animal(Id, Name, Ege, NumberLegs);
        
    }
}
