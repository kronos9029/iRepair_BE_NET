using iRepair_BE_NET.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace iRepair_BE_NET.Helpers
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options){}
        DbSet<Admin> admins{get; set;}

    }
}