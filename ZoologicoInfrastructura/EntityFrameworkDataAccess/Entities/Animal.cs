using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Zoo.Infrastructure.EntityFrameworkDataAccess.Entities
{
    public class Animal 
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Ege { get; set; }
        public int NumberLegs { get; set; }
    }
}
