using Helthy_Shop.Data.interfaces;
using Helthy_Shop.Data.Models;
using Helthy_Shop.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Html;

namespace Helthy_Shop.Controllers
{
    public class DishesController : Controller
    {
        private readonly IAllDishes _allDishes;
        private readonly IDishDiet _dietDish;
        private readonly IDishmeal _mealDish;

        private readonly ICompositeViewEngine _viewEngine;

        public DishesController(IAllDishes iallDishes, IDishDiet idietDish, IDishmeal imealDish, ICompositeViewEngine viewEngine)
        {
            _allDishes = iallDishes;
            _dietDish = idietDish;
            _mealDish = imealDish;

            _viewEngine = viewEngine;
        }
        //Отображает основной список блюд
        public ViewResult List()
        {
            ViewBag.Title = "Меню";//Устанавливает заголовок страницы
            DishesListViewModel obj = new DishesListViewModel();
            obj.allDishs= _allDishes.Dishes;
            obj.AllDiets = _dietDish.ALLDiets;
            obj.currMeal = "Прием пищи";


            
            return View(obj);
        }

        //Динамическая подгрузка блюд
        [HttpGet]
        public IActionResult LoadMore(int offset)
        {
            var allDishesList = _allDishes.Dishes.ToList();
            // Берём следующую порцию товаров – например, 3 штуки
            var moreDishesQuery = _allDishes.Dishes.Skip(offset).Take(6);
            var moreDishes = moreDishesQuery.ToList();

            // Проверяем, есть ли ещё товары после данной порции
            bool hasMore = _allDishes.Dishes.Skip(offset + moreDishes.Count()).Any();

            // Генерируем HTML с помощью PartialView
            var html = this.RenderPartialViewToString("_DishesPartial", moreDishes);
            return Json(new { html = html, hasMore = hasMore });
        }
        //Преобразует частичное представление в HTML-строку.
        protected string RenderPartialViewToString(string viewName, object model)
        {
            if (string.IsNullOrEmpty(viewName))
                viewName = ControllerContext.ActionDescriptor.ActionName;

            ViewData.Model = model;

            using (var sw = new StringWriter())
            {
                var viewResult = _viewEngine.FindView(ControllerContext, viewName, false);
                if (viewResult.View == null)
                {
                    throw new ArgumentNullException($"{viewName} не найдено. Проверьте правильность имени представления.");
                }
                var viewContext = new ViewContext(
                    ControllerContext,
                    viewResult.View,
                    ViewData,
                    TempData,
                    sw,
                    new HtmlHelperOptions()
                );
                viewResult.View.RenderAsync(viewContext).Wait();
                return sw.GetStringBuilder().ToString();
            }
        }
        //[HttpGet]
        //public IActionResult FilterByPrice(int? minPrice, int? maxPrice, int offset = 0)
        //{
        //    int min = minPrice ?? 0;
        //    int max = maxPrice ?? int.MaxValue;

        //    var filteredQuery = _allDishes.Dishes
        //        .Where(d => d.price >= min && d.price <= max)
        //        .OrderBy(d => d.price);

        //    var filteredDishes = filteredQuery.Skip(offset).Take(6).ToList();
        //    bool hasMore = filteredQuery.Skip(offset + filteredDishes.Count()).Any();

        //    var html = RenderPartialViewToString("_DishesPartial", filteredDishes);
        //    return Json(new { html = html, hasMore = hasMore });
        //}

        [HttpGet]
        public IActionResult FilterDishes(
        int? minPrice, int? maxPrice,
        int? minCalories, int? maxCalories,
        string[] selectedMeals, string[] selectedDiets,
        int offset = 0)
        {
            int priceMin = minPrice ?? 0;
            int priceMax = maxPrice ?? int.MaxValue;
            int caloriesMin = minCalories ?? 0;
            int caloriesMax = maxCalories ?? int.MaxValue;

            // Начинаем с базового запроса
            var query = _allDishes.Dishes.AsQueryable();

            // Фильтрация по цене
            query = query.Where(d => d.price >= priceMin && d.price <= priceMax);

            // Фильтрация по калориям
            query = query.Where(d => d.calories >= caloriesMin && d.calories <= caloriesMax);

            // Фильтрация по приёму пищи (используем Meal.mealName)
            if (selectedMeals != null && selectedMeals.Any())
            {
                // Предполагается, что на клиенте выбранное значение соответствует mealName в нижнем регистре
                query = query.Where(d => selectedMeals.Contains(d.Meal.mealName.ToLower()));
            }

            // Фильтрация по диетам (используем коллекцию Tags)
            if (selectedDiets != null && selectedDiets.Any())
            {
                query = query.Where(d => d.Tags.Any(t =>
                    selectedDiets.Contains(t.dietName.ToLower().Replace(" ", "-"))
                ));
            }

            // Сортировка (например, по цене)
            query = query.OrderBy(d => d.price);

            // Пагинация – выбираем 6 элементов
            var filteredDishes = query.Skip(offset).Take(6).ToList();
            bool hasMore = query.Skip(offset + filteredDishes.Count()).Any();

            var html = RenderPartialViewToString("_DishesPartial", filteredDishes);
            return Json(new { html = html, hasMore = hasMore });
        }


        public IActionResult Details(int id)
        {
            var dish = _allDishes.Dishes
                .FirstOrDefault(d => d.id == id);

            if (dish == null)
            {
                return NotFound(); // Вернуть 404, если блюда нет
            }

            return View(dish);
        }















    }
}
