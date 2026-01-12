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

        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<ServiceRecord> ServiceRecords { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                "Server=mysqlstudenti.litv.sssvt.cz;Database=4c2_matocha_db2;User=matochadavid;Password=123456;",
                
                ServerVersion.AutoDetect(
                    "Server=mysqlstudenti.litv.sssvt.cz;Database=4c2_matocha_db2;User=matochadavid;Password=123456;"
                )
            );
        }


    }
}
