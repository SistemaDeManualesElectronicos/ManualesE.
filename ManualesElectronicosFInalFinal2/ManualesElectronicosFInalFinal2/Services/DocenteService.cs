﻿using ManualesElectronicosFInalFinal2.Models;
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
            sistemaselectronicoContext dr = new sistemaselectronicoContext();
            return dr.Carrera;
        }
       
    }
}
