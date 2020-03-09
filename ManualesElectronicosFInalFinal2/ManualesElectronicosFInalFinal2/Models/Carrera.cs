using System;
using System.Collections.Generic;

namespace ManualesElectronicosFInalFinal2.Models
{
    public partial class Carrera
    {
        public Carrera()
        {
            Alumnos = new HashSet<Alumnos>();
            Docentes = new HashSet<Docentes>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public ICollection<Alumnos> Alumnos { get; set; }
        public ICollection<Docentes> Docentes { get; set; }
    }
}
