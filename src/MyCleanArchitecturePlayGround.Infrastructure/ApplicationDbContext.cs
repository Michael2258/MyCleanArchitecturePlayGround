using Microsoft.EntityFrameworkCore;
using MyCleanArchitecturePlayGround.Infrastructure.Orders;
using MyCleanArchitecturePlayGround.Infrastructure.Shipments;

namespace MyCleanArchitecturePlayGround.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<OrderRecord> Orders { get; set; }
        public DbSet<ShipmentRecord> Shipments { get; set; }
        public DbSet<StopRecord> Stops { get; set; }
    }
}