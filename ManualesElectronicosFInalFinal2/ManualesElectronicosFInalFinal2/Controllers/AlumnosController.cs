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

                List<string> errores = alu.ValidarAlumnos(nuevo);
                for (int i = 0; i < errores.Count; i++)
                {
                    ModelState.AddModelError("", errores[i]);
                }

                if(errores.Count()== 0){
                    nuevo.Nombre = nuevo.Nombre.ToUpper();
                    nuevo.Eliminado = false;
                    nuevo.Contraseña = EncriptarLaContraseñaConverter.Encriptar(nuevo.NumeroControl);
                    alu.Insert(nuevo);
                    return RedirectToAction("Alumnos");
                }


          
                return View(nuevo);
            }
            else
            {
                return View(nuevo);
            }
         
        }

      
        public IActionResult Eliminar(Alumnos c)
        {
            AlumnosRepository alu = new AlumnosRepository();

       
                    var r = alu.GetAlumnoById(c.Id);
                    alu.Delete(r);
                    return RedirectToAction("Alumnos");
         
        }

        public IActionResult EditarAlumnos(int id)
        {
            AlumnosRepository al = new AlumnosRepository();

            var a = al.GetAlumnoById(id);

                return View(a);
            
        }
        [HttpPost]

        public IActionResult EditarAlumnos(Alumnos d)
        {
            AlumnosRepository alu = new AlumnosRepository();
            if (ModelState.IsValid)
            {
                List<string> errores = alu.ValidarAlumnosEditar(d);
                for (int i = 0; i < errores.Count; i++)
                {
                    ModelState.AddModelError("", errores[i]);
                }
                if (errores.Count() == 0)
                {
                    var Datos = alu.GetById(d.Id);
                    Datos.Nombre = d.Nombre;
                    Datos.IdCarrera = d.IdCarrera;
                    // nuevo.Contraseña = EncriptarLaContraseñaConverter.Encriptar(nuevo.NumeroControl);
                    alu.Update(Datos);
                    return RedirectToAction("Alumnos");
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