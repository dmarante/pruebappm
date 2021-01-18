using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zoo.Application.Common;
using Zoo.Application.Repository;

namespace Zoo.Application.UseCase.Animal.DeleteAnimal
{
    public class DeleteAnimalUseCase : IDeleteAnimalUseCase
    {
        private readonly IAnimalRepository _animalRepository;

        public DeleteAnimalUseCase(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;

        }
        public async Task<Result> Execute(DeleteAnimalInput input)
        {
            var resul  = await _animalRepository.Delete( input.Id);

            return this.BuildOutput(resul);
        }

        private Result BuildOutput(bool resul )
        {

            if (resul == true)
            {
                return new Result
                {
                    Data = null,
                    Error = 0,
                    Mes = "Elemento eliminado"
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
