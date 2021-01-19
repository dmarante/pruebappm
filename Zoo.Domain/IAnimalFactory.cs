using Zoo.Domain.Animals;

namespace Zoo.Domain
{
    public interface IAnimalFactory
    {
        Animal NewAnimal(int Id, string Name, int Ege, int NumberLegs);
    }
}
