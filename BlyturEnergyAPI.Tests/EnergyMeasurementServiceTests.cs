using BlyturEnergyAPI.Domain.Models;
using BlyturEnergyAPI.Infrastructure.Interfaces;
using BlyturEnergyAPI.Application.Services;
using Moq;

namespace BlyturEnergyAPI.Tests.Services
{
    public class EnergyMeasurementServiceTests
    {
        private readonly Mock<IEnergyMeasurementRepository> _mockRepository;
        private readonly EnergyMeasurementService _service;

        public EnergyMeasurementServiceTests()
        {
            _mockRepository = new Mock<IEnergyMeasurementRepository>();
            _service = new EnergyMeasurementService(_mockRepository.Object);
        }

        [Fact]
        public async Task GetAllByTurbineIdAsync_ShouldReturnMeasurements_WhenExist()
        {
            // Arrange
            var turbineId = "turbine123";
            var measurements = new List<EnergyMeasurement>
            {
                new() { Id = "1", TurbineId = turbineId, EnergyProduced = 100.5, MeasurementDate = DateTime.UtcNow },
                new() { Id = "2", TurbineId = turbineId, EnergyProduced = 200.0, MeasurementDate = DateTime.UtcNow.AddMinutes(-10)},
                new() { Id = "3", TurbineId = turbineId, EnergyProduced = 200.0, MeasurementDate = DateTime.UtcNow.AddMinutes(50)}
            };

            _mockRepository
                .Setup(repo => repo.GetAllByTurbineIdAsync(turbineId))
                .ReturnsAsync(measurements);

            // Act
            var result = await _service.GetAllByTurbineIdAsync(turbineId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(3, result.Count());
            Assert.All(result, m => Assert.Equal(turbineId, m.TurbineId));
        }

        [Fact]
        public async Task AddAsync_ShouldCallRepositoryAddAsync()
        {
            // Arrange
            var measurement = new EnergyMeasurement
            {
                Id = "1",
                TurbineId = "turbine123",
                EnergyProduced = 150.0,
                MeasurementDate = DateTime.UtcNow
            };

            _mockRepository
                .Setup(repo => repo.AddAsync(measurement))
                .Returns(Task.CompletedTask);

            // Act
            await _service.AddAsync(measurement);

            // Assert
            _mockRepository.Verify(repo => repo.AddAsync(measurement), Times.Once);
        }
    }
}
