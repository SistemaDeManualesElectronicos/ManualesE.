using System;
using System.Collections.Generic;

namespace ManualesElectronicosFInalFinal2.models
{
    public partial class Temas
    {
        public Temas()
        {
            Subtemas = new HashSet<Subtemas>();
        }

        public int Id { get; set; }
        public string Encabezado { get; set; }
       
        public ICollection<Subtemas> Subtemas { get; set; }

     
    }
}
