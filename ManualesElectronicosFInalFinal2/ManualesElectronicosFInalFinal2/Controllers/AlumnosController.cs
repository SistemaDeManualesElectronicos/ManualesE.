using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManualesElectronicosFInalFinal2.Models;
using ManualesElectronicosFInalFinal2.Repositories;
using Microsoft.AspNetCore.Mvc;
using ManualesElectronicosFInalFinal2.Helpers;
using Newtonsoft.Json;

namespace ManualesElectronicosFInalFinal2.Controllers
{

    public class AlumnosController : Controller
    {//

        AlumnosRepository alu;
        public IActionResult Alumnos()
        {
            alu = new AlumnosRepository();
            ViewModelAlumnos nom = new ViewModelAlumnos();
            nom.Alumnos = alu.GetAlumnosxNombre();

            return View(nom);


        }

        //public IActionResult Agregar()
        //{
        //    return View();
        //}
        [HttpPost]
        public JsonResult Agregar(ViewModelAlumnos nuevo)
        {
            
                alu = new AlumnosRepository();
                JsonResult json = null;
                List<string> errores = alu.ValidarAlumnos(nuevo.Alumno);
                nuevo.Alumno.Nombre = nuevo.Alumno.Nombre.ToUpper();
            try
            {
                if (errores.Count() == 0)
                {

                    nuevo.Alumno.Eliminado = false;
                    nuevo.Alumno.Contraseña = EncriptarLaContraseñaConverter.Encriptar(nuevo.Alumno.NumeroControl);
                    alu.Insert(nuevo.Alumno);
                    json = Json(true);
                }

                for (int i = 0; i < errores.Count; i++)
                {
                    json = Json(errores);
                }
            }

            catch (Exception ex)
            {
                json = Json(ex.Message);
            }
            //if (ModelState.IsValid)
            //{

            //    AlumnosRepository alu = new AlumnosRepository();

            //    List<string> errores = alu.ValidarAlumnos(nuevo);
            //    for (int i = 0; i < errores.Count; i++)
            //    {
            //        ModelState.AddModelError("", errores[i]);
            //    }

            //    if (errores.Count() == 0)
            //    {

            //}
            return json;
        }
        [HttpPost]

        public JsonResult Eliminar(int Id)
        {
           
            JsonResult json = null;
            try
            {
               AlumnosRepository alu = new AlumnosRepository();
                var r = alu.GetAlumnoById(Id);
                if (r != null)
                {
                    alu.Delete(r);
                    json = Json(true);
                }
                else
                {
                    json = Json("El alumno no existe o ya ha sido eliminado.");
                }
            }
            catch (Exception ex)
            {
                json = Json(ex.Message);
            }


            return json;

        }
        [HttpPost]

        public JsonResult GetAlumno(int id)
        {
            JsonResult json = null;
            AlumnosRepository al = new AlumnosRepository();
            var alu = al.GetAlumnoById(id);

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
                        alu.NumeroControl,
                        alu.IdCarrera
                    }


                    );
            }
            return json;

        }
        [HttpPost]
        public JsonResult Editar(ViewModelAlumnos e)
        {
            JsonResult json = null;
            AlumnosRepository al = new AlumnosRepository();
            e.Alumno.Nombre = e.Alumno.Nombre.ToUpper();
            List<string> errores = al.ValidarAlumnos(e.Alumno);

            try
            {
                //if (errores.Count() == 0)
                //        {
                if (errores.Count() == 0)
                {
                    al.Update(e.Alumno);
                    json = Json(true);
                }
                for (int i = 0; i < errores.Count; i++)
                {
                    json = Json(errores);
                }
                //  }
            }

            catch(Exception ex)
            {
                json = Json(ex.Message);
            }
                return json;

        }


        //public IActionResult EditarAlumnos(Alumnos d)
        //{
        //    AlumnosRepository alu = new AlumnosRepository();
        //    if (ModelState.IsValid)
        //    {
        //        List<string> errores = alu.ValidarAlumnosEditar(d);
        //        for (int i = 0; i < errores.Count; i++)
        //        {
        //            ModelState.AddModelError("", errores[i]);
        //        }
        //        if (errores.Count() == 0)
        //        {
        //            var Datos = alu.GetById(d.Id);
        //            Datos.Nombre = d.Nombre;
        //            Datos.IdCarrera = d.IdCarrera;
        //            // nuevo.Contraseña = EncriptarLaContraseñaConverter.Encriptar(nuevo.NumeroControl);
        //            alu.Update(Datos);
        //            return RedirectToAction("Alumnos");
        //        }









        //        return View(d);

        //    }

        //    else
        //    {
        //        return View(d);
        //    }

        //}
    }
    
}