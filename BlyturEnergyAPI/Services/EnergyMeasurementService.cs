using BlyturEnergyAPI.Domain.Models;
using BlyturEnergyAPI.Infrastructure.Interfaces;

namespace BlyturEnergyAPI.Application.Services
{
    public class EnergyMeasurementService
    {
        private readonly IEnergyMeasurementRepository _repository;

        public EnergyMeasurementService(IEnergyMeasurementRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<EnergyMeasurement>> GetAllByTurbineIdAsync(string turbineId) =>
            _repository.GetAllByTurbineIdAsync(turbineId);

        public Task AddAsync(EnergyMeasurement measurement) =>
            _repository.AddAsync(measurement);
    }
}
