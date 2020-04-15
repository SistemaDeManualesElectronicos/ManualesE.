using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ManualesElectronicosFInalFinal2.Models.DocentesViewModels
{
    public class SubtemasViewModel

    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Debe escribir el nombre de la categoria.")]
        [StringLength(25, ErrorMessage = "El nombre no debe sobrepasar los 25 caracteres")]
        public string ContenidoHtml { get; set; }
        public string ReferenciasApa { get; set; }
        public string ListadeRecursos { get; set; }
        public IFormFile Foto { get; set; }
    }
}

