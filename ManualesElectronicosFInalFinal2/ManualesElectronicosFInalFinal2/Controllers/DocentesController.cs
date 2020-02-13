using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ManualesElectronicosFInalFinal2.Controllers
{
    public class DocentesController : Controller
    {
        public IActionResult Docentes()
        {
            return View();
        }
    }
}