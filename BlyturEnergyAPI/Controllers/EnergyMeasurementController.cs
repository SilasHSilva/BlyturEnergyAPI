using BlyturEnergyAPI.Application.Services;
using BlyturEnergyAPI.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlyturEnergyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnergyMeasurementController : ControllerBase
    {
        private readonly EnergyMeasurementService _service;

        public EnergyMeasurementController(EnergyMeasurementService service)
        {
            _service = service;
        }

        [HttpGet("{turbineId}")]
        public async Task<IActionResult> GetByTurbineId(string turbineId) =>
            Ok(await _service.GetAllByTurbineIdAsync(turbineId));

        [HttpPost]
        public async Task<IActionResult> Create(EnergyMeasurement measurement)
        {
            await _service.AddAsync(measurement);
            return CreatedAtAction(nameof(GetByTurbineId), new { turbineId = measurement.TurbineId }, measurement);
        }
    }
}
