using Cine_PruebaDanielMartinez.DTOs;
using Cine_PruebaDanielMartinez.Models;
using Cine_PruebaDanielMartinez.Repository;


namespace Cine_PruebaDanielMartinez.Service
{
    public class PeliculaService : IPeliculaService
    {
        private readonly IPeliculaRepository _repo;

        public PeliculaService(IPeliculaRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<PeliculaDTO>> GetAllPeliculasAsync()
        {
            var peliculas = await _repo.GetAllAsync();
            return peliculas.Select(p => new PeliculaDTO
            {
                id_pelicula = p.id_pelicula,
                Nombre = p.nombre,
                Duracion = p.duracion,
                Estado = p.estado
            }).ToList();
        }

        public async Task<PeliculaDTO?> GetPeliculaByIdAsync(int id)
        {
            var p = await _repo.GetByIdAsync(id);
            if (p == null) return null;
            return new PeliculaDTO
            {
                id_pelicula = p.id_pelicula,
                Nombre = p.nombre,
                Duracion = p.duracion,
                Estado = p.estado
            };
        }

        public async Task<List<PeliculaDTO>> BuscarPorNombreAsync(string nombre)
        {
            var peliculas = await _repo.BuscarPorNombreAsync(nombre);
            return peliculas.Select(p => new PeliculaDTO
            {
                id_pelicula = p.id_pelicula,
                Nombre = p.nombre,
                Duracion = p.duracion,
                Estado = p.estado
            }).ToList();
        }

        public async Task<PeliculaDTO> AddPeliculaAsync(PeliculaDTO dto)
        {
            var pelicula = new pelicula
            {
                nombre = dto.Nombre,
                duracion = dto.Duracion,
                estado = dto.Estado
            };

            await _repo.AddAsync(pelicula);

            return new PeliculaDTO
            {
                id_pelicula = pelicula.id_pelicula,
                Nombre = pelicula.nombre,
                Duracion = pelicula.duracion,
                Estado = pelicula.estado
            };
        }

        public async Task UpdatePeliculaAsync(PeliculaDTO dto)
        {
            var pelicula = await _repo.GetByIdAsync(dto.id_pelicula);
            if (pelicula == null) throw new Exception("No encontrada");

            pelicula.nombre = dto.Nombre;
            pelicula.duracion = dto.Duracion;
            pelicula.estado = dto.Estado;

            await _repo.UpdateAsync(pelicula);
        }

        public async Task DeletePeliculaAsync(int id)
        {
            var pelicula = await _repo.GetByIdAsync(id);
            if (pelicula != null)
                await _repo.DeleteAsync(pelicula);
        }
    }
}