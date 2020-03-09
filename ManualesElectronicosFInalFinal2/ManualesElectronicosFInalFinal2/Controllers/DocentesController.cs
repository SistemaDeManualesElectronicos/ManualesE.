using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManualesElectronicosFInalFinal2.Helpers;
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

            return View(doc.GetDocentesxNombre());
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
                List<string> errores = doc.ValidarDocentes(nuevo);
                

                if (errores.Count() == 0)
                {



                    nuevo.Eliminado = false;
                    nuevo.Contraseña = EncriptarLaContraseñaConverter.Encriptar(nuevo.NumeroDeControl);
                    doc.Insert(nuevo);
                    return RedirectToAction("Docentes");

                }


                else
                {
for (int i = 0; i < errores.Count(); i++)
                {
                    ModelState.AddModelError("", errores[i]);
                    
                }
                    return View(nuevo);
                }

            }
            else
            {
                return View(nuevo);
            }

        }

        public IActionResult Eliminar(Docentes d)
        {
            doc = new DocentesRepository();
            List<string> errores = doc.ValidarDocentes(d);
            var datos = doc.GetDocenteById(d.Id);
            return View(datos);
        }

        [HttpPost]
        public IActionResult Eliminar(int id)
        {
            doc = new DocentesRepository();
            var clase = doc.GetDocenteById(id);
            doc.Delete(clase);
            return RedirectToAction("Docentes");
        }





        public IActionResult EditarDocentes(Docentes d)
        {

            if (ModelState.IsValid)
            {
                doc = new DocentesRepository();
                List<string> errores = doc.ValidarDocentes(d);
                for (int i = 0; i < errores.Count(); i++)
                {
                    ModelState.AddModelError("", errores[i]);
                }

                if (errores.Count() == 0)
                {



                    var Datos = doc.GetById(d.Id);
                    Datos.Nombre = d.Nombre;
                    Datos.NumeroDeControl = d.NumeroDeControl;
                    Datos.Contraseña = EncriptarLaContraseñaConverter.Encriptar(Datos.NumeroDeControl);
                    Datos.IdCarrera = d.IdCarrera;
                    doc.Update(Datos);
                    return RedirectToAction("Docentes");
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

