using Cine_PruebaDanielMartinez.Contexts;
using Cine_PruebaDanielMartinez.Models;
using Cine_PruebaDanielMartinez.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cine_PruebaDanielMartinez.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class sala_cineController : ControllerBase
    {
        private readonly ISalaCineService _service;

        public sala_cineController(ISalaCineService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<sala_cine>>> Get()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<sala_cine>> Get(int id)
        {
            var sala = await _service.GetByIdAsync(id);
            if (sala == null) return NotFound();
            return Ok(sala);
        }

        [HttpPost]
        public async Task<ActionResult> Post(sala_cine sala)
        {
            await _service.AddAsync(sala);
            return CreatedAtAction(nameof(Get), new { id = sala.id_sala }, sala);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, sala_cine sala)
        {
            try
            {
                await _service.UpdateAsync(id, sala);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (System.ArgumentException)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _service.DeleteAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
