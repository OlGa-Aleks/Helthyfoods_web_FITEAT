using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helthy_Shop.Data.Models
{
    public class ShopCart
    {
        private readonly AppDBContent appDBContent;
        public ShopCart(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public string ShopCartId { get; set; }

        public List<ShopCartItem> listShopItems { get; set; }

        public static ShopCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDBContent>();
            string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", shopCartId);

            var cart = new ShopCart(context) { ShopCartId = shopCartId };

            // Загружаем товары в корзину сразу при получении
            cart.listShopItems = context.ShopCartItem
                .Include(s => s.dish)  // Подгружаем товар, чтобы избежать NullReferenceException
                .Where(s => s.ShopCartID == shopCartId)
                .ToList();

            return cart;

        }

        public void AddToCart(Dish dish)
        {

            //// Получаем отслеживаемую сущность блюда из базы по его id
            //var trackedDish = appDBContent.Dish.FirstOrDefault(d => d.id == dish.id);
            //if (trackedDish == null)
            //{
            //    throw new Exception("Блюдо не найдено в базе");
            //}

            this.appDBContent.ShopCartItem.Add(new ShopCartItem
            {
                ShopCartID = ShopCartId,
                dish = dish,
                price = dish.price
            });
            appDBContent.SaveChanges();
        }


        public List<ShopCartItem> GetCartItems()
        {
            return appDBContent.ShopCartItem.Where(s => s.ShopCartID == ShopCartId).ToList();
        }

        public int GetTotalPrice()
        {
            return appDBContent.ShopCartItem.Where(s => s.ShopCartID == ShopCartId).Sum(s => s.price);
        }

        public void RemoveFromCart(int dishId)
        {
            var cartItem = appDBContent.ShopCartItem.FirstOrDefault(s => s.dish.id == dishId && s.ShopCartID == ShopCartId);
            if (cartItem != null)
            {
                appDBContent.ShopCartItem.Remove(cartItem);
                appDBContent.SaveChanges();
            }
        }




    }
}
