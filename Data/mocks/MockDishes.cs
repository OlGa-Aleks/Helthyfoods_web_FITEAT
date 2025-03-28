using Helthy_Shop.Data.interfaces;
using Helthy_Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helthy_Shop.Data.mocks
{
    public class MockDishes : IAllDishes    {
        private readonly IDishmeal _mealsDishs = new MockMeal();
        private readonly IDishDiet _dishDiets = new MockDiet();
        public IEnumerable<Dish> Dishes { 
            get {
                return new List<Dish> 
                { new Dish{  name ="Лосось по гречески",price =1200,Meal =_mealsDishs.ALLMeals.First(),

                             Tags = _dishDiets.ALLDiets.ToList(),
                             description ="Это блюдо из запечённого лосося в греческом стиле готовится быстро и просто, и его можно приготовить на обед в будний день. Оно содержит омега-3, белок и много свежих овощей и является идеальным питательным блюдом.",
                             composition ="Лосось; Помидоры черри; Красный лук; Болгарский перец; Оливки; Фета; Лимон; Оливковое масло; Чеснок; Свежий орегано; Соль; Перец.",
                             calories =490,
                             weight =350,
                             micronutrients ="40/25/10",
                             allergens ="остатки орех",
                             img = "/img/greek-baked-salmon-1.jpeg"},
                new Dish{  name ="Блинчики с матчей и протеином",price =460,Meal =_mealsDishs.ALLMeals.First(),

                            Tags = _dishDiets.ALLDiets.ToList(),
                             description ="Лёгкие и пышные протеиновые блинчики с матчей, без сахара из рафинированных злаков, только с овсянкой и большим количеством полезных белков.",
                             composition ="Овсяная мука без глютена; Порошок матчи (2-3 г) ; Кокосовое масло; Порошок протеина(20 г), Стевия.",
                             calories =350,
                             weight =210,
                             micronutrients ="30/15/41",
                             allergens ="остатки орехов, клубника",
                             img ="/img/tovar_first.jpeg" },
                new Dish{  name ="Блинчики с матчей и протеином",price =460,Meal =_mealsDishs.ALLMeals.First(),

                             Tags = _dishDiets.ALLDiets.ToList(),
                             description ="Лёгкие и пышные протеиновые блинчики с матчей, без сахара из рафинированных злаков, только с овсянкой и большим количеством полезных белков.",
                             composition ="Овсяная мука без глютена; Порошок матчи (2-3 г) ; Кокосовое масло; Порошок протеина(20 г), Стевия.",
                             calories =350,
                             weight =210,
                             micronutrients ="30/15/41",
                             allergens ="остатки орехов, клубника",
                             img ="/img/greek-baked-salmon-1.jpeg" },
                new Dish{  name ="Блинчики с матчей и протеином",price =460,Meal =_mealsDishs.ALLMeals.First(),

                             Tags = _dishDiets.ALLDiets.ToList(),
                             description ="Лёгкие и пышные протеиновые блинчики с матчей, без сахара из рафинированных злаков, только с овсянкой и большим количеством полезных белков.",
                             composition ="Овсяная мука без глютена; Порошок матчи (2-3 г) ; Кокосовое масло; Порошок протеина(20 г), Стевия.",
                             calories =350,
                             weight =210,
                             micronutrients ="30/15/41",
                             allergens ="остатки орехов, клубника",
                             img ="/img/greek-baked-salmon-1.jpeg" },
                new Dish{  name ="Блинчики с матчей и протеином",price =460,Meal =_mealsDishs.ALLMeals.First(),

                             Tags = _dishDiets.ALLDiets.ToList(),
                             description ="Лёгкие и пышные протеиновые блинчики с матчей, без сахара из рафинированных злаков, только с овсянкой и большим количеством полезных белков.",
                             composition ="Овсяная мука без глютена; Порошок матчи (2-3 г) ; Кокосовое масло; Порошок протеина(20 г), Стевия.",
                             calories =350,
                             weight =210,
                             micronutrients ="30/15/41",
                             allergens ="остатки орехов, клубника",
                             img ="/img/greek-baked-salmon-1.jpeg" },
                new Dish{  name ="Блинчики с матчей и протеином",price =460,Meal =_mealsDishs.ALLMeals.First(),

                             Tags = _dishDiets.ALLDiets.ToList(),
                             description ="Лёгкие и пышные протеиновые блинчики с матчей, без сахара из рафинированных злаков, только с овсянкой и большим количеством полезных белков.",
                             composition ="Овсяная мука без глютена; Порошок матчи (2-3 г) ; Кокосовое масло; Порошок протеина(20 г), Стевия.",
                             calories =350,
                             weight =210,
                             micronutrients ="30/15/41",
                             allergens ="остатки орехов, клубника",
                             img ="/img/greek-baked-salmon-1.jpeg" },
                new Dish{  name ="Блинчики с матчей и протеином",price =460,Meal =_mealsDishs.ALLMeals.First(),

                             Tags = _dishDiets.ALLDiets.ToList(),
                             description ="Лёгкие и пышные протеиновые блинчики с матчей, без сахара из рафинированных злаков, только с овсянкой и большим количеством полезных белков.",
                             composition ="Овсяная мука без глютена; Порошок матчи (2-3 г) ; Кокосовое масло; Порошок протеина(20 г), Стевия.",
                             calories =350,
                             weight =210,
                             micronutrients ="30/15/41",
                             allergens ="остатки орехов, клубника",
                             img ="/img/greek-baked-salmon-1.jpeg" },
                new Dish{  name ="Блинчики с матчей и протеином",price =460,Meal =_mealsDishs.ALLMeals.First(),

                             Tags = _dishDiets.ALLDiets.ToList(),
                             description ="Лёгкие и пышные протеиновые блинчики с матчей, без сахара из рафинированных злаков, только с овсянкой и большим количеством полезных белков.",
                             composition ="Овсяная мука без глютена; Порошок матчи (2-3 г) ; Кокосовое масло; Порошок протеина(20 г), Стевия.",
                             calories =350,
                             weight =210,
                             micronutrients ="30/15/41",
                             allergens ="остатки орехов, клубника",
                             img ="/img/greek-baked-salmon-1.jpeg" },
                new Dish{  name ="Блинчики с матчей и протеином",price =460,Meal =_mealsDishs.ALLMeals.First(),

                             Tags = _dishDiets.ALLDiets.ToList(),
                             description ="Лёгкие и пышные протеиновые блинчики с матчей, без сахара из рафинированных злаков, только с овсянкой и большим количеством полезных белков.",
                             composition ="Овсяная мука без глютена; Порошок матчи (2-3 г) ; Кокосовое масло; Порошок протеина(20 г), Стевия.",
                             calories =350,
                             weight =210,
                             micronutrients ="30/15/41",
                             allergens ="остатки орехов, клубника",
                             img ="/img/greek-baked-salmon-1.jpeg" }
            };
            } 
        }

        public void AddDish(Dish dish)
        {
            throw new NotImplementedException();
        }

        public Dish getObjectDish(int dishID)
        {
            throw new NotImplementedException();
        }

       
    }
}
