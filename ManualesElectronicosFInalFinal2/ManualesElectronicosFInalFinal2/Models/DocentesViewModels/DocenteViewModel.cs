using ManualesElectronicosFInalFinal2.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManualesElectronicosFInalFinal2.Models.DocentesViewModels
{
    public class DocenteViewModel:Repository<Docentes>
    {

        public Docentes Docente { get; set; }
        public IEnumerable<Docentes> docentes { get; set; }

        public IEnumerable<Carrera> Carrera { get; set; }

    }
}
