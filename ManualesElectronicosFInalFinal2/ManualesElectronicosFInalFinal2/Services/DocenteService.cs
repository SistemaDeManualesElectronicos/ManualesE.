using ManualesElectronicosFInalFinal2.Models;
using ManualesElectronicosFInalFinal2.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManualesElectronicosFInalFinal2.Services
{
    public class DocenteService
    {
        public IEnumerable<Carrera> GetCarreras()
        {
            sistemaelectronico123Context dr = new sistemaelectronico123Context();
            return dr.Carrera;
        }
       
    }
}
