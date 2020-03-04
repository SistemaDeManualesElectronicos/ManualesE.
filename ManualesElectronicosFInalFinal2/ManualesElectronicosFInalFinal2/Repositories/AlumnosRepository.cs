using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using ManualesElectronicosFInalFinal2.Models;

namespace ManualesElectronicosFInalFinal2.Repositories
{
    public class AlumnosRepository : Repository<Alumnos>
    {
       public IEnumerable<Alumnos> GetAlumnosxNombre()
        {
            
            var data = Context.Alumnos.OrderBy(x => x.Nombre);
            return data;
        }

        public Alumnos GetAlumnoById(int id)
        {
            return Context.Alumnos.FirstOrDefault(x => x.Id == id);

        }

        Regex NombreConCaracteresEspeciales = new Regex(@"[ A-Za-zäÄëËïÏöÖüÜáéíóúáéíóúÁÉÍÓÚÂÊÎÔÛâêîôûàèìòùÀÈÌÒÙ.-]+");
        Regex NumeroDeControl = new Regex(@"/^[0-9]+$/");
        Regex NumeroDeControlA = new Regex(@"()");
        public bool ValidarAlumnos(Alumnos alumnos)
        {
           

            if (!NombreConCaracteresEspeciales.IsMatch(alumnos.Nombre.ToString()))
            {
                throw new Exception("El Nombre no puede ir con caracteres especiales poner caracteres especiales");
            }
            if (string.IsNullOrWhiteSpace(alumnos.Nombre.ToString()))

            {
                throw new Exception("El Nombre no puede ir vacio");


            }

            return true;
        }
    }
}