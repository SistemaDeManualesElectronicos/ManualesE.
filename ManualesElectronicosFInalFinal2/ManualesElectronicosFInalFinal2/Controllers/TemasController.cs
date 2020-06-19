using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManualesElectronicosFInalFinal2.Models;
using ManualesElectronicosFInalFinal2.Models.DocentesViewModels;
using ManualesElectronicosFInalFinal2.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ManualesElectronicosFInalFinal2.Controllers
{
    public class TemasController : Controller
    {
        public TemasRepository temas;
        public SubtemasRepository sub;
        List<Subtemas> lista = new List<Subtemas>();
        public IActionResult Temas()
        {
            temas = new TemasRepository();
            sub = new SubtemasRepository();
            ViewModelTemas tem = new ViewModelTemas();
            SubtemasViewModel su = new SubtemasViewModel();
            NavigationTemasSubtemas na = new NavigationTemasSubtemas();
            //su.Subtema = sub.GetSubemascxNombre();
            tem.Tema = temas.GetTemascxNombre();
            su.Subtema = sub.GetSubemascxNombre();
            //    su.Subtema = sub.GetSubemascxNombre();
           lista = new List<Subtemas>();
            ViewBag.SubBag = sub.GetSubemascxNombre();
       
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
                        json = Json("El Tema no existe o ya ha sido eliminado.");
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