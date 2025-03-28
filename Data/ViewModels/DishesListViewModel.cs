using Helthy_Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helthy_Shop.Data.ViewModels
{
    public class DishesListViewModel
    {
        public IEnumerable<Diet> AllDiets { get; set; }
        public IEnumerable <Dish> allDishs { get; set; }
        public string currMeal { get; set; }


        public bool HasMore { get; set; }
        // Новые свойства для сохранения состояний фильтров:
        public int? MinCalories { get; set; }
        public int? MaxCalories { get; set; }
        public string[] SelectedMeals { get; set; }
        public string[] SelectedDiets { get; set; }
    }
}
