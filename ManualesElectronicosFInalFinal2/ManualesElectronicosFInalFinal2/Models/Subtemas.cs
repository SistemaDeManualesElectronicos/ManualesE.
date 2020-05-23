using System;
using System.Collections.Generic;

namespace ManualesElectronicosFInalFinal2.models
{
    public partial class Subtemas
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string ContenidoHtml { get; set; }
        public string ReferenciasApa { get; set; }
        public string ListadeRecursos { get; set; }
        public int? IdTemas { get; set; }

        public Temas IdTemasNavigation { get; set; }
    }
}
