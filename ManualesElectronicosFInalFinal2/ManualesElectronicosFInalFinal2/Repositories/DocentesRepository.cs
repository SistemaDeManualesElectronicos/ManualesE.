using ManualesElectronicosFInalFinal2.Models;
using ManualesElectronicosFInalFinal2.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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

        Regex NombreConCaracteresEspeciales = new Regex(@"^[a-zA-Z]+$");
        Regex NumeroDeControl = new Regex(@"[0-9][0-9][1][GDMTAP][0DC]\d\d\d+$");

        public bool ValidarDocentes(Docentes docente) 
        {
            if (!NombreConCaracteresEspeciales.IsMatch(docente.Nombre.ToString()))
            {
                throw new Exception("el nombre no puede ir con caracteres especiales poner caracteres especiales");
            }
            if (string.IsNullOrWhiteSpace(docente.Nombre.ToString()))
            {
                throw new Exception("el nombre no puede ir vacio");
            }
            
            if (!NumeroDeControl.IsMatch(docente.NumeroDeControl.ToString()))
            {
                throw new Exception("El patron de numero de control es incorrecto");
            }


            
          

            return true;
        }

        public void Insert(DocentesViewModel nuevo)
        {
            Docentes l = new Docentes { Nombre = nuevo.Nombre, Carrera = nuevo.Carrera, NumeroDeControl = nuevo.NumeroDeControl, Contraseña = nuevo.Contraseña, Id = nuevo.Id  };
            Insert(nuevo);
        }
        ///asd
        public void Update(DocentesViewModel old)
        {
            Docentes m = new Docentes { Id = old.Id, Nombre = old.Nombre, Carrera = old.Carrera, NumeroDeControl = old.NumeroDeControl, Contraseña =old.Contraseña   };
        }
        public Docentes GetMenuById(int id)
        {
            return Context.Docentes.FirstOrDefault(x => x.Id == id);
        }


    }
}
