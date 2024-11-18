using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlyturEnergyAPI.Domain.Models;
using BlyturEnergyAPI.Infrastructure.Interfaces;
using BlyturEnergyAPI.Application.Services;
using Moq;
using Xunit;

namespace BlyturEnergyAPI.Tests.Services
{
    public class TurbineServiceTests
    {
        private readonly Mock<ITurbineRepository> _mockRepository;
        private readonly TurbineService _service;

        public TurbineServiceTests()
        {
            _mockRepository = new Mock<ITurbineRepository>();
            _service = new TurbineService(_mockRepository.Object);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnListOfTurbines()
        {
            // Arrange
            var turbines = new List<Turbine>
            {
                new Turbine { Id = "1", Name = "Turbine A", Capacity = 3.5 },
                new Turbine { Id = "2", Name = "Turbine B", Capacity = 2.0 }
            };

            _mockRepository
                .Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(turbines);

            // Act
            var result = await _service.GetAllAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            Assert.Equal("Turbine A", result.First().Name);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnTurbine_WhenExists()
        {
            // Arrange
            var turbine = new Turbine { Id = "1", Name = "Turbine A", Capacity = 3.5 };

            _mockRepository
                .Setup(repo => repo.GetByIdAsync("1"))
                .ReturnsAsync(turbine);

            // Act
            var result = await _service.GetByIdAsync("1");

            // Assert
            Assert.NotNull(result);
            Assert.Equal("1", result.Id);
            Assert.Equal("Turbine A", result.Name);
        }

        [Fact]
        public async Task AddAsync_ShouldCallRepositoryAddAsync()
        {
            // Arrange
            var newTurbine = new Turbine { Id = "3", Name = "Turbine C", Capacity = 4.0 };

            _mockRepository
                .Setup(repo => repo.AddAsync(newTurbine))
                .Returns(Task.CompletedTask);

            // Act
            await _service.AddAsync(newTurbine);

            // Assert
            _mockRepository.Verify(repo => repo.AddAsync(newTurbine), Times.Once);
        }

        [Fact]
        public async Task UpdateAsync_ShouldCallRepositoryUpdateAsync()
        {
            // Arrange
            var updatedTurbine = new Turbine { Id = "1", Name = "Updated Turbine", Capacity = 5.0 };

            _mockRepository
                .Setup(repo => repo.UpdateAsync("1", updatedTurbine))
                .Returns(Task.CompletedTask);

            // Act
            await _service.UpdateAsync("1", updatedTurbine);

            // Assert
            _mockRepository.Verify(repo => repo.UpdateAsync("1", updatedTurbine), Times.Once);
        }

        [Fact]
        public async Task DeleteAsync_ShouldCallRepositoryDeleteAsync()
        {
            // Arrange
            _mockRepository
                .Setup(repo => repo.DeleteAsync("1"))
                .Returns(Task.CompletedTask);

            // Act
            await _service.DeleteAsync("1");

            // Assert
            _mockRepository.Verify(repo => repo.DeleteAsync("1"), Times.Once);
        }
    }
}
