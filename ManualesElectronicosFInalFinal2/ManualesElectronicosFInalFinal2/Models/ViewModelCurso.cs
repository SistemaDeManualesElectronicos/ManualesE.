using ManualesElectronicosFInalFinal2.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManualesElectronicosFInalFinal2.Models
{
    public class ViewModelCurso
    {
        public Curso Curso { get; set; }
        public IEnumerable<Curso> Cursos { get; set; }
        public IEnumerable<Carrera> Carrera { get; set; }
    }
}
