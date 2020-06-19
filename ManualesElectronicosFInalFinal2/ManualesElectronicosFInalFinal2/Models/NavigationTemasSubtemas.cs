using ManualesElectronicosFInalFinal2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManualesElectronicosFInalFinal2.Models
{
    public class NavigationTemasSubtemas
    {
        public Temas Tema { get; set; }
        public Subtemas Subtema { get; set; }
        public IEnumerable<Temas>  Temas { get; set; }
        public IEnumerable<Subtemas> Subtemas { get; set; }
      


    }
}
