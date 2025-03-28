using Helthy_Shop.Data.interfaces;
using Helthy_Shop.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helthy_Shop.Data.Repository
{
    public class DietRepository : IDishDiet
    {
        private readonly AppDBContent appDBContent;
        public DietRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public IEnumerable<Diet> ALLDiets => appDBContent.Diet;
    }
}