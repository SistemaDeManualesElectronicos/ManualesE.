﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManualesElectronicosFInalFinal2.Models
{
    public class Alumnos
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string NumeroControl { get; set; }
        public string Contraseña { get; set; }
        public int IdCarrera { get; set; }
        public bool? Eliminado { get; set; }


        public Carrera IdCarreraNavigation { get; set; }
    }
}
