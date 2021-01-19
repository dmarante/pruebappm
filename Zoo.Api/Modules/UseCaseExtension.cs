using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Zoo.Application.Repository;
using Zoo.Application.UseCase;
using Zoo.Application.UseCase.Animal.CreateAnimal;
using Zoo.Application.UseCase.Animal.DeleteAnimal;
using Zoo.Application.UseCase.Animal.GetAnimal;
using Zoo.Application.UseCase.Animal.UpdateAnimal;
using Zoo.Application.UseCase.User;
using Zoo.Domain;
using Zoo.Infrastructure.DataAcces;
using Zoo.Infrastructure.EntityFrameworkDataAccess.Repositories;

namespace Zoo.Api.Modules
{
    public static class UseCaseExtension
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            
            services.AddScoped<IUser, UserUseCase>();
            services.AddScoped<IAnimalRepository, AnimalRepository>();
            services.AddScoped<IAnimalFactory, EntityFactory>();
            services.AddScoped<IdentityUser, ApplicationUser>();
            
            services.AddScoped<IGetAnimalUseCase, GetAnimalUseCase>();
            services.AddScoped<ICreateAnimalUseCase, CreateAnimalUseCase>();
            services.AddScoped<IUpdateAnimalUseCase, UpdateAnimalUseCase>();
            services.AddScoped<IDeleteAnimalUseCase, DeleteAnimalUseCase>();

            
            services.AddAutoMapper(typeof(MappingProfile));
            
            return services;
        }
    }

}
