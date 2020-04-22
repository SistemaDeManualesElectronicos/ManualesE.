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
                List<string> errores = cu.ValidarCurso(c.Curso  );

            if (errores.Count() == 0)
            {

                cu.Insert(c.Curso);
                json = Json(true);
            }

            else
            {
                for (int i = 0; i < errores.Count; i++)
                {
                    json = Json(errores);

                 }

            }

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


        public JsonResult GetCurso(int id)
        {
            JsonResult json = null;
            CursoRepository cu = new CursoRepository();
            var alu = cu.GetById(id);

            if (alu == null)
            {
                json = Json(false);
            }
            else
            {
                json = Json(
                    new
                    {
                        alu.Id,
                        alu.Nombre,
                        alu.FechaInicio,
                        alu.FechaFinal
                    }


                    );
            }
            return json;

        }
        [HttpPost]
        public JsonResult EditarCurso(ViewModelCurso c)
        {

            JsonResult json = null;

            cucu = new CursoRepository();
                List<string> errores = cucu.ValidarCurso(c.Curso);



                if(errores.Count() == 0)
                {
                    var Datos = cucu.GetCursoById(c.Curso.Id);

                    Datos.Nombre = c.Curso.Nombre;
                    Datos.Clave = c.Curso.Clave;
                    Datos.FechaInicio = c.Curso.FechaInicio;
                    Datos.FechaFinal = c.Curso.FechaFinal;
                    cucu.Update(Datos);
                Json(true);
                }

                else
                {
                    for (int i = 0; i < errores.Count(); i++)
                    {
                    Json(errores);
                    }


                }


            return json;

        }












    }
}