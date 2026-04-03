using Cine_PruebaDanielMartinez.Contexts;
using Cine_PruebaDanielMartinez.Models;
using Microsoft.EntityFrameworkCore;

namespace Cine_PruebaDanielMartinez.Repository
{
    public class PeliculaRepository : IPeliculaRepository
    {
        private readonly MoviesContext _context;

        public PeliculaRepository(MoviesContext context)
        {
            _context = context;
        }

        public async Task<List<pelicula>> GetAllAsync() => await _context.peliculas.ToListAsync();

        public async Task<pelicula?> GetByIdAsync(int id) => await _context.peliculas.FindAsync(id);

        public async Task<List<pelicula>> BuscarPorNombreAsync(string nombre) =>
            await _context.peliculas
                          .Where(p => p.nombre.Contains(nombre))
                          .ToListAsync();

        public async Task AddAsync(pelicula pelicula)
        {
            _context.peliculas.Add(pelicula);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(pelicula pelicula)
        {
            _context.Entry(pelicula).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(pelicula pelicula)
        {
            pelicula.estado = false;
            await _context.SaveChangesAsync();
        }

        public bool Exists(int id) => _context.peliculas.Any(p => p.id_pelicula == id);
    }
}
