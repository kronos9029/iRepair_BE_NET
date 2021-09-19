using System;
using iRepair_BE_NET.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace iRepair_BE_NET.Helpers
{
    public partial class iRepair_DEVContext : DbContext
    {
        public iRepair_DEVContext()
        {
        }

        public iRepair_DEVContext(DbContextOptions<iRepair_DEVContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<FavoriteBy> FavoriteBies { get; set; }
        public virtual DbSet<LinkedAccount> LinkedAccounts { get; set; }
        public virtual DbSet<Major> Majors { get; set; }
        public virtual DbSet<MajorField> MajorFields { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderEvidence> OrderEvidences { get; set; }
        public virtual DbSet<OrderHistory> OrderHistories { get; set; }
        public virtual DbSet<RepairMan> RepairMen { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<SpecializeIn> SpecializeIns { get; set; }
        public virtual DbSet<WorkOn> WorkOns { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=iRepair_DEV;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.Property(e => e.AccountId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IsDefault).IsFixedLength(true);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Address_Customer");
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IsOnline).IsFixedLength(true);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<FavoriteBy>(entity =>
            {
                entity.HasOne(d => d.Customer)
                    .WithMany()
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_FavoriteBy_Customer");

                entity.HasOne(d => d.Repairman)
                    .WithMany()
                    .HasForeignKey(d => d.RepairmanId)
                    .HasConstraintName("FK_FavoriteBy_RepairMan");
            });

            modelBuilder.Entity<LinkedAccount>(entity =>
            {
                entity.HasOne(d => d.Customer)
                    .WithMany()
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LinkedAccount_Customer");
            });

            modelBuilder.Entity<Major>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Picture).IsFixedLength(true);
            });

            modelBuilder.Entity<MajorField>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description).IsFixedLength(true);

                entity.HasOne(d => d.Major)
                    .WithMany(p => p.MajorFields)
                    .HasForeignKey(d => d.MajorId)
                    .HasConstraintName("FK_MajorField_Major");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Customer");

                entity.HasOne(d => d.Repairman)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.RepairmanId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_RepairMan");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Service");
            });

            modelBuilder.Entity<OrderEvidence>(entity =>
            {
                entity.HasOne(d => d.Order)
                    .WithMany()
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_OrderEvidence_Order");
            });

            modelBuilder.Entity<OrderHistory>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderHistories)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderHistory_Order");
            });

            modelBuilder.Entity<RepairMan>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.RepairMen)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK_RepairMan_Company");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Services)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Service_Company");

                entity.HasOne(d => d.Field)
                    .WithMany(p => p.Services)
                    .HasForeignKey(d => d.FieldId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Service_MajorField");
            });

            modelBuilder.Entity<SpecializeIn>(entity =>
            {
                entity.HasOne(d => d.Company)
                    .WithMany()
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK_SpecializeIn_Company");

                entity.HasOne(d => d.Major)
                    .WithMany()
                    .HasForeignKey(d => d.MajorId)
                    .HasConstraintName("FK_SpecializeIn_Major");
            });

            modelBuilder.Entity<WorkOn>(entity =>
            {
                entity.HasKey(e => new { e.RepairmanId, e.ServiceId });

                entity.HasOne(d => d.Repairman)
                    .WithMany(p => p.WorkOns)
                    .HasForeignKey(d => d.RepairmanId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WorkOn_RepairMan");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.WorkOns)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WorkOn_Service");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
