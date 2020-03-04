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
         
        Regex NumeroDeControl = new Regex(@"/^[0-9]+$/");
       
        public bool ValidarAlumnos(Alumnos alumnos)
        {
            Regex NombreConCaracteresEspeciales = new Regex(@"[ A-Za-zäÄëËïÏöÖüÜáéíóúáéíóúÁÉÍÓÚÂÊÎÔÛâêîôûàèìòùÀÈÌÒÙ.-]+");
            Regex NumeroDeControlA = new Regex(@"[1][0-9]{2}[G,D,M,T,P,A][0]{1}[0-9]{3}");

            if (!NombreConCaracteresEspeciales.IsMatch(alumnos.Nombre.ToString()))
            {
                throw new Exception("El Nombre no puede ir con caracteres especiales.");
            }
            if (!NumeroDeControlA.IsMatch(alumnos.NumeroControl.ToString()))
            {
                throw new Exception("Numero de control incorrecto. Verifique que el formato este correcto");
            }
            if (string.IsNullOrWhiteSpace(alumnos.Nombre.ToString()))

            {
                throw new Exception("El Nombre no puede ir vacio");
            }

            return true;
        }
    }
}