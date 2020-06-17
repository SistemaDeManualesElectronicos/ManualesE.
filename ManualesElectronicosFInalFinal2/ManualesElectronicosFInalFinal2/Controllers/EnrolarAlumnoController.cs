using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManualesElectronicosFInalFinal2.Models;
using ManualesElectronicosFInalFinal2.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ManualesElectronicosFInalFinal2.Controllers
{
    public class EnrolarAlumnoController : Controller
    {
        AlumnosRepository alu;
        public IActionResult EnrolarAlumno()
        {
            alu = new AlumnosRepository();
            ViewModelAlumnos nom = new ViewModelAlumnos();
            nom.Alumnos = alu.GetAlumnosxNombre();

            return View(nom);

        }
    }
}