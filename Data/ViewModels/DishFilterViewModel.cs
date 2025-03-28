using Helthy_Shop.Data.Models;
using System.Collections.Generic;

namespace Helthy_Shop.Data.ViewModels
{
    public class DishFilterViewModel
    {
        // Параметры фильтрации, которые будут приходить от пользователя
        public int? MinPrice { get; set; }
        public int? MaxPrice { get; set; }
        public int? MinCalories { get; set; }
        public int? MaxCalories { get; set; }
        public List<string> SelectedMeals { get; set; } = new List<string>();
        public List<string> SelectedDiets { get; set; } = new List<string>();

        // Списки для отображения возможных опций фильтрации
        public IEnumerable<Meal> AllMeals { get; set; }
        public IEnumerable<Diet> AllDiets { get; set; }

        // Результат фильтрации – отфильтрованные блюда
        public IEnumerable<Dish> FilteredDishes { get; set; }
    }
}
