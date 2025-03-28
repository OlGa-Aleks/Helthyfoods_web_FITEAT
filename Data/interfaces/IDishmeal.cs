using Helthy_Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//Интерфейс для получение всех типов примема пищи
namespace Helthy_Shop.Data.interfaces
{
   public interface IDishmeal
    {
        IEnumerable<Meal> ALLMeals { get; }
    }
}
