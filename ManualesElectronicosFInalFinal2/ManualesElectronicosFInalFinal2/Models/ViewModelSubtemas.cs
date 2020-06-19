using ManualesElectronicosFInalFinal2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManualesElectronicosFInalFinal2.Models
{
    public class ViewModelSubtemas
    {

        public  Subtemas Subtemas { get; set; }

        public IEnumerable<Subtemas> Subtema { get; set; }
    }
}
