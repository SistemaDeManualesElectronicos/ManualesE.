using ManualesElectronicosFInalFinal2.Models;
using ManualesElectronicosFInalFinal2.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManualesElectronicosFInalFinal2.Repositories
{
    public class DocentesRepository:Repository<Docentes>
    {
        public IEnumerable<Docentes> GetDocentesxNombre()
        {
            var data = GetAll();
            return data;
        }

        public void Insert(DocentesViewModel nuevo)
        {
            Docentes l = new Docentes { Nombre = nuevo.Nombre, Carrera = nuevo.Carrera, NumeroDeControl = nuevo.NumeroDeControl, Contraseña = nuevo.Contraseña, Id = nuevo.Id  };
            Insert(nuevo);
        }
        public void Update(DocentesViewModel old)
        {
            Docentes m = new Docentes { Id = old.Id, Nombre = old.Nombre, Carrera = old.Carrera, NumeroDeControl = old.NumeroDeControl, Contraseña =old.Contraseña  };
        }
    }
}
