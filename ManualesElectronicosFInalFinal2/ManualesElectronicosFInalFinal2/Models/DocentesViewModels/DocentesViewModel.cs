using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManualesElectronicosFInalFinal2.Models.DocentesViewModels
{
    public class DocentesViewModel
    {

        public string Nombre { get; set; }
        public string NumeroDeControl { get; set; }
        public  List<Carrera> Carreras { get; set; }
        
    }
}
