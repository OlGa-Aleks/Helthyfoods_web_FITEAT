using Helthy_Shop.Data.interfaces;
using Helthy_Shop.Data.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Helthy_Shop.Controllers
{
    public class FormController : Controller
    {
        private readonly IAllDishes _dishRepo;
        private readonly IDishmeal _mealRepo;
        private readonly IDishDiet _dietRepo;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FormController(IAllDishes dishRepo, IDishmeal mealRepo, IDishDiet dietRepo, IWebHostEnvironment webHostEnvironment)
        {
            _dishRepo = dishRepo;
            _mealRepo = mealRepo;
            _dietRepo = dietRepo;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Отображаем форму добавления нового блюда
        [HttpGet]       
        public IActionResult AddForm()
        {
           
            return View();
        }

        // POST: Добавление нового блюда
        [HttpPost]
        public async Task<IActionResult> AddDish(Data.ViewModels.NewDishDTO model)
        {
            // Проверка на пустые и отрицательные значения
            if (string.IsNullOrWhiteSpace(model.Name))
                ModelState.AddModelError("Name", "Название обязательно");

            if (string.IsNullOrWhiteSpace(model.Description) || model.Description.Length < 20)
                ModelState.AddModelError("Description", "Описание должно содержать не менее 20 символов");

            if (string.IsNullOrWhiteSpace(model.Composition) || model.Composition.Length < 20)
                ModelState.AddModelError("Composition", "Состав должен содержать не менее 20 символов");

            if (model.Price <= 0)
                ModelState.AddModelError("Price", "Цена должна быть положительным числом");

            if (model.Calories < 0)
                ModelState.AddModelError("Calories", "Калории не могут быть отрицательными");

            if (model.Weight <= 0)
                ModelState.AddModelError("Weight", "Вес должен быть положительным числом");

            // Проверка существования типа приёма пищи
            var selectedMeal = _mealRepo.ALLMeals.FirstOrDefault(m => m.mealName == model.MealTime);
            if (selectedMeal == null)
                ModelState.AddModelError("MealTime", "Выбранный тип приёма пищи не найден");

            // Проверка файла изображения
            if (model.Image == null || model.Image.Length == 0)
            {
                ModelState.AddModelError("Image", "Изображение обязательно для загрузки");
            }
            else
            {
                var ext = Path.GetExtension(model.Image.FileName).ToLower();
                if (ext != ".jpg" && ext != ".jpeg" && ext != ".png")
                {
                    ModelState.AddModelError("Image", "Допустимы только файлы формата jpeg или png");
                }
            }

            if (!ModelState.IsValid)
            {
                // Если есть ошибки, возвращаем представление с текущими данными
                return View(model);
            }

            // Создание нового объекта Dish
            Dish newDish = new Dish
            {
                name = model.Name,
                price = model.Price,
                description = model.Description,
                composition = model.Composition,
                calories = model.Calories,
                weight = model.Weight,
                micronutrients = model.Macronutrients,
                allergens = model.Allergens,
                Meal = selectedMeal,
                Tags = new List<Diet>()
            };

            // Привязка выбранных диет
            if (model.Diets != null && model.Diets.Any())
            {
                foreach (var dietName in model.Diets)
                {
                    var diet = _dietRepo.ALLDiets.FirstOrDefault(d => d.dietName == dietName);
                    if (diet != null)
                    {
                        newDish.Tags.Add(diet);
                    }
                }
            }

            // Сохранение изображения
            try
            {
                string uniqueFileName = ImageSaveHelper.SaveImage(model.Image);
                newDish.img = "/img/" + uniqueFileName; // записываем полный путь


            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Image", "Ошибка при загрузке изображения: " + ex.Message);
                return View(model);
            }

            // Сохранение блюда в базе данных
            _dishRepo.AddDish(newDish);

            // Перенаправление на главную страницу
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
