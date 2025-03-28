using Helthy_Shop.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helthy_Shop.Data
{
    public class AppDBContent  : Microsoft.EntityFrameworkCore.DbContext
    {
        public AppDBContent(DbContextOptions<AppDBContent> options) : base(options)
        {

        }
        
        public Microsoft.EntityFrameworkCore.DbSet<Dish> Dish { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Meal> Meal { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Diet> Diet { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<ShopCartItem> ShopCartItem { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dish>()
                .HasMany(d => d.Tags)
                .WithMany(d => d.Dishes)
                .UsingEntity(j => j.ToTable("DishDiets")); // Промежуточная таблица
        }






    }
}
