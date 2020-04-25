using ManualesElectronicosFInalFinal2.Models;
using ManualesElectronicosFInalFinal2.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ManualesElectronicosFInalFinal2.Services
{
    public class AlumnosService
    {


       
        public IEnumerable<Carrera> GeTcarreritas()
        {
            itesrcne_manualesContext dr = new itesrcne_manualesContext();
            return dr.Carrera;
        }
    }
}
