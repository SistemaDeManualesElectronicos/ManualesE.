using ManualesElectronicosFInalFinal2.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManualesElectronicosFInalFinal2.Models
{
    public class ViewModelTemas
    {
        public Temas Temas { get; set; }

        public IEnumerable<Temas> Tema { get; set; }
    }
}
