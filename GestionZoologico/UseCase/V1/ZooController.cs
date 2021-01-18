﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Zoo.Api.ViewModels;
using Zoo.Application.Entities;
using Zoo.Application.UseCase.Animal.CreateAnimal;
using Zoo.Application.UseCase.Animal.DeleteAnimal;
using Zoo.Application.UseCase.Animal.GetAnimal;
using Zoo.Application.UseCase.Animal.UpdateAnimal;

namespace Zoo.Api.UseCase.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    //[Authorize]
    public class ZooController : ControllerBase
    {

        
        private readonly ILogger<ZooController> _logger;
        private readonly IMapper _mapper;
        private readonly IGetAnimalUseCase _getAnimalUseCase;
        private readonly ICreateAnimalUseCase _createAnimalUseCase;
        private readonly IUpdateAnimalUseCase _updateAnimalUseCase;
        private readonly IDeleteAnimalUseCase _deleteAnimalUseCase;

        public ZooController(ILogger<ZooController> logger, IMapper mapper, IGetAnimalUseCase getAnimalUseCase, ICreateAnimalUseCase createAnimalUseCase, IUpdateAnimalUseCase updateAnimalUseCase,
            IDeleteAnimalUseCase deleteAnimalUseCase)
        {
            _logger = logger;
            _mapper = mapper;
            _getAnimalUseCase = getAnimalUseCase;
            _createAnimalUseCase = createAnimalUseCase;
            _updateAnimalUseCase = updateAnimalUseCase;
            _deleteAnimalUseCase = deleteAnimalUseCase;
        }

        // GET: api/<ZooController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get([FromQuery] Parameter parameter)
        {
            try { 
            var resul = await _getAnimalUseCase.Execute(new GetAnimalInput(null,parameter.PageNumber, parameter.PageSize, parameter.Search));
            
            return Ok(resul);
                 }
            catch(Exception e)
            {
                _logger.LogError(e.StackTrace);
                return BadRequest("Error en el proceso");
            }

        }

        // GET api/<ZooController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<string>>> GetAsync(int id)
        {
            var resul = await _getAnimalUseCase.Execute(new GetAnimalInput(id,0,0,""));
            return Ok(resul);
        }

        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<AnimalViewModel> value)
        {
            var get = await _getAnimalUseCase.Execute(new GetAnimalInput(id, 0, 0, ""));
            var animal = (AnimalResul)get.Data;
            if (animal == null)
                return NotFound();
            var animalToPatch = _mapper.Map<AnimalViewModel>(animal);            
            value.ApplyTo(animalToPatch, ModelState);

            _mapper.Map(animalToPatch, animal);
            
            var resul = _updateAnimalUseCase.Execute(new UpdateAnimalInput(id, animal.Name, animal.Ege, animal.NumberLegs));
            return Ok(resul);            
        }

        // POST api/<ZooController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] AnimalResul value)
        {
            var resul = await _createAnimalUseCase.Execute(new CreateAnimalInput(value.Name, value.Ege, value.NumberLegs));
            return Ok(resul);
        }

        // PUT api/<ZooController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put (int id, [FromBody] AnimalResul value)
        {
            var resul = _updateAnimalUseCase.Execute(new UpdateAnimalInput(id,value.Name,value.Ege,value.NumberLegs )) ;
            return Ok(resul);
        }

        // DELETE api/<ZooController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            var resul = _deleteAnimalUseCase.Execute(new DeleteAnimalInput(id));
            return Ok(resul);
        }
    }
}
