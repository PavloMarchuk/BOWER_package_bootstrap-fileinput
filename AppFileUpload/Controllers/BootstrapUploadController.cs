using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AppFileUpload.Controllers
{
    public class BootstrapUploadController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}