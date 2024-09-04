using Entities.Concreates;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.EntityFramework.Context
{
    public class MarketAppContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MarketDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"); //Bağlantı cümleciği buradan geçilebilir.
                                                                                                                                                                                                                                                                             //string başında @ koymak, kaçış karakterlerini kullanmayacağını belirtir. 
                                                                                                                                                                                                                                                                             //kaçış karakteri : n => \n olduğunda.
                                                                                                                                                                                                                                                                             //Integrated Security : Windows Auth olduğunda.
                                                                                                                                                                                                                                                                             //Şifre ve username ileyse False'a çekilip, Username ve Password verilir.
                                                                                                                                                                                                                                                                             //Initial Catalog = DB ismi
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
            .HasMany(u => u.ShoppingCarts)  // User has many ShoppingCarts
            .WithOne(s => s.User)           // ShoppingCart has one User
            .HasForeignKey(s => s.UserId);  // Foreign key in ShoppingCart table

            // Optional: Configure additional properties if needed
            modelBuilder.Entity<User>()
                .Property(u => u.UserName)
                .IsRequired()
                .HasMaxLength(50);  // Example: Set maximum length of UserName

            modelBuilder.Entity<ShoppingCart>()
                .Property(s => s.TotalPrice)
                .IsRequired();  // Example: Make TotalPrice required

            // Optional: Configure table names, keys, or other properties
            modelBuilder.Entity<User>()
                .ToTable("Users");  // Set table name if different from class name

            modelBuilder.Entity<ShoppingCart>()
                .ToTable("ShoppingCarts");  // Set table name if different from class name

            // Additional configurations as necessary
        }
    }
}
