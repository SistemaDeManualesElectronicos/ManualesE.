using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManualesElectronicosFInalFinal2.Models;
using ManualesElectronicosFInalFinal2.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ManualesElectronicosFInalFinal2.Controllers
{
    public class AlumnosController : Controller
    {
        public IActionResult Alumnos()
        {
            AlumnosRepository doc = new AlumnosRepository();
            return View(doc.GetAll());
            

            
        }
        public IActionResult Agregar()
        {
            return View();
        }

        [HttpPost]

		public IActionResult Agregar(Alumnos nuevo)
		{
            if (ModelState.IsValid)
            {

                AlumnosRepository doc = new AlumnosRepository();

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
        public IActionResult Eliminar(int id)
        {
            AlumnosRepository repos = new AlumnosRepository();
            var r = repos.GetById(id);

            if (r == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(r);
            }
        }
        [HttpPost]
        public IActionResult Eliminar(Alumnos c)
        {
            AlumnosRepository repos = new AlumnosRepository();
            var r = repos.GetById(c.Id);

            repos.Delete(r);
            return RedirectToAction("Docentes");


        }

  

}