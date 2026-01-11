namespace WebApplication_CarService.Models
{
    public class ServiceRecord
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime ServiceDate { get; set; }

        public int CarId { get; set; }
        public Car Car { get; set; }
    }

}
