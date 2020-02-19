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
        //hjkl

        public IActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Agregar(Docentes nuevo)
        {
          

            if (ModelState.IsValid)
            {
                if (doc == null)
                {

                    doc = new DocentesRepository();
                }
                try
                {
                    if (doc.ValidarDocentes(nuevo))
                    {
                        doc.Insert(nuevo);

                        return RedirectToAction("Docentes");
                    }
                  
                }

                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View(nuevo);
                }
                return View(nuevo);
            }
            else
            {
                return View(nuevo);
            }

        }

        public IActionResult Eliminar( Docentes d)
        {

            DocentesRepository ss = new DocentesRepository();

            var clase = ss.GetMenuById(d.Id);
            return View(clase);
        }

        [HttpPost]
        public IActionResult Eliminar(int id)
        {
           DocentesRepository ss = new DocentesRepository();
    
            var clase = ss.GetMenuById(id);
            ss.Delete(clase);
            return RedirectToAction("Docentes");
        }
        



        public IActionResult EditarDocentes(int id)
        {
            DocentesRepository ss = new DocentesRepository();
            var clase = ss.GetById(id);
            ss.Update(clase);


            return View(clase );
        }
    }
    }
