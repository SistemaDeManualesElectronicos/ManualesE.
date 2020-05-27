using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManualesElectronicosFInalFinal2.Models;
using ManualesElectronicosFInalFinal2.Repositories;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace ManualesElectronicosFInalFinal2.Controllers
{
    public class SubtemasController : Controller
    {

        SubtemasRepository sub;
        public IActionResult Subtemas()
        {
            sub = new SubtemasRepository();
            ViewModelSubtemas su = new ViewModelSubtemas();

            su.Subtema = sub.GetSubemascxNombre();
            return View(su);
        }


        public IActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Agregar(ViewModelSubtemas s)
        {

            SubtemasRepository sub = new SubtemasRepository();
            JsonResult json = null;
            List<string> errores = sub.Validacion(s.Subtemas);
            try
            {
                if (errores.Count() == 0)
                {
                    s.Subtemas.Nombre = s.Subtemas.Nombre.ToUpper();

                    //nuevo.Alumno.Contraseña = EncriptarLaContraseñaConverter.Encriptar(nuevo.Alumno.NumeroControl);
                    sub.Insert(s.Subtemas);
                    json = Json(true);
                }

                for (int i = 0; i < errores.Count; i++)
                {
                    json = Json(errores);
                }
            }
            catch (Exception)
            {
                json = Json("Ah ocurrido un error, porfavor actualice la pagina y vuelva a intntarlo, si el error persiste comuniquese con soporte tecnico");
            }
            return json;




        }

        [HttpPost]
        public JsonResult Eliminar(int id)
        {
            JsonResult json = null;
            try
            {
                SubtemasRepository sub = new SubtemasRepository();
                var r = sub.GetById(id);
                if (r != null)
                {
                    sub.Delete(r);
                    json = Json(true);
                }
                else
                {
                    json = Json("El curso no existe o ya ha sido eliminado.");
                }
            }
            catch (Exception)
            {
                json = Json("Ah ocurrido un error, porfavor actualice la pagina y vuelva a intntarlo, si el error persiste comuniquese con soporte tecnico");
            }


            return json;
        }

        public JsonResult GetUbtemas(int id)
        {
            JsonResult json = null;
            SubtemasRepository sub = new SubtemasRepository();
            var r = sub.GetById(id);
            if (r == null)
            {
                json = Json(false);
            }
            else
            {
                json = Json(
                    new
                    {
                        r.Id,
                        r.Nombre




                    }
                    );
            }
            return json;

        }
        [HttpPost]
        public JsonResult Editar(ViewModelSubtemas s)
        {
            JsonResult json = null;
            SubtemasRepository sub = new SubtemasRepository();

            List<string> errores = sub.Validacion(s.Subtemas);

            try
            {
                if (errores.Count() == 0)
                {
                    if (s != null)
                    {
                        s.Subtemas.Nombre = s.Subtemas.Nombre.ToUpper();
                        sub.Update(s.Subtemas);
                        json = Json(true);
                    }
                    else
                    {
                        json = Json("El Subtema no existe o ya ha sido eliminado.");
                    }
                }


                for (int i = 0; i < errores.Count; i++)
                {
                    json = Json(errores);
                }
                //  }
            }

            catch (Exception)
            {
                json = Json("Ah ocurrido un error, porfavor actualice la pagina y vuelva a intntarlo,a si el error persiste comuniquese con soporte tecnico");
            }
            return json;

        }

    }
}