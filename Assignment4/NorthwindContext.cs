using Assignment4.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    public class NorthwindContext : DbContext
    {
        // change these variables depending on your local machine
        private string uid = "postgres";
        private string password = "pass123";
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Order> Orders { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            //optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
            //optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.UseNpgsql($"host=localhost;db=northwind;uid={uid};pwd={password}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // category mapping
            modelBuilder.Entity<Category>().ToTable("categories");
            modelBuilder.Entity<Category>().Property(x => x.Id).HasColumnName("categoryid");
            modelBuilder.Entity<Category>().Property(x => x.Name).HasColumnName("categoryname");
            modelBuilder.Entity<Category>().Property(x => x.Description).HasColumnName("description");

            // product mapping
            modelBuilder.Entity<Product>().ToTable("products");
            modelBuilder.Entity<Product>().Property(x => x.Id).HasColumnName("productid");
            modelBuilder.Entity<Product>().Property(x => x.Name).HasColumnName("productname");
            modelBuilder.Entity<Product>().Property(x => x.CategoryId).HasColumnName("categoryid");
            modelBuilder.Entity<Product>().Property(x => x.QuantityPerUnit).HasColumnName("quantityperunit");
            modelBuilder.Entity<Product>().Property(x => x.UnitPrice).HasColumnName("unitprice");
            modelBuilder.Entity<Product>().Property(x => x.UnitsInStock).HasColumnName("unitsinstock");

            // order details
            modelBuilder.Entity<OrderDetails>().ToTable("orderdetails");
            modelBuilder.Entity<OrderDetails>().Property(x => x.Id).HasColumnName("orderid");
            modelBuilder.Entity<OrderDetails>().Property(x => x.ProductId).HasColumnName("productid");
            modelBuilder.Entity<OrderDetails>().Property(x => x.Price).HasColumnName("unitprice");
            modelBuilder.Entity<OrderDetails>().Property(x => x.Quantity).HasColumnName("quantity");
            modelBuilder.Entity<OrderDetails>().Property(x => x.Discount).HasColumnName("discount");

            // order
            modelBuilder.Entity<Order>().ToTable("orders");
            modelBuilder.Entity<Order>().Property(x => x.Id).HasColumnName("orderid");
            modelBuilder.Entity<Order>().Property(x => x.Date).HasColumnName("orderdate");
            modelBuilder.Entity<Order>().Property(x => x.Require).HasColumnName("requireddate");
            modelBuilder.Entity<Order>().Property(x => x.Shipped).HasColumnName("shippeddate");
            modelBuilder.Entity<Order>().Property(x => x.Freight).HasColumnName("freight");
            modelBuilder.Entity<Order>().Property(x => x.ShipName).HasColumnName("shipname");
            modelBuilder.Entity<Order>().Property(x => x.ShipCity).HasColumnName("shipcity");

        }
    }
}
