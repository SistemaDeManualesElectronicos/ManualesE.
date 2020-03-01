using ManualesElectronicosFInalFinal2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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


        public bool ValidarAlumnos(Alumnos alumnos, out List<string> errores)
        {

            errores = new List<string>();

            if (!NombreConCaracteresEspeciales.IsMatch(alumnos.Nombre.ToString()))
            {
                errores.Add("El nombre no puede ir con caracteres especiales poner caracteres especiales");
            }
            if (string.IsNullOrWhiteSpace(alumnos.Nombre.ToString()))
            {
                errores.Add("El nombre no puede ir vacio");
            }
          //  if (!NumeroDeControl.IsMatch(alumnos.NumeroDeControl))
            //{
             //   throw new Exception("El numero de control no puede contener letras");
           // }


            return true;
        }


    }
}
