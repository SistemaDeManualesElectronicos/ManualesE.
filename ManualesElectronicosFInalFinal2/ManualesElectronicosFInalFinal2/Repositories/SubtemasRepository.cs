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
        public IEnumerable<Subtemas> GetSubemascxNombre()
        {
            return Context.Subtemas.OrderBy(x => x.Nombre);
        }

        public List<Subtemas> listas()
        {
            List < Subtemas > listas = new List<Subtemas>();
            return listas;
        }
        public Subtemas GetSubtemaById(int id)
        {
            return Context.Subtemas.FirstOrDefault(x => x.Id == id);

        }
        public IEnumerable<string> GetNombresSubtemas()
        {
            var data = GetAll().OrderBy(x => x.Nombre).Select(x => x.Nombre);
            return data;
        }
        //public SubtemasRepository(itesrcne_manualesContext context)
        //{
        //    Context = context;
        //}

        //public SubtemasRepository(itesrcne_manualesContext context, IHostingEnvironment environment)
        //{
        //    Context = context;
        //    this.environment = environment;
        //    ruta = environment.WebRootPath;
        //}


        public List<string> Validacion(Subtemas s)
        {
            List<string> errores = new List<string>();

            return errores;

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
