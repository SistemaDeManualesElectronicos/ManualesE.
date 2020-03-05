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
      
      public bool validarAlumnosEditar (Alumnos alumnos)
        {



            return true;
        }
        sistemaselectronicoContext context = new sistemaselectronicoContext();
       
        public bool ValidarAlumnos(Alumnos alumnos)
        {
          
            Regex NombreConCaracteresEspeciales = new Regex(@"[ A-Za-zäÄëËïÏöÖüÜáéíóúáéíóúÁÉÍÓÚÂÊÎÔÛâêîôûàèìòùÀÈÌÒÙ.-]+");
            Regex NumeroDeControlA = new Regex(@"[1][0-9]{2}[A-Z]{1}[0]{1}[0-9]{3}");

            if (string.IsNullOrWhiteSpace(alumnos.NumeroControl.ToString()))  //Validar Numero Control vacio

            {
                throw new Exception("El Numero de control no puede ir vacio");
            }
            else
            {
                if (!NumeroDeControlA.IsMatch(alumnos.NumeroControl.ToString())) //validar formato de numero de control
                {
                    throw new Exception("Numero de control incorrecto. Verifique que el formato este correcto");
                }
            }


            if (!NombreConCaracteresEspeciales.IsMatch(alumnos.Nombre.ToString())) 
            {
                throw new Exception("El Nombre no puede ir con caracteres especiales.");
            }
         
            if (string.IsNullOrWhiteSpace(alumnos.Nombre.ToString()))

            {
                throw new Exception("El Nombre no puede ir vacio");
            }

            if (Context.Alumnos.Any(x => x.NumeroControl == alumnos.NumeroControl))  //Validar si ya existe numero de control
            {
                throw new Exception("Numero de control repetido");
            }

            return true;
        }
    }
}