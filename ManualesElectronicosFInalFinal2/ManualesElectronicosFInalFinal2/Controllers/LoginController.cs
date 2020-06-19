using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManualesElectronicosFInalFinal2.Models;
using Microsoft.AspNetCore.Mvc;

namespace ManualesElectronicosFInalFinal2.Controllers
{
    public class LoginController : Controller
    {
        
        public static string mensaje { set; get; }
        itesrcne_manualesContext context;
        [HttpPost]
        public IActionResult Login(string nombre, string password)
        {
            context = new itesrcne_manualesContext();
            var result = context.Login.Any(x => x.Nombre == nombre && x.Password == password);
            if (result)
            {
                mensaje = nombre;
                return RedirectToAction("Contenido");

            }
            else
            {
                ViewBag.Incorrecto = "Valores Incorrectos";
                return RedirectToAction("Login");
            }
        }
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Contenido()
        {
            return View();
        }
    }
}