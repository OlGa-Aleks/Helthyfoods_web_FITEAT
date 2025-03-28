using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace Helthy_Shop
{
    public class ImageSaveHelper
    {
        public static string SaveImage(Microsoft.AspNetCore.Http.IFormFile image)
        {

            string path = System.IO.Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "wwwroot/img/"));

            var ext = Path.GetExtension(image.FileName);
            var newName = Guid.NewGuid().ToString() + ext;

            using (var fileStream = new FileStream(Path.Combine(path, newName), FileMode.Create))
            {
                image.CopyTo(fileStream);
            }

            return newName;
        }
    }
}
