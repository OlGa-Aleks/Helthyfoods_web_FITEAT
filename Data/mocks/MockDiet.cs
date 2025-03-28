using Helthy_Shop.Data.interfaces;
using Helthy_Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helthy_Shop.Data.mocks
{
    public class MockDiet : IDishDiet
    {
        public IEnumerable<Diet> ALLDiets
        {
            get
            {
                return new List<Diet>
                {
                    new Diet { dietName = "Вегетарианская" },
                    new Diet { dietName = "Веганская" },
                    new Diet { dietName = "Без глютена" },
                    new Diet { dietName = "Без лактозы" },
                    new Diet { dietName = "Без сахара" }
                };
            }
        }
    }
}
