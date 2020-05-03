﻿using System;
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
            nom.docentes = doc.GetDocentesxNombre();
            return View(nom);
        }





        [HttpPost]
        public JsonResult Agregar(DocenteViewModel nuevo)
        {



            doc = new DocentesRepository();
            JsonResult json = null;
           
            List<string> errores = doc.ValidarDocentes(nuevo.Docente);
            nuevo.Docente.Nombre = nuevo.Docente.Nombre.ToUpper();



            try
            {
                if (errores.Count() == 0)
                {

                    nuevo.Docente.Eliminado = false;
                    nuevo.Docente.Contraseña = EncriptarLaContraseñaConverter.Encriptar(nuevo.Docente.NumeroDeControl);
                    doc.Insert(nuevo.Docente);
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

            return json;
        }
      






        [HttpPost]
        public JsonResult Eliminar(int id)
        {
            JsonResult json = null;
          

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

        [HttpPost]
        public JsonResult EditarDocentes(DocenteViewModel d)
        {

            JsonResult json = null;
            DocentesRepository doc = new DocentesRepository();
            
            List<string> errores = doc.ValidarDocentes(d.Docente);
            d.Docente.Nombre = d.Docente.Nombre.ToUpper();
            try
            {
                //if (errores.Count() == 0)
                //        {
                if (errores.Count() == 0)
                {
                   doc.Update(d.Docente);
                    json = Json(true);
                }
                for (int i = 0; i < errores.Count; i++)
                {
                    json = Json(errores);
                }
                //  }
            }

            catch (Exception ex)
            {
                json = Json(ex.Message);
            }
            return json;

        }


    }
}


