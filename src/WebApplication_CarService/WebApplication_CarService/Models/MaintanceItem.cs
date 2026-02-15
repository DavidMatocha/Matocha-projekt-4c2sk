using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication_CarService.Models;

[Table("maintenance_items")]
public class MaintenanceItem
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("car_id")]
    public int CarId { get; set; }
    public Car? Car { get; set; }

    [Required, StringLength(150)]
    [Column("name")]
    public string Name { get; set; } = string.Empty;

    [Column("interval_km")]
    public int? IntervalKm { get; set; }

    [Column("interval_months")]
    public int? IntervalMonths { get; set; }

    [Column("last_date")]
    public DateTime? LastDate { get; set; }

    [Column("last_mileage")]
    public int? LastMileage { get; set; }
}
