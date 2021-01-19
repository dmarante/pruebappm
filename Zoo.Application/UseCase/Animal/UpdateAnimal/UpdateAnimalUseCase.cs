using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zoo.Application.Common;
using Zoo.Application.Entities;
using Zoo.Application.Repository;

namespace Zoo.Application.UseCase.Animal.UpdateAnimal
{
    public class UpdateAnimalUseCase : IUpdateAnimalUseCase
    {
        private readonly IAnimalRepository _animalRepository;

        public UpdateAnimalUseCase(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;

        }

        public async Task<Result> Execute(UpdateAnimalInput input)
        {
            var animals = await _animalRepository.Update(new Domain.Animals.Animal
            {
                Id = input.Id,
                Ege = input.Ege,
                Name = input.Name,
                NumberLegs = input.NumberLegs
            });

            return this.BuildOutput(animals);
        }

        private Result BuildOutput(AnimalResul animal)
        {

            if (animal != null)
            {
                return new Result
                {
                    Data = animal,
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
