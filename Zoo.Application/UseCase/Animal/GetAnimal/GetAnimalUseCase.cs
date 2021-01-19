using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoo.Application.Common;
using Zoo.Application.Entities;
using Zoo.Application.Repository;

namespace Zoo.Application.UseCase.Animal.GetAnimal
{
    public class GetAnimalUseCase : IGetAnimalUseCase
    {
        private readonly IAnimalRepository _animalRepository;
        
        public GetAnimalUseCase(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        
        }

        public async Task<Result> Execute(GetAnimalInput input)
        {
            
          
            if (input.Id != null)
            {
                var animal = await _animalRepository.Get((int)input.Id);
                return this.BuildOutput(animal);
            }
            else
            {
                var animals = await _animalRepository.GetAll(input.Search, input.PageNumber,input.PageSize);
                return this.BuildOutput(animals.ToList());
            }

            

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
                    Error = 404,
                    Mes = "Animal not found"
                };
            }
        }
        private  Result BuildOutput(List<AnimalResul> animals)
        {
            if (animals != null && animals.Count > 0)
            {
                return new Result
                {
                    Data = animals,
                    Error = 0,
                    Mes = ""
                };
                
            }
            else
            {
                return new Result
                {
                    Data = null,
                    Error = 404,
                    Mes = "Animal not found"
                };
            }
        }
    }
}
