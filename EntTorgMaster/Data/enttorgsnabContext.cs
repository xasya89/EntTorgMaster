using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EntTorgMaster.Data
{
    public partial class enttorgsnabContext : DbContext
    {
        public DbSet<DoorType> DoorTypes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDoor> OrderDoors { get; set; }
        public DbSet<Good> Goods { get; set; }
        public DbSet<GoodBalance> GoodBalances { get; set; }
        public DbSet<DoorSpecificationWriteof> DoorSpecificationsWriteof { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Contractor> Contractors { get; set; }
        public DbSet<Arrival> Arrivals { get; set; }
        public DbSet<ArrivalGood> ArrivalGoods { get; set; }

        public DbSet<History> Histories { get; set; }
        public enttorgsnabContext()
        {
        }

        public enttorgsnabContext(DbContextOptions<enttorgsnabContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;database=enttorgsnab;uid=root;pwd=kt38hmapq", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.29-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8_unicode_ci")
                .HasCharSet("utf8mb3");

            modelBuilder.Entity<OrderDoor>()
                .HasOne(d => d.Order)
                .WithMany(o => o.OrderDoors)
                .HasForeignKey(d => d.OrderId);
            modelBuilder.Entity<OrderDoor>()
                .HasOne(d => d.DoorType)
                .WithMany(d => d.OrderDoors)
                .HasForeignKey(d => d.DoorTypeId);
            modelBuilder.Entity<DoorSpecificationWriteof>()
                .HasOne(s => s.OrderDoor)
                .WithMany(d => d.DoorSpecificationsWriteof)
                .HasForeignKey(s => s.OrderDoorId);
            modelBuilder.Entity<DoorSpecificationWriteof>()
                .HasOne(s => s.Good)
                .WithMany(s => s.DoorSpecificationsWriteof)
                .HasForeignKey(s => s.GoodId);

            modelBuilder.Entity<ArrivalGood>()
                .HasOne(a => a.Good)
                .WithMany(g => g.ArrivalGoods)
                .HasForeignKey(a => a.GoodId);
            modelBuilder.Entity<ArrivalGood>()
                .HasOne(a => a.Arrival)
                .WithMany(a => a.ArrivalGoods)
                .HasForeignKey(a => a.ArrivalId);
            modelBuilder.Entity<Arrival>()
                .HasOne(a => a.Contractor)
                .WithMany(c => c.Arrivals)
                .HasForeignKey(a => a.ContractorId);

            modelBuilder.Entity<History>()
                .HasOne(h => h.User)
                .WithMany(u => u.Histories)
                .HasForeignKey(h => h.UserId);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
