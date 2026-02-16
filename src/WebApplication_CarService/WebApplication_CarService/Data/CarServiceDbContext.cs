using Microsoft.EntityFrameworkCore;
using WebApplication_CarService.Models;

namespace WebApplication_CarService.Data
{
    public class CarServiceDbContext : DbContext
    {
        public CarServiceDbContext(DbContextOptions<CarServiceDbContext> options)
            : base(options)
        {

        }
        public DbSet<MaintenanceItem> MaintenanceItems { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<ServiceRecord> ServiceRecords { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var cs = "Server=mysqlstudenti.litv.sssvt.cz;Database=4c2_matochadavid_db2;User=matochadavid;Password=123456;";

            optionsBuilder.UseMySql(
                cs,
                ServerVersion.AutoDetect(cs)
            );
        }



    }
}
