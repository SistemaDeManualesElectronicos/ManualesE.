using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManualesElectronicosFInalFinal2.Models;
using ManualesElectronicosFInalFinal2.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ManualesElectronicosFInalFinal2.Controllers
{
    public class CursosController : Controller
    {
        CursoRepository cucu;
        public IActionResult Cursos()
        {
            cucu = new CursoRepository();
            return View(cucu.GetAll()); ;
        }   

        public IActionResult AgregarCurso()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AgregarCurso(Curso c )
        {
            if (ModelState.IsValid)
            {
                CursoRepository cu = new CursoRepository();
                List<string> errores = cu.ValidarCurso(c);

                if (errores.Count() == 0)
                {

                    cu.Insert(c);
                    return RedirectToAction("Cursos");
                }

                else
                {
                    for (int i = 0; i < errores.Count; i++)
                    {
                        ModelState.AddModelError("", errores[i]);

                    }

                }
             
                return View(c);
               
            }
            else
            {
                return View(c);
            }



        }

        public IActionResult Eliminar(Curso d)
        {
            cucu = new CursoRepository();
            List<string> errores = cucu.ValidarCurso(d);
            var datos = cucu.GetCursoById(d.Id);
            return View(datos);
        }


        [HttpPost]
        public IActionResult Eliminar(int id)
        {
            cucu = new CursoRepository();
            var clase = cucu.GetCursoById(id);
            cucu.Delete(clase);
            return RedirectToAction("Docentes");
        }


        public IActionResult EditarCurso(Curso c)
        {

            if (ModelState.IsValid)
            {

                cucu = new CursoRepository();
                List<string> errores = cucu.ValidarCurso(c);



                if(errores.Count() == 0)
                {
                    var Datos = cucu.GetCursoById(c.Id);

                    Datos.Nombre = c.Nombre;
                    Datos.Clave = c.Clave;   
                }

                else
                {
                    for (int i = 0; i < errores.Count(); i++)
                    {
                        ModelState.AddModelError("", errores[i]);
                    }


                }
               
            }
            return View(c);

        }












    }
}