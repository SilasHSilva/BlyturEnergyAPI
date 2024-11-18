using BlyturEnergyAPI.Domain.Models;
using BlyturEnergyAPI.Infrastructure.Interfaces;
using MongoDB.Driver;

namespace BlyturEnergyAPI.Infrastructure.Repositories
{
    public class TurbineRepository : ITurbineRepository
    {
        private readonly IMongoCollection<Turbine> _turbines;

        public TurbineRepository(IMongoDatabase database)
        {
            _turbines = database.GetCollection<Turbine>("Turbines");
        }

        public async Task<IEnumerable<Turbine>> GetAllAsync() => 
            await _turbines.Find(_ => true).ToListAsync();

        public async Task<Turbine> GetByIdAsync(string id) => 
            await _turbines.Find(t => t.Id == id).FirstOrDefaultAsync();

        public async Task AddAsync(Turbine turbine) => 
            await _turbines.InsertOneAsync(turbine);

        public async Task UpdateAsync(string id, Turbine turbine) =>
            await _turbines.ReplaceOneAsync(t => t.Id == id, turbine);

        public async Task DeleteAsync(string id) =>
            await _turbines.DeleteOneAsync(t => t.Id == id);
    }
}
