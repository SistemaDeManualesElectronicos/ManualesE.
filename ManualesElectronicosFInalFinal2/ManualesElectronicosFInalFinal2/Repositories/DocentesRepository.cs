using ManualesElectronicosFInalFinal2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ManualesElectronicosFInalFinal2.Repositories
{
    public class DocentesRepository : Repository<Docentes>
    {
        private string error;
        public string Error
        {
            get { return error; }
            set { value = error; }
        }

        public IEnumerable<Docentes> GetDocentesxNombre()
        {
            
            var data = Context.Docentes.OrderBy(x => x.Nombre);
            return data;
        }

        public Docentes GetDocenteById(int id)
        {
            return Context.Docentes.FirstOrDefault(x=>x.Id == id);
          
        }

        public bool ValidarDocentes(Docentes docente)
        {
           
            Regex NombreConCaracteresEspeciales = new Regex(@"[ A-Za-zäÄëËïÏöÖüÜáéíóúáéíóúÁÉÍÓÚÂÊÎÔÛâêîôûàèìòùÀÈÌÒÙ.-]+");
           

            if (!NombreConCaracteresEspeciales.IsMatch(docente.Nombre.ToString()))
            {
                throw new Exception("el nombre no puede ir con caracteres especiales poner caracteres especiales");
            }
            if (string.IsNullOrWhiteSpace(docente.Nombre.ToString()))
            {
                throw new Exception("el nombre no puede ir vacio");
            }
            //if (!NumeroDeControl.IsMatch(docente.NumeroDeControl))
            //{
            //    throw new Exception("El numero de control no puede contener letras");
            //}

            return true;
        }
    }
}
