using ManualesElectronicosFInalFinal2.Models;
using ManualesElectronicosFInalFinal2.Models.DocentesViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ManualesElectronicosFInalFinal2.Repositories
{
    public class DocentesRepository : Repository<Docentes>
    {
        public IEnumerable<Docentes> GetDocentesxNombre(string Nombre)
        {
            var data = Context.Docentes.OrderBy(x => x.Nombre);
            return data;
        }
        public Docentes GetDDocenteByNombre(string nombre)
        {
            return Context.Docentes
                .FirstOrDefault(x => x.Nombre.ToUpper() == nombre.ToUpper());
        }

        Regex NombreConCaracteresEspeciales = new Regex(@"[ A-Za-zäÄëËïÏöÖüÜáéíóúáéíóúÁÉÍÓÚÂÊÎÔÛâêîôûàèìòùÀÈÌÒÙ.-]+");
        Regex NumeroDeControl = new Regex(@"/^[0-9]+$/");

        public bool ValidarDocentes(Docentes docente)
        {
            if (!NombreConCaracteresEspeciales.IsMatch(docente.Nombre.ToString()))
            {
                throw new Exception("el nombre no puede ir con caracteres especiales poner caracteres especiales");
            }
            if (string.IsNullOrWhiteSpace(docente.Nombre.ToString()))
            {
                throw new Exception("el nombre no puede ir vacio");
            }
            //if (!NumeroDeControl.IsMatch(docente.NumeroDeControl))
            //{
            //    throw new Exception("El numero de control no puede contener letras");
            //}





            return true;
        }
        static string Encriptar(string Contraseña)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(Contraseña));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public void InsertRepository(Docentes nuevo)
        {

            //Docentes l = new Docentes { Nombre = nuevo.Nombre, NumeroDeControl = nuevo.NumeroDeControl, Contraseña = nuevo.NumeroDeControl, Eliminado = false };
            nuevo.Contraseña = nuevo.NumeroDeControl;
            var contra= Encriptar(nuevo.Contraseña.ToString());
            nuevo.Contraseña = contra;
            Insert(nuevo);
        
        }

        public void Update(DocentesViewModel old)
        {
            Docentes m = new Docentes { Nombre = old.Nombre, NumeroDeControl = old.NumeroDeControl };
        }
        public Docentes GetDocenteById(int id)
        {
            return Context.Docentes.FirstOrDefault(x => x.Id == id);
        }


    }
}
