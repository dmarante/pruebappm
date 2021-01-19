using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zoo.Api.ViewModels;
using Zoo.Application.Entities;
using Zoo.Domain.Animals;

namespace Zoo.Api.Modules
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<AnimalResul,AnimalViewModel>();
            CreateMap<AnimalViewModel, AnimalResul>();
            CreateMap<AnimalResul, Animal>();
            CreateMap<Animal, AnimalResul>();
        }
    }
}
