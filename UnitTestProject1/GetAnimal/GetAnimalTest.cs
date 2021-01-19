using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Zoo.Application.UseCase.Animal.GetAnimal;

namespace UnitTestProject1.GetAnimal
{
    [TestClass]
    public class GetAnimalTest
    {
        private readonly StandardFixture _fixture;

        public GetAnimalTest()
        {
            this._fixture = new StandardFixture();
        }

        [TestMethod]
        public void GetAnimalUseCaseTest()
        {
            GetAnimalUseCase animalUseCase = new GetAnimalUseCase(_fixture.AnimalRepositoryFake);
            var resul = animalUseCase.Execute(new GetAnimalInput(1,0,0,null));

            Assert.AreEqual(0, resul.Result.Error);
        }
    }
}
