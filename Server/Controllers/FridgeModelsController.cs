﻿using AutoMapper;
using Contracts;
using Entities.DTO.FridgeModel;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using NLog;
using System;
using System.Collections.Generic;
namespace Server.Controllers
{
    [Route("api/fridgemodels")]
    [ApiController]
    public class FridgeModelsController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        public FridgeModelsController(ILoggerManager logger, IRepositoryManager repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetFridgeModels()
        {
            var fridgeModels = _repository.FridgeModel.GetAllFridgeModels(trackChanges: false);
            var fridgeModelsDTO = _mapper.Map<IEnumerable<FridgeModelDTO>>(fridgeModels);
            return Ok(fridgeModelsDTO);
        }
        [HttpGet("{id}", Name = "GetFridgeModelById")]
        public IActionResult GetFridgeModel(Guid id)
        {
            var fridgeModel = _repository.FridgeModel.GetFridgeModel(id, trackChanges: false);
            if (fridgeModel == null)
            {
                _logger.LogInfo($"FridgeModel with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                var fridgeModelDTO = _mapper.Map<FridgeModelDTO>(fridgeModel);
                return Ok(fridgeModelDTO);
            }
        }

        [HttpPost]
        public IActionResult CreateFridgeModel([FromBody] FridgeModelForCreationDTO fridgeModel)
        {
            if (fridgeModel == null)
            {
                _logger.LogError("FridgeModelForCreationDto object sent from client is null.");
                return BadRequest("FridgeModelForCreationDto object is null");
            }
            var fridgeModelEntity = _mapper.Map<FridgeModel>(fridgeModel);

            _repository.FridgeModel.CreateFridgeModel(fridgeModelEntity);
            _repository.Save();

            var fridgeModelToReturn = _mapper.Map<FridgeModelDTO>(fridgeModelEntity);

            return CreatedAtRoute("GetFridgeModelById", new { id = fridgeModelToReturn.Id },
                                  fridgeModelToReturn);
        }
    }
}
