using System;
using System.Collections.Generic;

namespace ManualesElectronicosFInalFinal2.Models
{
    public partial class Carrera
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public Docentes IdNavigation { get; set; }
    }
}
