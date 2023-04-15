using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class PizzeriaDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<DeliveryProvider> DeliveryProviders { get; set; }

        public PizzeriaDbContext(DbContextOptions<PizzeriaDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<OrderPizza>()
            .HasKey(op => new { op.OrderId, op.PizzaId });

            builder.Entity<OrderPizza>()
                .HasOne(op => op.Order)
                .WithMany(o => o.OrderPizzas)
                .HasForeignKey(op => op.OrderId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<OrderPizza>()
                .HasOne(op => op.Pizza)
                .WithMany(p => p.OrderPizzas)
                .HasForeignKey(op => op.PizzaId)
                .OnDelete(DeleteBehavior.NoAction);
        }

    }
}
