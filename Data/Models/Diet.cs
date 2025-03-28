using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helthy_Shop.Data.Models
{
    public class Diet
    {
        public int id { set; get; }
        public string dietName { set; get; }
        public List<Dish> Dishes { set; get; }
    }
}
