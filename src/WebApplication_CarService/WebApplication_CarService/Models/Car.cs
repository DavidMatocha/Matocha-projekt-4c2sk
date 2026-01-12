using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication_CarService.Models
{
    [Table("Car")]
    public class Car
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("Brand")]
        public string Brand { get; set; }
        [Column("Model")]
        public string Model { get; set; }
        [ForeignKey("Id")]
        public int UserId { get; set; }
        [Column("User")]
        public User User { get; set; }
    }

}
