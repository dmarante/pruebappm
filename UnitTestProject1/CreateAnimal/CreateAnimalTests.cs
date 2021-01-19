using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Zoo.Application.UseCase.Animal.CreateAnimal;

namespace UnitTestProject1.CreateAnimal
{
    [TestClass]
    public class CreateAnimalTests
    {
        private readonly StandardFixture _fixture;

        public CreateAnimalTests()
        {
            this._fixture = new StandardFixture();
        }

        [TestMethod]
        public void CreateAnimalUseCaseTest()
        {
            CreateAnimalUseCase animalUseCase = new CreateAnimalUseCase(_fixture.AnimalRepositoryFake);
            var resul = animalUseCase.Execute(new CreateAnimalInput("Pepe", 21, 3));
            Assert.AreEqual(22, resul.Result.Data);
        }


    }
}
