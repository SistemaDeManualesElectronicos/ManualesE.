using System;
using System.Collections.Generic;

namespace ManualesElectronicosFInalFinal2.Models
{
    public partial class Subtemas
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string ContenidoHtml { get; set; }
        public string ReferenciasApa { get; set; }
        public string ListadeRecursos { get; set; }
    }
}
