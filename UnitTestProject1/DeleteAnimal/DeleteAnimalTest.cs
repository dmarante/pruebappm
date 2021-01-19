using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Zoo.Application.UseCase.Animal.DeleteAnimal;

namespace UnitTestProject1.DeleteAnimal
{
    [TestClass]
    public class DeleteAnimalTest
    {
        private readonly StandardFixture _fixture;

        public DeleteAnimalTest()
        {
            this._fixture = new StandardFixture();
        }

        [TestMethod]
        public void DeleteAnimalUseCaseTest()
        {
            DeleteAnimalUseCase animalUseCase = new DeleteAnimalUseCase(_fixture.AnimalRepositoryFake);
            var resul = animalUseCase.Execute(new DeleteAnimalInput(1));
            Assert.AreEqual(0, resul.Result.Error);
        }
    }
}
