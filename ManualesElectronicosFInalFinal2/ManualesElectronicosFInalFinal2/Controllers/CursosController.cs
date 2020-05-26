using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
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

            try { 
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

        }

            catch (Exception )
            {
                json = Json("Ah ocurrido un error, porfavor actualice la pagina y vuelva a intntarlo, si el error persiste comuniquese con soporte tecnico");
    }
            return json;
         


        }
        [HttpPost]
        public JsonResult Eliminar(int Id)
        {
            JsonResult json = null;

            try
            {
                CursoRepository cucu = new CursoRepository();
                var r = cucu.GetCursoById(Id);
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

            var inicio = alu.FechaInicio.GetValueOrDefault().ToString("yyyy-MM-dd");
            var final = alu.FechaFinal.GetValueOrDefault().ToString("yyyy-MM-dd");
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
                        inicio,
                        final,
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
            CursoRepository cucu = new CursoRepository();
            c.Curso.Nombre = c.Curso.Nombre.ToUpper();
            List<string> errores = cucu.ValidarCurso(c.Curso);

            try
            {
                if (errores.Count() == 0)
                {
                    if (c != null)
                    {
                     //   var Datos = cucu.GetCursoById(c.Curso.Id);

                        c.Curso.Nombre = c.Curso.Nombre.ToUpper();
                        cucu.Update(c.Curso);
                        json = Json(true);
                    }
                    else
                    {
                        json = Json("El Curso no existe o ya ha sido eliminado.");
                    }
                }

                for (int i = 0; i < errores.Count; i++)
                {
                    json = Json(errores);
                }
            }
            catch (Exception)
            {
                json = Json("Ah ocurrido un error, porfavor actualice la pagina y vuelva a intntarlo,a si el error persiste comuniquese con soporte tecnico");
            }

            return json;

        }












    }
}