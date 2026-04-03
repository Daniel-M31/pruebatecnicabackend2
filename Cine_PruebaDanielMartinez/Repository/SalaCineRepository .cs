using Cine_PruebaDanielMartinez.Contexts;
using Cine_PruebaDanielMartinez.Models;
using Microsoft.EntityFrameworkCore;

namespace Cine_PruebaDanielMartinez.Repository
{
    public class SalaCineRepository : ISalaCineRepository
    {
        private readonly MoviesContext _context;

        public SalaCineRepository(MoviesContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<sala_cine>> GetAllAsync()
        {
            return await _context.sala_cines.ToListAsync();
        }

        public async Task<sala_cine?> GetByIdAsync(int id)
        {
            return await _context.sala_cines.FindAsync(id);
        }

        public async Task AddAsync(sala_cine sala)
        {
            _context.sala_cines.Add(sala);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(sala_cine sala)
        {
            _context.Entry(sala).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var sala = await _context.sala_cines.FindAsync(id);
            if (sala != null)
            {
                _context.sala_cines.Remove(sala);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.sala_cines.AnyAsync(e => e.id_sala == id);
        }
    }
}