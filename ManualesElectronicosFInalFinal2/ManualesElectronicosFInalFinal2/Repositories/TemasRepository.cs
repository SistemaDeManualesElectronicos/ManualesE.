using ManualesElectronicosFInalFinal2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ManualesElectronicosFInalFinal2.Repositories
{
    public class TemasRepository:Repository<Temas>
    {
        public IEnumerable<Temas> GetTemascxNombre()
        {
            return Context.Temas.OrderBy(x => x.Encabezado);
        }

        public Temas GetTemabyId(int id)
        {
            return Context.Temas.FirstOrDefault(x=>x.Id == id);
        }


        public List<string> Validacion(Temas t)
        {
            List<string> pablito = new List<string>();
            Regex NombreConCaracteresEspeciales = new Regex(@"^([A-Za-zÁÉÍÓÚñáéíóúÑ]){1,29}?$");
            if (string.IsNullOrEmpty(t.Encabezado))
            {
                pablito.Add("rellene el pinche nombre");
            }
            else
            {
                if (!NombreConCaracteresEspeciales.IsMatch(t.Encabezado))
                {
                    pablito.Add("el encabezado es muy corto o no debe de llevar caracteres especiales");
                }
            }

          
           
            return pablito;
      
        }
    }
}
