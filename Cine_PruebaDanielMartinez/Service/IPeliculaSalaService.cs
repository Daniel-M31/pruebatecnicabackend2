using Cine_PruebaDanielMartinez.DTOs;
namespace Cine_PruebaDanielMartinez.Service
{
    public interface IPeliculaSalaService
    {
        Task<List<PeliculaSalaDTO>> GetAllAsync();
        Task<PeliculaSalaDTO?> GetByIdAsync(int id);
        Task<PeliculaSalaDTO> CreateAsync(PeliculaSalaDTO dto);
        Task UpdateAsync(PeliculaSalaDTO dto);
        Task DeleteAsync(int id);
    }
}
