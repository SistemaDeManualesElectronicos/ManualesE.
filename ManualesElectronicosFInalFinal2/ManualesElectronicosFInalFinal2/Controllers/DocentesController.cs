using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManualesElectronicosFInalFinal2.Models;
using ManualesElectronicosFInalFinal2.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ManualesElectronicosFInalFinal2.Controllers
{
    public class DocentesController : Controller
    {
        DocentesRepository doc;
        public IActionResult Docentes()
        {
            doc = new DocentesRepository();
            return View(doc.GetDocentesxNombre());
        }


        public IActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Agregar(Docentes nuevo)
        {
            doc = new DocentesRepository();
            if (ModelState.IsValid)
            {
                doc.Insert(nuevo);
              
                return RedirectToAction("Docentes");
            }
            else
            {
                return View(nuevo);
            }

        }

        public IActionResult Eliminar(int id)
        {
           DocentesRepository ss = new DocentesRepository();
    
            var clase = ss.GetMenuById(id);
            ss.Delete(clase);
            return RedirectToAction("Docente");
        }
    }
    }
