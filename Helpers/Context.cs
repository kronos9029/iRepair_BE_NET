using iRepair_BE_NET.Models.Constants;
using iRepair_BE_NET.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace iRepair_BE_NET.Helpers
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options){}
        public DbSet<Account> Account{get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            optionsBuilder.UseSqlServer();
        }
        

    }
}