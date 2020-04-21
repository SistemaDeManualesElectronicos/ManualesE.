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
            ViewModelCurso cur = new ViewModelCurso();
            cur.Cursos = cucu.GetAllxNombre();
            return View(cur); ;
        }   

      //  public IActionResult AgregarCurso()
        //{
          //  return View();
        //}
        [HttpPost]
        public JsonResult Agregar(ViewModelCurso c )
        {
            JsonResult json = null;
                CursoRepository cu = new CursoRepository();
              //  List<string> errores = cu.ValidarCurso(c.Curso  );

                //if (errores.Count() == 0)
                //{

                    cu.Insert(c.Curso);
                json = Json(true);
                //}

                //else
                //{
                  //  for (int i = 0; i < errores.Count; i++)
                    //{
                    //json = Json(errores);

                    //}

                //}

            return json;
         


        }

        public JsonResult Eliminar(int Id)
        {
            JsonResult json = null;

            try
            {
                CursoRepository cucu = new CursoRepository();
                var r = cucu.GetById(Id);
                if (r != null)
                {
                    cucu.Delete(r);
                    json = Json(true);
                }
                else
                {
                    json = Json("El curso no existe o ya ha sido eliminado.");
                }
            }
            catch (Exception ex)
            {
                json = Json(ex.Message);
            }
            return json;

        }
     
       


        public IActionResult EditarCurso(int id)
        {
            CursoRepository cu = new CursoRepository();

            var a = cu.GetById(id);

            return View(a);

        }
        [HttpPost]
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
                    Datos.FechaInicio = c.FechaInicio;
                    Datos.FechaFinal = c.FechaFinal;
                    cucu.Update(Datos);
                }

                else
                {
                    for (int i = 0; i < errores.Count(); i++)
                    {
                        ModelState.AddModelError("", errores[i]);
                    }


                }
               
            }
            return RedirectToAction("Cursos");

        }












    }
}