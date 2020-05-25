using ManualesElectronicosFInalFinal2.models;
using ManualesElectronicosFInalFinal2.Models;
using ManualesElectronicosFInalFinal2.Models.DocentesViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ManualesElectronicosFInalFinal2.Repositories
{
    public class SubtemasRepository: Repository<Subtemas>
    {
        private IHostingEnvironment environment;

        public string ruta { get; set; }

        public SubtemasRepository(itesrcne_manualesContext context)
        {
            Context = context;
        }

        public SubtemasRepository(itesrcne_manualesContext context, IHostingEnvironment environment)
        {
            Context = context;
            this.environment = environment;
            ruta = environment.WebRootPath;
        }

        public void AgregarImagen(IFormFile foto, string carpeta, int id, string ruta)
        {
            if (foto != null)
            {
                if (foto.Length > 1024 * 1024) { throw new Exception("El tamaño maximo permitido para el archivo es de 1MB"); }
                FileStream fs = System.IO.File.Create(Path.Combine(ruta, $"img/{carpeta}", id + ".png"));
                foto.CopyTo(fs);
                fs.Close();
            }
        }

        public void Insert(SubtemasViewModel svm)
        {
            Subtemas subtemas = new Subtemas { ContenidoHtml = svm.ContenidoHtml, Nombre = svm.Nombre };
            Insert(subtemas);
            AgregarImagen(svm.Foto, "secciones/iconos", subtemas.Id, ruta);
        }

    }
}
