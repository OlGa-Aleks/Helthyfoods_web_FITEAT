using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Helthy_Shop.Data.ViewModels
{
    public class NewDishDTO
    {
        [Required(ErrorMessage = "Название обязательно")]
        [Display(Name = "Название блюда:")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Цена обязательна")]
        [Range(0, int.MaxValue, ErrorMessage = "Цена должна быть положительной")]
        [Display(Name = "Цена (₽):")]
        public ushort Price { get; set; }

        [Required(ErrorMessage = "Приём пищи обязателен")]
        [Display(Name = "Приём пищи:")]
        public string MealTime { get; set; }

        [RequiredList(ErrorMessage = "Выберите хотя бы одну диету")]
        [Display(Name = "Диеты:")]
        public List<string> Diets { get; set; }



        [Required(ErrorMessage = "Описание обязательно")]
        [MinLength(20, ErrorMessage = "Описание должно содержать не менее 20 символов")]
        [Display(Name = "Описание:")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Состав обязателен")]
        [MinLength(20, ErrorMessage = "Состав должен содержать не менее 20 символов")]
        [Display(Name = "Состав блюда:")]
        public string Composition { get; set; }

        [Required(ErrorMessage = "Калорийность обязательна")]
        [Range(0, int.MaxValue, ErrorMessage = "Калории должны быть положительными")]
        [Display(Name = "Калорийность (ккал):")]
        public ushort Calories { get; set; }

        [Required(ErrorMessage = "Вес обязателен")]
        [Range(0, int.MaxValue, ErrorMessage = "Вес должен быть положительным")]
        [Display(Name = "Вес (г):")]
        public ushort Weight { get; set; }

        [Required(ErrorMessage = "Макронутриенты обязательны")]
        [RegularExpression(@"^\d+\/\d+\/\d+$", ErrorMessage = "Макронутриенты нужно вводить в формате: жиры/углеводы/белки (например, 10/20/30)")]
        [Display(Name = "Макронутриенты (Б/Ж/У):")]
        public string Macronutrients { get; set; }

        // Поле для аллергенов – не обязательно
        [Display(Name = "Аллергены:")]
        public string Allergens { get; set; }

        [Required(ErrorMessage = "Изображение обязательно для загрузки")]
        [DataType(DataType.Upload)]
        [Display(Name = "Изображение блюда:")]
        public IFormFile Image { get; set; }

        // Новое свойство для хранения пути к изображению
        public string? ImagePath { get; set; }

        
    }
}
