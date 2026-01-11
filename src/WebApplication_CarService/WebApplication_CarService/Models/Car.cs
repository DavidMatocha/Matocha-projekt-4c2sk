namespace WebApplication_CarService.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }

}
