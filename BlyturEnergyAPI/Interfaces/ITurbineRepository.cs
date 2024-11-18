using BlyturEnergyAPI.Domain.Models;

namespace BlyturEnergyAPI.Infrastructure.Interfaces
{
    public interface ITurbineRepository
    {
        Task<IEnumerable<Turbine>> GetAllAsync();
        Task<Turbine> GetByIdAsync(string id);
        Task AddAsync(Turbine turbine);
        Task UpdateAsync(string id, Turbine turbine);
        Task DeleteAsync(string id);
    }
}
