using BlyturEnergyAPI.Domain.Models;

namespace BlyturEnergyAPI.Infrastructure.Interfaces
{
    public interface IEnergyMeasurementRepository
    {
        Task<IEnumerable<EnergyMeasurement>> GetAllByTurbineIdAsync(string turbineId);
        Task AddAsync(EnergyMeasurement measurement);
    }
}
    