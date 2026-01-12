using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication_CarService.Models
{
    public class User
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("Email")]
        public string Email { get; set; }
        [Column("Password")]
        public string Password { get; set; }
    }

}
