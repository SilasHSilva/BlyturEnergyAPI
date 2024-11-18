using BlyturEnergyAPI.Domain.Models;
using BlyturEnergyAPI.Infrastructure.Interfaces;
using MongoDB.Driver;

namespace BlyturEnergyAPI.Infrastructure.Repositories
{
    public class EnergyMeasurementRepository : IEnergyMeasurementRepository
    {
        private readonly IMongoCollection<EnergyMeasurement> _measurements;

        public EnergyMeasurementRepository(IMongoDatabase database)
        {
            _measurements = database.GetCollection<EnergyMeasurement>("EnergyMeasurements");
        }

        public async Task<IEnumerable<EnergyMeasurement>> GetAllByTurbineIdAsync(string turbineId) =>
            await _measurements.Find(m => m.TurbineId == turbineId).ToListAsync();

        public async Task AddAsync(EnergyMeasurement measurement) =>
            await _measurements.InsertOneAsync(measurement);
    }
}
