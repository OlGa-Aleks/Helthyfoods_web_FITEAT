using Helthy_Shop.Data.interfaces;
using Helthy_Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helthy_Shop.Data.Repository
{
    public class MealReposetory : IDishmeal
    {
        private readonly AppDBContent appDBContent;
        public MealReposetory(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public IEnumerable<Meal> ALLMeals => appDBContent.Meal;
    }
}
