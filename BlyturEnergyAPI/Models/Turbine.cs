namespace BlyturEnergyAPI.Domain.Models
{
    public class Turbine
    {
        public required string Id { get; set; } 
        public required string Name { get; set; }
        public double Capacity { get; set; } // Capacidade em kW
        public string Location { get; set; }
        public DateTime InstallationDate { get; set; }
    }
}
