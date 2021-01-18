using System;
using System.Collections.Generic;
using System.Text;
using Zoo.Application.Exceptions;
using Zoo.Application.OutputPorts;

namespace Zoo.Application.UseCase.Animal.CreateAnimal
{
    public class CreateAnimalInput : IUseCaseInput
    {
        
        public string Name { get;  }
        public int Ege { get;  }
        public int NumberLegs { get; }

        public CreateAnimalInput(string name, int ege, int numberLegs)
        {
            Name = name;
            Ege = ege;
            NumberLegs = numberLegs;
            this.Validate();
        }
        private void Validate()
        {
            if (string.IsNullOrWhiteSpace(this.Name))
            {
                throw new ApplicationFieldValidationException($"Nombre es requerido");
            }
            if (this.Ege ==0)
            {
                throw new ApplicationFieldValidationException($"Edad es requerido");
            }
            if (this.NumberLegs ==0)
            {
                throw new ApplicationFieldValidationException($"Numero de piernas");
            }
        }
    }
    
}
