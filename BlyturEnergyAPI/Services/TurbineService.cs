using BlyturEnergyAPI.Domain.Models;
using BlyturEnergyAPI.Infrastructure.Interfaces;

namespace BlyturEnergyAPI.Application.Services
{
    public class TurbineService
    {
        private readonly ITurbineRepository _repository;

        public TurbineService(ITurbineRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<Turbine>> GetAllAsync() => _repository.GetAllAsync();

        public Task<Turbine> GetByIdAsync(string id) => _repository.GetByIdAsync(id);

        public Task AddAsync(Turbine turbine) => _repository.AddAsync(turbine);

        public Task UpdateAsync(string id, Turbine turbine) => _repository.UpdateAsync(id, turbine);

        public Task DeleteAsync(string id) => _repository.DeleteAsync(id);
    }
}
