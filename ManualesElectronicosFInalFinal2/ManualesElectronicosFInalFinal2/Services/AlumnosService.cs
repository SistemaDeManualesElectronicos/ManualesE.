using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManualesElectronicosFInalFinal2.Models;
using ManualesElectronicosFInalFinal2.Repositories;

namespace ManualesElectronicosFInalFinal2.Services
{
    public class AlumnosService
    {


        public IEnumerable<Carrera> GetCarreras()
        {
            sistemaselectronicoContext dr = new sistemaselectronicoContext();
            return dr.Carrera;
        }
    }
}
