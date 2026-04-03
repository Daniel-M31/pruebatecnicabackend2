using Cine_PruebaDanielMartinez.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cine_PruebaDanielMartinez.Repository
{
    public interface IPeliculaRepository
    {
        Task<List<pelicula>> GetAllAsync();
        Task<pelicula?> GetByIdAsync(int id);
        Task<List<pelicula>> BuscarPorNombreAsync(string nombre);
        Task AddAsync(pelicula pelicula);
        Task UpdateAsync(pelicula pelicula);
        Task DeleteAsync(pelicula pelicula);
        bool Exists(int id);
    }
}