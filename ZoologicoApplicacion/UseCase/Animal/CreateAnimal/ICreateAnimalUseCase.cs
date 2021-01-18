using System;
using System.Collections.Generic;
using System.Text;
using Zoo.Application.OutputPorts;
using Zoo.Application.UseCase.Animal.GetAnimal;

namespace Zoo.Application.UseCase.Animal.CreateAnimal
{
    public interface ICreateAnimalUseCase : IUseCase<CreateAnimalInput>
    {
    }
}
