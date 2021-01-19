using Zoo.Application.Exceptions;
using Zoo.Application.OutputPorts;

namespace Zoo.Application.UseCase.Animal.DeleteAnimal
{
    public class DeleteAnimalInput: IUseCaseInput
    {
        public int Id { get; }

        public DeleteAnimalInput(int id)
        {
            Id = id;
            
            this.Validate();
        }
        private void Validate()
        {
            if (this.Id == 0)
            {
                throw new ApplicationFieldValidationException($"Id es requerido");
            }   
        }
    }
}
