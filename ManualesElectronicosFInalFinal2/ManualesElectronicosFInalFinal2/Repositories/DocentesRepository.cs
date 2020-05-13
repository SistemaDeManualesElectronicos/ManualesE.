using ManualesElectronicosFInalFinal2.Models;
using Microsoft.EntityFrameworkCore;
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
      

        public IEnumerable<Docentes> GetDocentesxNombre()
        {
            
            var data = Context.Docentes.Include(x=>x.IdCarreraNavigation).OrderBy(x => x.Nombre);
            return data;
        }

        public Docentes GetDocenteById(int id)
        {
            return Context.Docentes.FirstOrDefault(x=>x.Id == id);
          
        }

       
        public List<string> ValidarDocentes(Docentes docente)
        {
            
            List<string> errores = new List<string>();
            Regex NombreConCaracteresEspeciales = new Regex(@"^([A-ZÁÉÍÓÚñáéíóúÑ]{0}?[A-ZÁÉÍÓÚñáéíóúÑ\']+[\s])+([A-ZÁÉÍÓÚñáéíóúÑ]{0}?[A-ZÁÉÍÓÚñáéíóúÑ\'])+[\s]?([A-ZÁÉÍÓÚñáéíóúÑ]{0}?[A-ZÁÉÍÓÚñáéíóúÑ\'])?$");
            Regex NumeroDeControl = new Regex(@"^([0-9]\d{0,5})+$");
            var dato = Context.Carrera.FirstOrDefault(x => x.Id == docente.IdCarrera);

            
            if (string.IsNullOrWhiteSpace(docente.NumeroDeControl))
            {
                errores.Add("El Campo conocido como numero de control no debe ir vacio");
            }
            else
            {
                if (!NumeroDeControl.IsMatch(docente.NumeroDeControl))
                {
                    errores.Add("El patron de numero de control esta incorrecto");
                }
            }
           

  
            if (string.IsNullOrWhiteSpace(docente.Nombre))
            {
                errores.Add("el campo no puede ser nulo o en blanco");
            }
            
            else
            {
                if (!NombreConCaracteresEspeciales.IsMatch(docente.Nombre))
                {
                    errores.Add("El nombre no puede tener caracteres especiales o debe contener nombre y apellido, debe estar en mayusculas");
                }
            }

            if (dato == null)
            {
                errores.Add("El Value de la carrera no existe");
            }

            if (Context.Docentes.Any(x => x.NumeroDeControl == docente.NumeroDeControl && x.Id != docente.Id))  //Validar si ya existe numero de control
            {

                errores.Add("Numero de control ya existente");
            }






            return errores;
        }
    }
}
