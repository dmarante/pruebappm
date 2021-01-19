using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Zoo.Domain.Animals;

namespace Zoo.Infrastructure.EntityFrameworkDataAccess
{
    public class DataContextFake
    {
        public DataContextFake()
        {
            Animals.Add(new Animal {
                Id = 1,
                Ege= 4,
                Name = "Perro",
                NumberLegs = 4
            });
            Animals.Add(new Animal
            {
                Id = 2,
                Ege = 4,
                Name = "Gato",
                NumberLegs = 4
            });
        }
        public Collection<Animal> Animals { get; } = new Collection<Animal>();
    }
}
