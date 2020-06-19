using System;
using System.Collections.Generic;

namespace ManualesElectronicosFInalFinal2.Models
{
    public partial class Alumnos
    {
        public Alumnos()
        {
            Curso = new HashSet<Curso>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string NumeroControl { get; set; }
        public string Contraseña { get; set; }
        public int? IdCarrera { get; set; }
        public bool? Eliminado { get; set; }
        public int? IdCurso { get; set; }

        public Carrera IdCarreraNavigation { get; set; }
        public ICollection<Curso> Curso { get; set; }
    }
}
