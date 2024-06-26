﻿using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using Sieve.Services;
using Tabi.Helpers;
using Tabi.Model;
using Tabi.Services;

namespace Tabi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class HarvestController(ISieveProcessor sieveProcessor, IHarvestService harvestService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetHarvests([FromQuery] SieveModel sieveModel)
        {
            IEnumerable<Harvest> harvests = await harvestService.GetHarvests();
            return Ok(sieveProcessor.Apply(sieveModel, harvests.AsQueryable()));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetHarvest(int id)
        {
            Harvest? harvest = await harvestService.GetHarvest(id);
            if (harvest == null) return NotFound();
            return Ok(harvest);
        }

        [HttpPost]
        public async Task<IActionResult> CreateHarvest(
            [FromForm][Required] int CropID,
            [FromForm][Required] int HarvestStateID,
            [FromForm][Required] DateOnly Date,
            [FromForm][Required] float Amount)
        {
            Harvest harvest = await harvestService.CreateHarvest(CropID, HarvestStateID, Date, Amount);
            return CreatedAtAction(nameof(GetHarvest), new { id = harvest.HarvestID }, harvest);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateHarvest(
            [FromForm][Required] int HarvestID,
            [FromForm] int? CropID,
            [FromForm] int? HarvestStateID,
            [FromForm] DateOnly? Date,
            [FromForm] float? Amount)
        {
            Harvest? harvest = await harvestService.GetHarvest(HarvestID);
            if (harvest == null) return NotFound();
            harvest = await harvestService.UpdateHarvest(HarvestID, CropID, HarvestStateID, Date, Amount);
            return Ok(harvest);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteHarvest(int id)
        {
            Harvest? harvest = await harvestService.GetHarvest(id);
            if (harvest == null) return NotFound();
            await harvestService.DeleteHarvest(id);
            return NoContent();
        }
    }
}
