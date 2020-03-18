using System;
using System.Collections.Generic;

namespace ManualesElectronicosFInalFinal2.Models
{
    public partial class Curso
    {
        public int Id { get; set; }
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFinal { get; set; }
        public int? IdDocente { get; set; }
        public int? IdTemas { get; set; }
    }
}
