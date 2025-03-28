using Helthy_Shop.Data.interfaces;
using Helthy_Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helthy_Shop.Data.mocks
{
    public class MockMeal : IDishmeal
    {
        public IEnumerable<Meal> ALLMeals { 
            get{
                return new List<Meal>
                {
                    new Meal{mealName="Завтрак"},
                    new Meal{mealName="Обед"},
                    new Meal{mealName="Ужин"},

                };
            }
        }
    }
}
