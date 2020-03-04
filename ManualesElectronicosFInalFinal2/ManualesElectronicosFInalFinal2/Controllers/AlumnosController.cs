using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManualesElectronicosFInalFinal2.Models;
using ManualesElectronicosFInalFinal2.Repositories;
using Microsoft.AspNetCore.Mvc;
using ManualesElectronicosFInalFinal2.Helpers;


namespace ManualesElectronicosFInalFinal2.Controllers
{
    
    public class AlumnosController : Controller
    {

        AlumnosRepository alu;
        public IActionResult Alumnos()
        {
            alu = new AlumnosRepository();
            return View(alu.GetAlumnosxNombre());
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

                AlumnosRepository alu = new AlumnosRepository();

                try
                {

                    if (alu.ValidarAlumnos(nuevo))
                    {
                        nuevo.Eliminado = false;
                        nuevo.Contraseña = EncriptarLaContraseñaConverter.Encriptar(nuevo.NumeroControl);
                        alu.Insert(nuevo);
                        return RedirectToAction("Alumnos");
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
            return View(r);
            
        }
        [HttpPost]
        public IActionResult Eliminar(Alumnos c)
        {

            AlumnosRepository repos = new AlumnosRepository();
            var r = repos.GetAlumnoById(c.Id);
            repos.Delete(r);
            return RedirectToAction("Alumnos");
        }

     
        public IActionResult EditarAlumnos(Alumnos d)
        {

            if (ModelState.IsValid)
            {
                AlumnosRepository al = new AlumnosRepository();
            
                try
                {
                   
                    if (al.ValidarAlumnos(d))
                    {
                        var Datos = al.GetById(d.Nombre);
                        Datos.Nombre = d.Nombre;
                        Datos.NumeroControl = d.NumeroControl;
                        Datos.Contraseña = EncriptarLaContraseñaConverter.Encriptar(Datos.NumeroControl);
                        Datos.IdCarrera = d.IdCarrera;
                        al.Update(Datos);
                        return RedirectToAction("Alumnos");
                    }

                }

                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View(d);
                }
                return View(d);

            }

            else
            {
                return View(d);
            }

        }

    }
}