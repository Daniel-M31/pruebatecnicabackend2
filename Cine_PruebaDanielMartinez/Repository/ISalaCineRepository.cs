using Cine_PruebaDanielMartinez.Models;

namespace Cine_PruebaDanielMartinez.Repository
{
    public interface ISalaCineRepository
    {
        Task<IEnumerable<sala_cine>> GetAllAsync();
        Task<sala_cine?> GetByIdAsync(int id);
        Task AddAsync(sala_cine sala);
        Task UpdateAsync(sala_cine sala);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
