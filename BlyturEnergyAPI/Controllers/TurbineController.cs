using BlyturEnergyAPI.Application.Services;
using BlyturEnergyAPI.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlyturEnergyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurbineController : ControllerBase
    {
        private readonly TurbineService _service;

        public TurbineController(TurbineService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var turbine = await _service.GetByIdAsync(id);
            return turbine != null ? Ok(turbine) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Turbine turbine)
        {
            await _service.AddAsync(turbine);
            return CreatedAtAction(nameof(GetById), new { id = turbine.Id }, turbine);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Turbine turbine)
        {
            await _service.UpdateAsync(id, turbine);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
