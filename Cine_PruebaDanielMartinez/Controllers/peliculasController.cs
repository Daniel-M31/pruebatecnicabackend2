using Cine_PruebaDanielMartinez.DTOs;
using Cine_PruebaDanielMartinez.Service;
using Microsoft.AspNetCore.Mvc;

namespace Cine_PruebaDanielMartinez.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculasController : ControllerBase
    {
        private readonly IPeliculaService _service;

        public PeliculasController(IPeliculaService service)
        {
            _service = service;
        }

        // GET: api/peliculas
        [HttpGet]
        public async Task<ActionResult<List<PeliculaDTO>>> Get()
        {
            var peliculas = await _service.GetAllPeliculasAsync();
            return Ok(peliculas);
        }

        // GET: api/peliculas/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<PeliculaDTO>> Get(int id)
        {
            var pelicula = await _service.GetPeliculaByIdAsync(id);
            if (pelicula == null)
                return NotFound(new { mensaje = "Película no encontrada" });
            return Ok(pelicula);
        }

        // GET: api/peliculas/buscar?nombre=xxx
        [HttpGet("buscar")]
        public async Task<ActionResult<List<PeliculaDTO>>> Buscar(string nombre)
        {
            if (string.IsNullOrEmpty(nombre))
                return BadRequest(new { mensaje = "Ingrese un nombre de película a buscar" });

            var peliculas = await _service.BuscarPorNombreAsync(nombre);
            if (!peliculas.Any())
                return NotFound(new { mensaje = "No se encontraron películas con ese nombre" });

            return Ok(peliculas);
        }

        // POST: api/peliculas
        [HttpPost]
        public async Task<ActionResult> Post(PeliculaDTO dto)
        {
            // Validación de datos
            if (dto == null)
                return BadRequest(new { mensaje = "Datos de película inválidos" });

            // Llamada al servicio para agregar la película
            // Ahora AddPeliculaAsync retorna un PeliculaDTO con el id generado por la base de datos
            var nuevaPelicula = await _service.AddPeliculaAsync(dto);

            // Devuelve JSON con mensaje y la película completa
            return Ok(new { mensaje = "Película agregada correctamente", pelicula = nuevaPelicula });
        }

        // PUT: api/peliculas/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, PeliculaDTO dto)
        {
            if (id != dto.id_pelicula)
                return BadRequest(new { mensaje = "Id no coincide" });

            try
            {
                await _service.UpdatePeliculaAsync(dto);
                return Ok(new { mensaje = "Película actualizada correctamente" });
            }
            catch (Exception ex)
            {
                return NotFound(new { mensaje = ex.Message });
            }
        }

        // DELETE: api/peliculas/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _service.DeletePeliculaAsync(id);
            return Ok(new { mensaje = "Película eliminada correctamente" });
        }
    }
}