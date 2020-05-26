using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManualesElectronicosFInalFinal2.models;
using ManualesElectronicosFInalFinal2.Models;
using ManualesElectronicosFInalFinal2.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ManualesElectronicosFInalFinal2.Controllers
{
    public class TemasController : Controller
    {
        public TemasRepository temas;
     
        public IActionResult Temas()
        {
            temas = new TemasRepository();
            ViewModelTemas tem = new ViewModelTemas();
            tem.Tema = temas.GetTemascxNombre();
            return View(tem);
        }


        public IActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Agregar(ViewModelTemas t)
        {

            TemasRepository tem = new TemasRepository();
            JsonResult json = null;
            List<string> errores = tem.Validacion(t.Temas);
            try
            {
                if (errores.Count() == 0)
                {
                    t.Temas.Encabezado = t.Temas.Encabezado.ToUpper();

                    //nuevo.Alumno.Contraseña = EncriptarLaContraseñaConverter.Encriptar(nuevo.Alumno.NumeroControl);
                    tem.Insert(t.Temas);
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
                TemasRepository tem = new TemasRepository();
                var r = tem.GetById(id);
                if (r != null)
                {
                    tem.Delete(r);
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
        public JsonResult GetTemas(int id)
        {
            JsonResult json = null;
            TemasRepository tem = new TemasRepository();
            var r = tem.GetById(id);
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
                        r.Encabezado




                    }
                    );
            }
            return json;

        }

        [HttpPost]
         public JsonResult Editar(ViewModelTemas t)
        {
            JsonResult json = null;
            TemasRepository tem = new TemasRepository();
            t.Temas.Encabezado = t.Temas.Encabezado.ToUpper();
            List<string> errores = tem.Validacion(t.Temas);

            try
            {
                if (errores.Count() == 0)
                {
                    if (t != null)
                    {
                        t.Temas.Encabezado = t.Temas.Encabezado.ToUpper();
                        tem.Update(t.Temas);
                        json = Json(true);
                    }
                    else
                    {
                        json = Json("El Curso no existe o ya ha sido eliminado.");
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