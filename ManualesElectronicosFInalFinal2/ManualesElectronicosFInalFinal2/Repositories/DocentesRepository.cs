using ManualesElectronicosFInalFinal2.Models;

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

        Regex NombreConCaracteresEspeciales = new Regex(@"[ A-Za-zäÄëËïÏöÖüÜáéíóúáéíóúÁÉÍÓÚÂÊÎÔÛâêîôûàèìòùÀÈÌÒÙ.-]+");
        

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

           




            return true;
        }

        public void Insert(DocentesViewModel nuevo)
        {
            Docentes l = new Docentes { Nombre = nuevo.Nombre, NumeroDeControl = nuevo.NumeroDeControl };
            Insert(nuevo);
        }
        ///asd
        public void Update(DocentesViewModel old)
        {
            Docentes m = new Docentes { Nombre = old.Nombre, NumeroDeControl = old.NumeroDeControl };
        }
        public Docentes GetDocenteById(int id)
        {
            return Context.Docentes.FirstOrDefault(x => x.Id == id);
        }


    }
}
