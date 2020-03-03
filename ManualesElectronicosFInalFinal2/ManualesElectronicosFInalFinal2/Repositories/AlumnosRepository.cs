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
        public IEnumerable<string> GetNombresAlumnos()
        {
            var data = GetAll().OrderBy(x => x.Nombre).Select(x => x.Nombre);
            return data;
        }


        Regex NombreConCaracteresEspeciales = new Regex(@"[ A-Za-zäÄëËïÏöÖüÜáéíóúáéíóúÁÉÍÓÚÂÊÎÔÛâêîôûàèìòùÀÈÌÒÙ.-]+");
        Regex NumeroDeControl = new Regex(@"/^[0-9]+$/");

        public bool ValidarAlumnos(Alumnos alumnos)
        {
           

            if (!NombreConCaracteresEspeciales.IsMatch(alumnos.Nombre.ToString()))
            {
                throw new Exception("el nombre no puede ir con caracteres especiales poner caracteres especiales");
            }
            if (string.IsNullOrWhiteSpace(alumnos.Nombre.ToString()))

            {
                throw new Exception("el nombre no puede ir vacio");


            }

            return true;
        }
    }
}