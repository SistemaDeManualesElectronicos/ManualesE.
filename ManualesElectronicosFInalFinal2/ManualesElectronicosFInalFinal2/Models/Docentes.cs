using System;
using System.Collections.Generic;

namespace ManualesElectronicosFInalFinal2.Models
{
    public partial class Docentes
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string NumeroDeControl { get; set; }
        public string Contraseña { get; set; }
        public int? IdCarrera { get; set; }

        public Carrera Carrera { get; set; }
    }
}
