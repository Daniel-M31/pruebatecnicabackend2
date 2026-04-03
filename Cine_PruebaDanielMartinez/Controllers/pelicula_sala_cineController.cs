using Cine_PruebaDanielMartinez.Contexts;
using Cine_PruebaDanielMartinez.DTOs;
using Cine_PruebaDanielMartinez.Models;
using Cine_PruebaDanielMartinez.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cine_PruebaDanielMartinez.Controllers
{
    [Route("api/pelicula_sala_cine")]
    [ApiController]
    public class PeliculaSalaController : ControllerBase
    {
        private readonly IPeliculaSalaService _service;

        public PeliculaSalaController(IPeliculaSalaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<PeliculaSalaDTO>>> Get() => await _service.GetAllAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<PeliculaSalaDTO>> Get(int id)
        {
            var dto = await _service.GetByIdAsync(id);
            if (dto == null) return NotFound();
            return dto;
        }

        [HttpPost]
        public async Task<ActionResult<PeliculaSalaDTO>> Post(PeliculaSalaDTO dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = created.id_pelicula_sala }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, PeliculaSalaDTO dto)
        {
            if (id != dto.id_pelicula_sala) return BadRequest();
            await _service.UpdateAsync(dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}