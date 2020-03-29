using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManualesElectronicosFInalFinal2.Models;
using ManualesElectronicosFInalFinal2.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ManualesElectronicosFInalFinal2.Controllers
{
    public class TemasController : Controller
    {
        TemasRepository temas;
        public IActionResult Temas()
        {
            temas = new TemasRepository();
            return View(temas.GetTemascxNombre());
        }


        public IActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Agregar(Temas t)
        {
            if (ModelState.IsValid)
            {
                temas = new TemasRepository();
                List<string> errores = temas.Validacion(t);
                if (errores.Count() == 0)
                {
                    temas.Insert(t);
                    RedirectToAction("Temas");
                }
                else
                {
                    for (int i = 0; i < errores.Count(); i++)
                    {
                        ModelState.AddModelError("", errores[i]);

                    }
                    return View();
                }

            }

            else
            {
                return View();
            }
            return View();
        }

        public IActionResult Eliminar(Temas d)
        {
            temas = new TemasRepository();
            List<string> errores = temas.Validacion(d);
            var datos = temas.GetTemabyId(d.Id);
            return View(datos);
        }


        [HttpPost]
        public IActionResult Eliminar(int id)
        {
           temas = new TemasRepository();

            var clase = temas.GetTemabyId(id);
            temas.Delete(clase);
            return RedirectToAction("Temas");
        }


        public IActionResult EditarTemas(int id)
        {
           temas = new TemasRepository();
            var datos = temas.GetById(id);
            return View(id);
        }


        public IActionResult EditarTemas(Temas d)
        {

            if (ModelState.IsValid)
            {
                temas = new TemasRepository();
                List<string> errores = temas.Validacion(d);
                for (int i = 0; i < errores.Count(); i++)
                {
                    ModelState.AddModelError("", errores[i]);
                }

                if (errores.Count() == 0)
                {



                    var Datos = temas.GetById(d.Id);
                    Datos.Encabezado = d.Encabezado;
                    Datos.IdSubTema = d.IdSubTema;
                    temas.Update(Datos);
                    return RedirectToAction("Temas");
                }

            }
            else
            {

                return View(d);
            }
            return View(d);

        }
    }
}