using System;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManualesElectronicosFInalFinal2.models;

namespace ManualesElectronicosFInalFinal2.Models
{
    public class ViewModelAlumnos
    {

        public  Alumnos Alumno { get; set; }
        public IEnumerable<Alumnos> Alumnos { get; set; }

        public IEnumerable<Carrera> Carrera { get; set; }
    }
}
