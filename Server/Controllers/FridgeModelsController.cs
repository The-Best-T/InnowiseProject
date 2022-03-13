﻿using AutoMapper;
using Contracts;
using Entities.DTO.FridgeModel;
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
        public IActionResult Get()
        {
            try
            {
                var fridgemodels = _repository.FridgeModel.GetAllFridgeModels(trackChanges: false);
                var fridgeModelsDTO = _mapper.Map<IEnumerable<FridgeModelDTO>>(fridgemodels);
                return Ok(fridgemodels);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(Get)}action {ex}");
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var fridgeModel = _repository.FridgeModel.GetFridgeModel(id, trackChanges: false);
            if (fridgeModel == null)
            {
                _logger.LogInfo($"Company with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                var fridgeModelDTO = _mapper.Map<FridgeModelDTO>(fridgeModel);
                return Ok(fridgeModelDTO);
            }
        }
    }
}