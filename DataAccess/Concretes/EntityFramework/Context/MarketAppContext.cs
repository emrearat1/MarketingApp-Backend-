using Entities.Concreates;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.EntityFramework.Context
{
    //public class MarketAppContext : DbContext
    public class MarketAppContext : IdentityDbContext<User>
    {
        public DbSet<User> Users { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ShoppingCartProduct> ShoppingCartProducts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MarketDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
       
           protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            List<IdentityRole> roles = new List<IdentityRole>()
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                 new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER"
                },

            };
           modelBuilder.Entity<IdentityRole>().HasData(roles);
            // Configure Product entity
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.ProductName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Price).IsRequired();
                entity.Property(e => e.MarketerId).HasMaxLength(50);
                entity.Property(e => e.MarketerName).HasMaxLength(100);

                entity.HasMany(p => p.Comments)
                      .WithOne(c => c.Product)
                      .HasForeignKey(c => c.ProductId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Configure ShoppingCart entity
            modelBuilder.Entity<ShoppingCart>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.TotalPrice).HasColumnType("decimal(18,2)");

                // Configure one-to-many relationship with User
                entity.HasOne(sc => sc.User)
                      .WithMany(u => u.ShoppingCarts)
                      .HasForeignKey(sc => sc.UserId)
                      .OnDelete(DeleteBehavior.Cascade); // Ensures related shopping carts are deleted if user is deleted


            });

            // Configure User entity
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.UserName).IsRequired().HasMaxLength(50);
                //entity.Property(e => e.Password).IsRequired().HasMaxLength(255);
                entity.Property(e => e.Wallet).IsRequired();

                entity.HasMany(u => u.Comments)
                      .WithOne(c => c.User)
                      .HasForeignKey(c => c.UserId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<ShoppingCartProduct>(entity =>
            {
                entity.HasKey(scp => new { scp.ShoppingCartId, scp.ProductId });

                // Configure the relationship between ShoppingCartProduct and ShoppingCart
                entity.HasOne(scp => scp.ShoppingCart)
                      .WithMany(sc => sc.Products)
                      .HasForeignKey(scp => scp.ShoppingCartId)
                      .OnDelete(DeleteBehavior.Cascade);

                // Configure the relationship between ShoppingCartProduct and Product
                entity.HasOne(scp => scp.Product)
                      .WithMany(p => p.ShoppingCarts)
                      .HasForeignKey(scp => scp.ProductId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Title).IsRequired().HasMaxLength(500);
                entity.Property(e => e.Body).IsRequired().HasMaxLength(500);
            });
        }
    }
}
