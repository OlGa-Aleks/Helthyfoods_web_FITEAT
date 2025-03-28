using Helthy_Shop.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helthy_Shop.Data
{
    public class DBObject
    {
        public static void Initial(AppDBContent content)
        {
            



            if (!content.Meal.Any())
            {
                content.Meal.AddRange(Meals.Select(c => c.Value));
            }
            if (!content.Diet.Any())
            {
                content.Diet.AddRange(Diets.Select(d => d.Value));
            }


            if (!content.Dish.Any())
            {
                content.AddRange(
                    new Dish
                    {
                        name = "Блинчики с матчей и протеином",
                        price = 560,
                        Meal = Meals["Завтрак"],

                        Tags = new List<Diet> { Diets["Веганская"], Diets["Вегетарианская"], Diets["Без глютена"], Diets["Без сахара"] },
                        description = "Лёгкие и пышные протеиновые блинчики с матчей, без сахара из рафинированных злаков, только с овсянкой и большим количеством полезных белков.",
                        composition = "Овсяная мука без глютена; Порошок матчи (2-3 г) ; Кокосовое масло; Порошок протеина(20 г), Стевия.",
                        calories = 350,
                        weight = 210,
                        micronutrients = "40/25/10",
                        
                        img = "/img/tovar_first.jpeg"
                    },
                    new Dish
                    {
                        name = "Лосось по гречески",
                        price = 1500,
                        Meal = Meals["Ужин"],

                        Tags = new List<Diet> { Diets["Без глютена"], Diets["Без лактозы"] },
                        description = "Это блюдо из запечённого лосося в греческом стиле готовится быстро и просто, и его можно приготовить на обед в будний день. Оно содержит омега-3, белок и много свежих овощей и является идеальным питательным блюдом.",
                        composition = "Лосось; Помидоры черри; Красный лук; Болгарский перец; Оливки; Фета; Лимон; Оливковое масло; Чеснок; Свежий орегано; Соль; Перец.",
                        calories = 490,
                        weight = 350,
                        micronutrients = "40/25/10",
                        allergens = "остатки орех",
                        img = "/img/greek-baked-salmon-1.jpeg"
                    },
                new Dish
                {
                    name = "Фалафельные вафли",
                    price = 460,
                    Meal = Meals["Завтрак"],

                    Tags = new List<Diet> { Diets["Веганская"], Diets["Вегетарианская"], Diets["Без глютена"], Diets["Без лактозы"] },
                    description = "Необычный взгляд на классику! Все вкусы, которые вы знаете и любите в фалафеле, в форме вафли, идеально хрустящей, без жарки во фритюре. Подаётся с салатом из огурцов и помидоров и йогуртовым соусом с кинзой в качестве лёгкого и освежающего блюда для позднего завтрака.",
                    composition = "Нут-250 г;муки из гарбанзо-50 г;1 ст. л.-кориандр;1 столовая ложка-тахини;1 ч. л.-лимонный сок;1/8 ч. л.-чесночный порошок;1/4 ч. л.-молотый тмин;1/4 ч. л.-свежемолотый перец;1 / 4 ч.л.- соль; 60 мл - вода.",
                    calories = 400,
                    weight = 300,
                    micronutrients = "30/15/41",
                    
                    img = "/img/falafel-waffles.jpeg"
                },
                new Dish
                {
                    name = "Веганский сендвич с яйцом и карри",
                    price = 320,
                    Meal = Meals["Завтрак"],

                    Tags = new List<Diet> { Diets["Веганская"], Diets["Вегетарианская"], Diets["Без лактозы"] },
                    description = "Салат с тофу и карри — это вкусно и отличная замена сэндвичам с яйцом и карри! Порошок карри полезен для здоровья, так как уменьшает воспаление и улучшает уровень сахара в крови. Салат отлично подходит для сэндвичей, бургеров или в качестве начинки для рисовых крекеров.",
                    composition = "Твердый тофу-200 г; Желтая горчица - 1 ст. л.; Тахини - 1 ст.л.; Сок лайма - 1 ст.л.; Порошок карри -1,5 ст.л.; Луковой порошок -1/2 ч.л.;Чесночный порошок -1/2 ч.л.;Кукурма - 1/4 ч.л.;Паприка - 1/4 ч.л.;черная соль - 1/2 ч.л.. ",
                    calories = 420,
                    weight = 270,
                    micronutrients = "40/10/50",

                    img = "/img/vegan-curried-egg-sandwich.jpeg"
                },
                new Dish
                {
                    name = "Цветная капуста с кунжутом и апельсином",
                    price = 320,
                    Meal = Meals["Обед"],

                    Tags = new List<Diet> { Diets["Веганская"], Diets["Вегетарианская"] },
                    description = "Хрустящие кусочки цветной капусты в сладком и пикантном липком апельсиновом соусе. Представьте, что это более здоровая вегетарианская версия курицы в апельсиновом соусе с кунжутом.",
                    composition = "Цветная капуста -1 головка;Цельнозерновая мука -150 г.; Соевое молоко -220 мл; Белый перец - 1/2 ч.л.; Апельсины выжатый из сока - 100 г, Соевый соус- 10 мл; Кукурузный крахмал - 30 г, кунжут -20 г. ",
                    calories = 230,
                    weight = 210,
                    micronutrients = "34/9/50",
                    allergens = "апельсин, кунжут",

                    img = "/img/sesame-orange-cauliflower.jpeg"
                },
                 new Dish
                 {
                     name = "Карри из кокосовых креветок",
                     price = 870,
                     Meal = Meals["Обед"],

                     Tags = new List<Diet> { Diets["Без глютена"], Diets["Без лактозы"] },
                     description = "кокосовое карри с креветками очень ароматное, а на его приготовление уходит меньше 30 минут. Сочные креветки в сливочно-томатном кокосовом карри отлично сочетаются с рисом или нааном, а если вы следите за потреблением углеводов, то с рисом из цветной капусты.",
                     composition = "Креветки; Кокосовое молоко; Лук; Чеснок; Имбирь; Карри-паста; Кокосовое масло; Лимонный сок; Соль; Перец; Кинза; Рис.",
                     calories = 450,
                     weight = 350,
                     micronutrients = "25/20/35",
                     allergens = "кокос",

                     img = "/img/tovar_eight.jpeg"
                 },
                  new Dish
                  {
                      name = "Полезные фрикадельки Терияки",
                      price = 570,
                      Meal = Meals["Обед"],

                      Tags = new List<Diet> { Diets["Без глютена"], Diets["Без лактозы"] },
                      description = "Фрикадельки в соусе терияки содержат много говядины, овощей и специй! Они богаты белком и клетчаткой и подаются с липкой глазурью терияки без сахара, которая представляет собой идеальное сочетание солёного и сладкого.",
                      composition = "Фарш из индейки; Яйцо; Панировочные сухари из цельнозернового хлеба; Чеснок; Имбирь; Соевый соус; Мед; Кунжутное масло; Кунжут; Зеленый лук.",
                      calories = 150,
                      weight = 210,
                      micronutrients = "25/10/15",
                      

                      img = "/img/healthy-teriyaki-meatballs.jpeg"
                  },
                  new Dish
                  {
                      name = "Паста со спаржей и креветками",
                      price = 1120,
                      Meal = Meals["Обед"],

                      Tags = new List<Diet> { Diets["Без глютена"] },
                      description = "Паста со  свежей спаржей и сочными креветками в простом лимонно-чесночном соусе. Лёгкий и яркий вкус делает его идеальным летним блюдом.",
                      composition = "Спагетти; Креветки; Спаржа; Чеснок; Оливковое масло; Лимонный сок; Соль; Перец; Пармезан; Петрушка.",
                      calories = 350,
                      weight = 210,
                      micronutrients = "20/10/40",


                      img = "/img/asparagus-shrimp-spaghetti.jpeg"
                  },
                   new Dish
                   {
                       name = "Тортилья с запеченным тофу и барбекью",
                       price = 665,
                       Meal = Meals["Обед"],

                       Tags = new List<Diet> { Diets["Веганская"], Diets["Вегетарианская"],Diets["Без глютена"] },
                       description = "Тортилья доверху наполненная измельчённым тофу с барбекю, множеством свежих овощей и сливочным соусом из бобов чипотле, станут полезным и сытным обедом, которого вы будете ждать всё утро!",
                       composition = "Тортилья; Тофу; Соус барбекю; Шпинат; Лук; Чеснок; Оливковое масло; Соль; Перец; Сыр (по желанию).",
                       calories = 300,
                       weight = 250,
                       micronutrients = "15/10/35",


                       img = "/img/chipotle-shredded-tofu.jpeg"
                   }
                );
            }
            content.SaveChanges();//сохраняем изменения
        }
        private static Dictionary<string, Meal> meal;
        public static Dictionary<string,Meal> Meals
        {
            get
            {
                if (meal == null)
                {
                    var list = new Meal[]
                    {
                    new Meal{mealName="Завтрак"},
                    new Meal{mealName="Обед"},
                    new Meal{mealName="Ужин"},
                    };
                    meal = new Dictionary<string, Meal>();
                    foreach (Meal el in list)
                    {
                        meal.Add(el.mealName, el);
                    }
                }
                return meal;
            }
        }

        private static Dictionary<string, Diet> diet;
        public static Dictionary<string, Diet> Diets
        {
            get
            {
                if (diet == null)
                {
                    var list = new Diet[]
                    {
                new Diet { dietName = "Веганская" },
                new Diet { dietName = "Вегетарианская" },
                new Diet { dietName = "Без глютена" },
                new Diet { dietName = "Без лактозы" },
                new Diet { dietName = "Без сахара" }
                    };
                    diet = new Dictionary<string, Diet>();
                    foreach (Diet el in list)
                    {
                        diet.Add(el.dietName, el);
                    }
                }
                return diet;
            }
        }

    }
}
