using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManualesElectronicosFInalFinal2.Helpers;
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


            if (ModelState.IsValid)
            {

                doc = new DocentesRepository();

                try
                {
                    {
                        if (doc.ValidarDocentes(nuevo))
                        {
                             nuevo.Eliminado = false;
                             nuevo.Contraseña = EncriptarLaContraseñaConverter.Encriptar(nuevo.NumeroDeControl);
                             doc.Insert(nuevo);
                             return RedirectToAction("Docentes");
                        }

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

        public IActionResult Eliminar(Docentes d)
        {
            doc = new DocentesRepository();
            var datos = doc.GetDocenteById(d.Id);
            return View(datos);
        }

        [HttpPost]
        public IActionResult Eliminar(int id)
        {
            doc = new DocentesRepository();
            var clase = doc.GetDocenteById(id);
            doc.Delete(clase);
            return RedirectToAction("Docentes");
        }




        public IActionResult EditarDocentes(int id)
        {
            DocentesRepository ss = new DocentesRepository();
            var clase = ss.GetDocenteById(id);
            ss.Update(clase);

            if (clase == null)
            {
                return RedirectToAction("Index");

            }
            else
            {

                return View(clase);

            }

        }



    }
}

