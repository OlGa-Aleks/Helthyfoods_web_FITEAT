using Helthy_Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helthy_Shop.Data.interfaces
{
    public interface IAllDishes
    {
        IEnumerable<Dish> Dishes { get;  }
        Dish getObjectDish(int dishID);

        void AddDish(Dish dish); // Новый метод для добавления блюда
    



}
}
