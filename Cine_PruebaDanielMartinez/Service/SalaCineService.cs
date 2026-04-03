using Cine_PruebaDanielMartinez.Models;
using Cine_PruebaDanielMartinez.Repository;

namespace Cine_PruebaDanielMartinez.Service
{
    public class SalaCineService : ISalaCineService
    {
        private readonly ISalaCineRepository _repository;

        public SalaCineService(ISalaCineRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<sala_cine>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<sala_cine?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(sala_cine sala)
        {
            await _repository.AddAsync(sala);
        }

        public async Task UpdateAsync(int id, sala_cine sala)
        {
            if (id != sala.id_sala)
                throw new System.ArgumentException("ID mismatch");

            if (!await _repository.ExistsAsync(id))
                throw new KeyNotFoundException("Sala no encontrada");

            await _repository.UpdateAsync(sala);
        }

        public async Task DeleteAsync(int id)
        {
            if (!await _repository.ExistsAsync(id))
                throw new KeyNotFoundException("Sala no encontrada");

            await _repository.DeleteAsync(id);
        }
    }
}