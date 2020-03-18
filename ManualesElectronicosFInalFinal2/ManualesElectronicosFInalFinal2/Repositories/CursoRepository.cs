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

            //if (curso.Nombre.Length < 4)
            //{
                //listaerrores.Add("Debe poner un nombre mayor a 4 letras ");
                //
           // }



            return listaerrores;
        }



        }
}
