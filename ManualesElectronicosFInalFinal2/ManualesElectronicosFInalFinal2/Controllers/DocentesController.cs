using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManualesElectronicosFInalFinal2.Helpers;
using ManualesElectronicosFInalFinal2.Models;
using ManualesElectronicosFInalFinal2.Models.DocentesViewModels;
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
            DocenteViewModel nom = new DocenteViewModel();
            return View(doc.GetDocentesxNombre());
        }





        [HttpPost]
        public JsonResult Agregar(DocenteViewModel nuevo)
        {



            doc = new DocentesRepository();
            JsonResult json = null;
            nuevo.Docente.Nombre = nuevo.Docente.Nombre.ToUpper();

            nuevo.Docente.Eliminado = false;
            nuevo.Docente.Contraseña = EncriptarLaContraseñaConverter.Encriptar(nuevo.Docente.NumeroDeControl);
            doc.Insert(nuevo.Docente);
            json = Json(true);
            //List<string> errores = doc.ValidarDocentes(nuevo);


            //        if (errores.Count() == 0)
            //        {



            //            nuevo.Eliminado = false;
            //            nuevo.Contraseña = EncriptarLaContraseñaConverter.Encriptar(nuevo.NumeroDeControl);
            //            doc.Insert(nuevo);
            //            return RedirectToAction("Docentes");

            //        }


            //else
            //    {
            //     for (int i = 0; i < errores.Count(); i++)
            //    {
            //        ModelState.AddModelError("", errores[i]);

            //    }
            //    return View(nuevo);
            //}

            return json;
        }
        //else
        //{
        //    return View(nuevo);
        //}





        //public IActionResult Eliminar(Docentes d)
        //{
        //    doc = new DocentesRepository();
        //    List<string> errores = doc.ValidarDocentes(d);
        //    var datos = doc.GetDocenteById(d.Id);
        //    return View(datos);
        //}






        [HttpPost]
        public JsonResult Eliminar(int id)
        {
            JsonResult json = null;
            doc = new DocentesRepository();

            try
            {
                DocentesRepository doc = new DocentesRepository();
                var r = doc.GetDocenteById(id);
                if (r != null)
                {
                    doc.Delete(r);
                    json = Json(true);
                }
                else
                {
                    json = Json("El docente no existe o ya ha sido eliminado.");
                }
            }

            catch (Exception ex)
            {
                json = Json(ex.Message);
            }
            //var clase = doc.GetDocenteById(id);
            //doc.Delete(clase);
            return json;
        }

        [HttpPost]

        public JsonResult GetDocente(int id)
        {
            JsonResult json = null;
            DocentesRepository doce = new DocentesRepository();
            var doc = doce.GetById(id);

            if (doc == null)
            {
                json = Json(false);
            }
            else
            {
                json = Json(
                    new
                    {
                        doc.Id,
                        doc.Nombre,
                        doc.NumeroDeControl,
                        doc.IdCarrera,
                        doc.Contraseña
                    }


                    );
            }
            return json;

        }


        //public IActionResult EditarDocentes(int id)
        //{
        //    doc = new DocentesRepository();
        //    var datos = doc.GetById(id);
        //    return View(id);
        //}


        public IActionResult EditarDocentes(DocenteViewModel d)
        {

            //    if (ModelState.IsValid)
            //    {
            //        doc = new DocentesRepository();
            //        List<string> errores = doc.ValidarDocentes(d);
            //        for (int i = 0; i < errores.Count(); i++)
            //        {
            //            ModelState.AddModelError("", errores[i]);
            //        }

            //        if (errores.Count() == 0)
            //        {



            //            var Datos = doc.GetById(d.Id);
            //            Datos.Nombre = d.Nombre;
            //            Datos.NumeroDeControl = d.NumeroDeControl;
            //            Datos.Contraseña = EncriptarLaContraseñaConverter.Encriptar(Datos.NumeroDeControl);
            //            Datos.IdCarrera = d.IdCarrera;
            //            doc.Update(Datos);
            //            return RedirectToAction("Docentes");
            //        }

            //        }
            //        else
            //        {

            //            return View(d);
            //        }
            //        return View(d);

            //}

            JsonResult json = null;
            DocentesRepository al = new DocentesRepository();


            //List<string> errores = alu.ValidarAlumnos(e.Alumno);
            //if (errores.Count() == 0)
            //        {
            al.Update(d.Docente);
            json = Json(true);

            //  }

            return json;


        }
    }
}

