using System;
using System.ComponentModel.DataAnnotations;

namespace Zoo.Domain.Animals
{
    public class Animal :IEntity
    {
        public Animal() { }
        public Animal(int id, string name, int ege, int numberLegs)
        {
            Id = id;
            Name = name;
            Ege = ege;
            NumberLegs = numberLegs;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Ege { get; set; }
        public int NumberLegs { get; set; }
    }
}
