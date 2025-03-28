using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helthy_Shop.Data.Models
{
    public class Meal
    {
        public int id { set; get; }
        public string mealName { set; get; }
        public List<Dish> dishs { set; get; }
    }
}
