using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace AppFileUpload.Controllers
{
    public class UploadController : Controller
    {
        IHostingEnvironment env;    //инициализируем через конструктор, 
                                    //с помощью встроенного контейнера зависимостей
        public UploadController(IHostingEnvironment env)
        {
            this.env = env;
        }

        public IActionResult FileUpload() => View();//загрузка одного файла!
      
        [HttpPost]
        public async Task<IActionResult> FileUpload(IFormFile fileUpload)
        {
            if(fileUpload!=null)
            {
                string path = "/Files/" + fileUpload.FileName.Split(new char[] { '\\', '/' }).Last();
                // сохраняем файл в папку Files в каталоге wwwroot
                using (var fileStream = new FileStream(env.WebRootPath + path, FileMode.Create))
                {
                    await fileUpload.CopyToAsync(fileStream);
                }
            }
            return RedirectToAction("FileUpload");
        }
        public IActionResult ManyFileUpload() => View();//загрузка нескольких файла!

        //Or  List<IFormFile> manyFileUpload Or IEnumerable<IFormFile> manyFileUpload
        [HttpPost]        
        public async Task<IActionResult> ManyFileUpload(IEnumerable<IFormFile> manyFileUpload)//
        {
            if (manyFileUpload != null)
            {
                foreach (var fileUpload in manyFileUpload)
                {
                    string path = "/Files/" + fileUpload.FileName.Split(new char[] { '\\', '/' }).Last();
                    // сохраняем файл в папку Files в каталоге wwwroot
                    using (var fileStream = new FileStream(env.WebRootPath + path, FileMode.Create))
                    {
                        await fileUpload.CopyToAsync(fileStream);
                    }
                }
            }
            return RedirectToAction("ManyFileUpload");
        }
    }
}