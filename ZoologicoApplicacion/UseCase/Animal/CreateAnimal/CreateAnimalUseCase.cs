using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zoo.Application.Common;
using Zoo.Application.Repository;
using Zoo.Application.UseCase.Animal.GetAnimal;

namespace Zoo.Application.UseCase.Animal.CreateAnimal
{
    public class CreateAnimalUseCase : ICreateAnimalUseCase
    {
        private readonly IAnimalRepository _animalRepository;

        public CreateAnimalUseCase(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;

        }

        public async Task<Result> Execute(CreateAnimalInput input)
        {
            var animals = await _animalRepository.Add(new Domain.Animals.Animal{
                Ege = input.Ege,
                Name = input.Name,
                NumberLegs = input.NumberLegs
            });

            return this.BuildOutput(animals);
        }

        private Result BuildOutput(Domain.Animals.Animal animal)
        {

            if (animal != null)
            {
                return new Result
                {
                    Data = animal.Id,
                    Error = 0,
                    Mes = ""
                };

            }
            else
            {
                return new Result
                {
                    Data = null,
                    Error = 500,
                    Mes = "Error en el proceso"
                };
            }
        }
    }
}
