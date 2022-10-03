using Microsoft.EntityFrameworkCore;
using Do_Again.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Do_Again.Models
{
    public class ourAppContext : IdentityDbContext
    {
        public ourAppContext(DbContextOptions<ourAppContext> options) : base(options)
        {

        }
        public DbSet<Do_Again.Models.Book> Book { get; set; }
        public DbSet<Do_Again.Models.TypeOfBook>TypeOfBooks { get; set; }   
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();
        
        }
    }
    }