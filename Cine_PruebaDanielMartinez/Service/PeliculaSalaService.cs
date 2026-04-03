using Cine_PruebaDanielMartinez.DTOs;
using Cine_PruebaDanielMartinez.Models;
using Cine_PruebaDanielMartinez.Repository;
using System.Globalization;

namespace Cine_PruebaDanielMartinez.Service
{
    public class PeliculaSalaService : IPeliculaSalaService
    {
        private readonly IPeliculaSalaRepository _repo;

        public PeliculaSalaService(IPeliculaSalaRepository repo)
        {
            _repo = repo;
        }
        public async Task<List<PeliculaSalaDTO>> GetAllAsync()
        {
            var entities = await _repo.GetAllAsync();
            return entities.Select(e => new PeliculaSalaDTO
            {
                id_pelicula_sala = e.id_pelicula_sala,
                id_pelicula = e.id_pelicula,
                id_sala = e.id_sala,
                fecha_publicacion = e.fecha_publicacion.ToString("yyyy-MM-dd"),
                fecha_fin = e.fecha_fin.ToString("yyyy-MM-dd"),
                estado = e.estado
            }).ToList();
        }

        public async Task<PeliculaSalaDTO?> GetByIdAsync(int id)
        {
            var e = await _repo.GetByIdAsync(id);
            if (e == null) return null;
            return new PeliculaSalaDTO
            {
                id_pelicula_sala = e.id_pelicula_sala,
                id_pelicula = e.id_pelicula,
                id_sala = e.id_sala,
                fecha_publicacion = e.fecha_publicacion.ToString("yyyy-MM-dd"),
                fecha_fin = e.fecha_fin.ToString("yyyy-MM-dd"),
                estado = e.estado
            };
        }

        public async Task<PeliculaSalaDTO> CreateAsync(PeliculaSalaDTO dto)
        {
            if (!DateOnly.TryParseExact(dto.fecha_publicacion, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var fechaPub))
                throw new ArgumentException("Formato de fecha_publicacion inválido. Debe ser yyyy-MM-dd");

            if (!DateOnly.TryParseExact(dto.fecha_fin, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var fechaFin))
                throw new ArgumentException("Formato de fecha_fin inválido. Debe ser yyyy-MM-dd");

            var entity = new pelicula_sala_cine
            {
                id_pelicula = dto.id_pelicula,
                id_sala = dto.id_sala,
                fecha_publicacion = fechaPub,
                fecha_fin = fechaFin,
                estado = dto.estado
            };

            var created = await _repo.CreateAsync(entity);
            dto.id_pelicula_sala = created.id_pelicula_sala;
            return dto;
        }

        public async Task UpdateAsync(PeliculaSalaDTO dto)
        {
            if (!DateOnly.TryParseExact(dto.fecha_publicacion, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var fechaPub))
                throw new ArgumentException("Formato de fecha_publicacion inválido. Debe ser yyyy-MM-dd");

            if (!DateOnly.TryParseExact(dto.fecha_fin, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var fechaFin))
                throw new ArgumentException("Formato de fecha_fin inválido. Debe ser yyyy-MM-dd");

            var entity = new pelicula_sala_cine
            {
                id_pelicula_sala = dto.id_pelicula_sala,
                id_pelicula = dto.id_pelicula,
                id_sala = dto.id_sala,
                fecha_publicacion = fechaPub,
                fecha_fin = fechaFin,
                estado = dto.estado
            };

            await _repo.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repo.DeleteAsync(id);
        }
    }
}