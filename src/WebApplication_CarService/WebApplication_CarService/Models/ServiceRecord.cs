using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication_CarService.Models;

[Table("service_records")]
public class ServiceRecord
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("car_id")]
    public int CarId { get; set; }
    public Car? Car { get; set; }

    [Column("date")]
    public DateTime Date { get; set; }

    [Required]
    [Column("mileage")]
    public int Mileage { get; set; }

    [Required, StringLength(150)]
    [Column("title")]
    public string Title { get; set; } = string.Empty;

    [Column("description")]
    public string? Description { get; set; }

    [Column("cost")]
    public decimal? Cost { get; set; }
}
