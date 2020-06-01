using ManualesElectronicosFInalFinal2.models;
using ManualesElectronicosFInalFinal2.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManualesElectronicosFInalFinal2.Services
{
    public class TemasServices
    {

        public IEnumerable<string> GetNombreSubtemas()
        {
            SubtemasRepository repos = new SubtemasRepository();
            return repos.GetNombresSubtemas();
        }

        public IEnumerable<Subtemas> Tema { get; set; }
    }
}
