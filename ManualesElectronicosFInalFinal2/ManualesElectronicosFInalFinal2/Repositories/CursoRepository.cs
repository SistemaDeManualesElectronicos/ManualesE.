using ManualesElectronicosFInalFinal2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManualesElectronicosFInalFinal2.Repositories
{
    public class CursoRepository : Repository<Curso>
    {

        public IEnumerable<Curso> GetAllxNombre()
        {

            var data = Context.Curso.OrderBy(x => x.Nombre);
            return data;
        }//p

        public Curso GetCursoById(int id)
        {
            return Context.Curso.FirstOrDefault(x => x.Id == id);

        }
       
        
        
        public List<string> ValidarCurso(Curso curso)
        {
            
     
            List<string> listaerrores = new List<string>();

            if (curso.Nombre.Length < 4 && curso.Nombre.Length < 30)
            {
                listaerrores.Add("El nombre debe ser minimo 4 letras ");
                
            }
            if (curso.FechaInicio.Value < DateTime.Now)
            {
                listaerrores.Add("La Fecha inicio debe debe ser mayor a la de hoy ");

            }
            if (curso.FechaFinal.Value < DateTime.Now && curso.FechaFinal.Value < curso.FechaInicio)
            {
                listaerrores.Add("La fecha final debe ser despues de la fecha inicio ");

            }


            return listaerrores;
        }



        }
}
