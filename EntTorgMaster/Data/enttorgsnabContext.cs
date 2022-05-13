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

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
