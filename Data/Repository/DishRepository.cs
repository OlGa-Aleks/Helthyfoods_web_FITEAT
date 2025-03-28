using Helthy_Shop.Data.interfaces;
using Helthy_Shop.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helthy_Shop.Data.Repository
{
    public class DishRepository : IAllDishes
    {
        private readonly AppDBContent appDBContent;
        public DishRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public IEnumerable<Dish> Dishes => appDBContent.Dish
            .Include(c => c.Meal)
            .Include(с => с.Tags);
            //.AsNoTracking(); // Не кэшировать данные



        public Dish getObjectDish(int dishID)
       => appDBContent.Dish.FirstOrDefault(p=>p.id==dishID);

        public void AddDish(Dish dish)
        {
            appDBContent.Dish.Add(dish);
            appDBContent.SaveChanges();
        }





    }
}
