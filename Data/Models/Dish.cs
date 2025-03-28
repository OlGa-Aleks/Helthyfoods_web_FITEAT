using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helthy_Shop.Data.Models
{
    public class Dish
    {
        public int id { set; get; }
        public string name { set; get; }
        public ushort price { set; get; }
        public int mealID { set; get; }
        public List<Diet> Tags { set; get; }
        public string description { set; get; }
        public string composition { set; get; }

        public ushort calories { set; get; }
        public ushort weight { set; get; }
        public string micronutrients { set; get; }

        public string allergens { set; get; }

        public string img { set; get; }    
        
        public virtual Meal Meal { set; get; }
               

    }
}
