using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QualityMonitoring.Models
{

    [Table("AirQuality")]
    public class AirQuality
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime Timestamp { get; set; }
        [Required]
        public double PM25 { get; set; }
        [Required]
        public double PM10 { get; set; }
        [Required]
        public double CO2 { get; set; }
    }
}

