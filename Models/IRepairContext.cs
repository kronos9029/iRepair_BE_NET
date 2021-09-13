using Microsoft.EntityFrameworkCore;

namespace iRepair_BE_NET.Models
{
    public class IRepairContext : DbContext
    {
    public IRepairContext(DbContextOptions<IRepairContext> options): base(options)
        {
        }

        public DbSet<IRepairContext> TodoItems { get; set; }
    }
}