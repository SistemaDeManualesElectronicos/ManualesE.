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
            
            return View(doc.GetAll());
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
                            doc.InsertRepository(nuevo);

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

            DocentesRepository ss = new DocentesRepository();

            var clase = ss.GetDocenteById(d.Id);
            return View();
        }

        [HttpPost]
        public IActionResult Eliminar(int id)
        {
            DocentesRepository ss = new DocentesRepository();

            var clase = ss.GetDocenteById(id);
            ss.Delete(clase);
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

        //[HttpPost]

        //public IActionResult EditarDocente(DocentesViewModel vi)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        DocentesRepository doc = new DocentesRepository();
        //        var v = doc.GetDDocenteByNombre(vi.Nombre);
        //        if (doc == null)
        //        {
        //            doc.Update(vi);
        //            return RedirectToAction("Index");
        //        }
        //        else if (v.Id == vi.NumeroDeControl)
        //        {
        //               v.Nombre= vi.Nombre;
        //              doc.Update(v);
        //            doc.Update(vi);
        //            return RedirectToAction("Index");
        //        }
        //        else {
        //        MdelState.AddModelError("","Ya existe un nombre igual. Porfavor escriba otro nombre");
        //            return view(vi);

        //        }

        //    }




    }
}

