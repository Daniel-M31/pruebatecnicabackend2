using Cine_PruebaDanielMartinez.Models;

namespace Cine_PruebaDanielMartinez.Repository
{
    public interface IPeliculaSalaRepository
    {
        Task<List<pelicula_sala_cine>> GetAllAsync();
        Task<pelicula_sala_cine?> GetByIdAsync(int id);
        Task<pelicula_sala_cine> CreateAsync(pelicula_sala_cine entity);
        Task UpdateAsync(pelicula_sala_cine entity);
        Task DeleteAsync(int id);
    }
}
