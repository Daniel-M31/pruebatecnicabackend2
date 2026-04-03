using Cine_PruebaDanielMartinez.DTOs;

namespace Cine_PruebaDanielMartinez.Service
{
    public interface IPeliculaService
    {
        Task<List<PeliculaDTO>> GetAllPeliculasAsync();
        Task<PeliculaDTO?> GetPeliculaByIdAsync(int id);
        Task<List<PeliculaDTO>> BuscarPorNombreAsync(string nombre);

        Task<PeliculaDTO> AddPeliculaAsync(PeliculaDTO dto);

        Task UpdatePeliculaAsync(PeliculaDTO dto);
        Task DeletePeliculaAsync(int id);
    }
}
