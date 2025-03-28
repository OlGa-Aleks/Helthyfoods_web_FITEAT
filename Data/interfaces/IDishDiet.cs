using Helthy_Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helthy_Shop.Data.interfaces
{
   public interface IDishDiet
    {
        IEnumerable<Diet> ALLDiets { get; }
    }
}
