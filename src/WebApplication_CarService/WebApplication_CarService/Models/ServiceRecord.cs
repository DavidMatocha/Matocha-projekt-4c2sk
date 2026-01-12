using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication_CarService.Models
{
    public class ServiceRecord
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("Description")]
        public string Description { get; set; }
        [Column("ServiceDate")]
        public DateTime ServiceDate { get; set; }

        public int CarId { get; set; }
        public Car Car { get; set; }
    }

}
