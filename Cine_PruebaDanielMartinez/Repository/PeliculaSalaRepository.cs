using Cine_PruebaDanielMartinez.Contexts;
using Cine_PruebaDanielMartinez.Models;
using Microsoft.EntityFrameworkCore;

namespace Cine_PruebaDanielMartinez.Repository
{
    public class PeliculaSalaRepository : IPeliculaSalaRepository
    {
        private readonly MoviesContext _context;

        public PeliculaSalaRepository(MoviesContext context)
        {
            _context = context;
        }

        public async Task<List<pelicula_sala_cine>> GetAllAsync() => await _context.pelicula_sala_cines.ToListAsync();

        public async Task<pelicula_sala_cine?> GetByIdAsync(int id) => await _context.pelicula_sala_cines.FindAsync(id);

        public async Task<pelicula_sala_cine> CreateAsync(pelicula_sala_cine entity)
        {
            _context.pelicula_sala_cines.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(pelicula_sala_cine entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.pelicula_sala_cines.FindAsync(id);
            if (entity != null)
            {
                _context.pelicula_sala_cines.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}