using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QualityMonitoring.Models
{
    [Table("WaterQuality")]
    public class WaterQuality
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Timestamp { get; set; }
        [Required]
        public double PH { get; set; }
        [Required]
        public double Turbidity { get; set; }
        [Required]
        public double DissolvedOxygen { get; set; }
    }
}
