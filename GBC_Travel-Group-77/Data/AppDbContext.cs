using Microsoft.Build.Evaluation;
using Microsoft.EntityFrameworkCore;
using GBC_Travel_Group_77.Models;

namespace GBC_Travel_Group_77.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Flight> Flights { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
