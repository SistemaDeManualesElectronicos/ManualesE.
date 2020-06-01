using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ManualesElectronicosFInalFinal2.models
{
    public partial class Curso
    {
        public int Id { get; set; }
        public string Clave { get; set; }
        public string Nombre { get; set; }
      //  [Display(Name = "editNombre")]
          [DisplayFormat(DataFormatString = "{0:yyy-MM-dd}", ApplyFormatInEditMode = true)]
          public DateTime? FechaInicio { get; set; }
 
        public DateTime inicio
        {
            get { return FechaInicio.Value.Date; }
        }

        public DateTime? FechaFinal { get; set; }
        public int? IdDocente { get; set; }
        public int? IdTemas { get; set; }
    }
}
