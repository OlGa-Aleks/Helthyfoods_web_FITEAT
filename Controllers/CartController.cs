using Microsoft.AspNetCore.Mvc;
using Helthy_Shop.Data.Models;
using System.Linq;
using Helthy_Shop.Data.interfaces;

namespace Helthy_Shop.Controllers
{
    public class CartController : Controller
    {
        private readonly IAllDishes _allDishes;
        private readonly ShopCart _shopCart;

        public CartController(IAllDishes allDishes, ShopCart shopCart)
        {
            _allDishes = allDishes;
            _shopCart = shopCart;
        }

        // Сценарий добавления товара в корзину
        [HttpPost]
        public IActionResult AddToCart([FromBody] dynamic request)
        {
            // Если передается только dishId (без количества)
            // Предположим, что request.dishId приходит как строка, поэтому парсим:
            int dishId = int.Parse(request.GetProperty("dishId").GetString());
            var dish = _allDishes.Dishes.FirstOrDefault(d => d.id == dishId);
            if (dish != null)
            {
                // Проверяем, есть ли этот товар уже в корзине
                var existingItem = _shopCart.GetCartItems().FirstOrDefault(i => i.dish.id == dishId);
                if (existingItem == null) // Если товара еще нет, добавляем
                {
                    _shopCart.AddToCart(dish);
                }
                return Json(new { success = true, message = "Товар добавлен в корзину", cartUrl = Url.Action("CartView", "Cart") });
            }
            return Json(new { success = false, message = "Товар не найден" });
        }

        // Сценарий удаления товара из корзины
        [HttpPost]
        public IActionResult RemoveFromCart([FromBody] dynamic request)
        {
            int dishId = request.GetProperty("dishId").GetInt32();

            _shopCart.RemoveFromCart(dishId);
            int total = _shopCart.GetTotalPrice();
            return Json(new { success = true, totalPrice = total });
        }

        // Отображение страницы корзины
        public IActionResult CartView()
        {
            var items = _shopCart.GetCartItems();
            return View(items);
        }

        [HttpGet]
        public IActionResult GetCartItems()
        {
            var items = _shopCart.GetCartItems().Select(i => i.dish.id).ToList();
            return Json(items);
        }

    }
}
