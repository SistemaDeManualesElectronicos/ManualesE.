using System;
using System.Collections.Generic;

namespace ManualesElectronicosFInalFinal2.Models
{
    public partial class Carrera
    {
        public Carrera()
        {
            Docentes = new HashSet<Docentes>();
            Alumnos = new HashSet<Alumnos>();
        }

        
        public int Id { get; set; }
        public string Nombre { get; set; }

        public ICollection<Docentes> Docentes { get; set; }
        public ICollection<Alumnos> Alumnos { get; set; }
    }
}
