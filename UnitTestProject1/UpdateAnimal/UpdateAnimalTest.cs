using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Zoo.Application.UseCase.Animal.UpdateAnimal;

namespace UnitTestProject1.UpdateAnimal
{
    [TestClass]
    public class UpdateAnimalTest
    {

        private readonly StandardFixture _fixture;

        public UpdateAnimalTest()
        {
            this._fixture = new StandardFixture();
        }

        [TestMethod]
        public void UpdateAnimalUseCaseTest()
        {
            UpdateAnimalUseCase animalUseCase = new UpdateAnimalUseCase(_fixture.AnimalRepositoryFake);
            var resul = animalUseCase.Execute(new UpdateAnimalInput(1,"pepe", 3,2));

            Assert.AreEqual(0, resul.Result.Error);
        }
    }
}
