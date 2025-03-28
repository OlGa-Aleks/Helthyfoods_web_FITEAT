using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helthy_Shop.Data.Models
{
    public class ShopCartItem
    {
        public int id { get; set; }
        public Dish dish { get; set; }
        public int price { get; set; }

        public string ShopCartID { get; set; }

      


    }
}
