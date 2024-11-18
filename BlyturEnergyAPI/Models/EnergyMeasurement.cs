namespace BlyturEnergyAPI.Domain.Models
{
    public class EnergyMeasurement
    {
        public required string Id { get; set; }
        public required string TurbineId { get; set; }
        public DateTime MeasurementDate { get; set; }
        public double EnergyProduced { get; set; }
    }
}
