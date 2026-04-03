using Cine_PruebaDanielMartinez.Models;

namespace Cine_PruebaDanielMartinez.Service
{
    public interface ISalaCineService
    {
        Task<IEnumerable<sala_cine>> GetAllAsync();
        Task<sala_cine?> GetByIdAsync(int id);
        Task AddAsync(sala_cine sala);
        Task UpdateAsync(int id, sala_cine sala);
        Task DeleteAsync(int id);
    }
}
