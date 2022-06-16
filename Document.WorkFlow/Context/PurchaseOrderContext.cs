using System;
using Document.WorkFlow.Models;
using Microsoft.EntityFrameworkCore;

namespace Document.WorkFlow.Context
{
    public class PurchaseOrderContext : DbContext
    {

        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<PurchaseOrderLine> PurchaseOrderLines { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PurchaseOrder>().ToTable("PurchaseOrder").HasNoKey();
            modelBuilder.Entity<PurchaseOrderLine>().ToTable("PurchaseOrderLine").HasNoKey();
            modelBuilder.Entity<Supplier>().ToTable("Supplier").HasKey(p => p.SupplierID);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=Localhost;Initial Catalog=PURCHASES;User ID=SA;Password=Yn0#1k6v");
        }
    }
}

