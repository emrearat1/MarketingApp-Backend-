using Entities.Concreates;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.EntityFramework.Context
{
    public class MarketAppContext:DbContext
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
                .HasOne(u => u.ShoppingCart)
                .WithOne(sc => sc.User)
                .HasForeignKey<User>(u => u.ShoppingCartId);

            modelBuilder.Entity<ShoppingCart>()
                .HasOne(sc => sc.User)
                .WithOne(u => u.ShoppingCart)
                .HasForeignKey<ShoppingCart>(sc => sc.UserId);
        }
    }
}
