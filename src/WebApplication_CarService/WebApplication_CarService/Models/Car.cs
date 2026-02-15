using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication_CarService.Models;

[Table("cars")]
public class Car
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("user_id")]
    public int UserId { get; set; }
    public User? User { get; set; }

    [Required, StringLength(100)]
    [Column("brand")]
    public string Brand { get; set; } = string.Empty;

    [Required, StringLength(100)]
    [Column("model")]
    public string Model { get; set; } = string.Empty;

    [StringLength(20)]
    [Column("license_plate")]
    public string? LicensePlate { get; set; }

    [Column("year")]
    public int? Year { get; set; }

    [Column("current_mileage")]
    public int? CurrentMileage { get; set; }
}
