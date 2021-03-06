﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using ManualesElectronicosFInalFinal2.Models;
using Microsoft.EntityFrameworkCore;

namespace ManualesElectronicosFInalFinal2.Repositories
{
    public class AlumnosRepository : Repository<Alumnos>
    {
       public IEnumerable<Alumnos> GetAlumnosxNombre()
        {
            
            var data = Context.Alumnos.Include(x => x.IdCarreraNavigation).OrderBy(x => x.Nombre);
            return data;
        }//p
        
        public Alumnos GetAlumnoById(int id)
        {
            return Context.Alumnos.FirstOrDefault(x => x.Id == id);

        }


        itesrcne_manualesContext context = new itesrcne_manualesContext();
        Regex NombreConCaracteresEspecialess = new Regex(@"^([A-Za-zÁÉÍÓÚñáéíóúÑ]{0}?[A-Za-zÁÉÍÓÚñáéíóúÑ\']+[\s])+([A-Za-zÁÉÍÓÚñáéíóúÑ]{0}?[A-Za-zÁÉÍÓÚñáéíóúÑ\'])+[\s]?([A-Za-zÁÉÍÓÚñáéíóúÑ]{0}?[A-Za-zÁÉÍÓÚñáéíóúÑ\'])?$");
        
        public List<string> ValidarAlumnos(Alumnos alumnos)
        {
            List<string> listaerrores = new List<string>();
            Regex NumeroDeControlA = new Regex(@"[0-1][0-9]{2}[A-Z]{1}[0]{1}[0-9]{3}");
            if (alumnos.Nombre != null )
            {
                if (alumnos.NumeroControl != null)
                {


                    if (string.IsNullOrWhiteSpace(alumnos.Nombre))

                    {
                        listaerrores.Add("El nombre del alumno no puede ir vacio, tener espacios en blanco ni numeros");
                    }

                //    if (string.IsNullOrWhiteSpace(alumnos.NumeroControl))

                  //  {
                    //    listaerrores.Add("El Numero de control no puede ir vacio o tener espacios en blanco");
                    //}

                    if (!NombreConCaracteresEspecialess.IsMatch(alumnos.Nombre.ToString())) //validar que escriba apellidos
                    {
                        listaerrores.Add("Verifique que haya escrito un nombre completo valido correctamente y no haya caracteres especiales");

                    }


                    if (alumnos.Nombre.Length > 45)
                    {
                        listaerrores.Add("El limite para el nombre es de 45");

                    }

                    if (Context.Alumnos.Any(x => x.Nombre == alumnos.Nombre && x.NumeroControl == alumnos.NumeroControl && x.Id != alumnos.Id))  //Validar si ya existe nombre de un alumno. IIDD
                    {
                        listaerrores.Add("Ya existe este Alumno, Por favor verifique sus datos");

                    }
                    ////////////////////////Numero Control//////////////////////////////////////////////////////////////////

                    if (string.IsNullOrWhiteSpace(alumnos.NumeroControl))  //Validar Numero Control vacio
                    {
                        listaerrores.Add("El Numero de control no puede ir vacio");
                    }
                    else
                    {
                        if (!NumeroDeControlA.IsMatch(alumnos.NumeroControl)) //validar formato de numero de control
                        {
                            listaerrores.Add("Numero de control incorrecto. Verifique que el formato este correcto");

                        }
                    }
                  string num = alumnos.NumeroControl.ToString().Substring(5,3);///  1 6 1 G 0 2 4 5
                    string ins = alumnos.NumeroControl.ToString().Substring(2, 1);
                    string letraCarrera = alumnos.NumeroControl.ToString().Substring(3, 1);
                    string numaño = alumnos.NumeroControl.ToString().Substring(0, 2);

                    
                    
                    if (int.Parse( numaño) < 14  ||  int.Parse(numaño) > int.Parse(  DateTime.Now.ToString("yy")) )
                    {
                        listaerrores.Add("Fecha de numero de control debe ser no debe ser abajo de 2014(14)");
                    }

                    if (num.Contains("000"))
                    {
                        listaerrores.Add("Numero de control no puede tener 000");
                    }
                    if (!ins.Contains("1"))
                    {
                        listaerrores.Add("Numero de control incorrecto, debe pertenecer a esta institución para ello debe colocar el numero (1) en el tercer digito del numero de control");
                    }

                    if (!letraCarrera.Contains("G") && !letraCarrera.Contains("T") && !letraCarrera.Contains("D") && !letraCarrera.Contains("M") && !letraCarrera.Contains("P") && !letraCarrera.Contains("A"))
                    {
                        listaerrores.Add("Esta carrera no existe");
                    }

                    if (alumnos.NumeroControl.Length > 8 || alumnos.NumeroControl.Length < 8)
                    {
                        listaerrores.Add("Numero de control incorrecto. El Numero de contorl tiene 8 caracteres");
                    }
                    if (context.Alumnos.Any(x => x.NumeroControl != alumnos.NumeroControl && x.Id == alumnos.Id))
                    {
                        listaerrores.Add("Error en el numero de control, Numero de control diferente");
                    }

                    if (Context.Alumnos.Any(x => x.NumeroControl == alumnos.NumeroControl && x.Id != alumnos.Id))  //Validar si ya existe numero de control
                    {

                        listaerrores.Add("Numero de control ya existente");
                    }
                    if (alumnos.IdCarrera == null)
                    {
                        listaerrores.Add("El Value de la carrera no existe");
                    }
                }
                else
                {
                    listaerrores.Add("El Numero de control no puede ir vacio o tener espacios en blanco");
                }

            }
            else
            {
                listaerrores.Add("El nombre del alumno no puede ir vacio o tener espacios en blanco");
            }

            return listaerrores ;
        }
        public List<string> ValidarAlumnosEditar(Alumnos alumnos)
        {
            List<string> listaerrores = new List<string>();
            if (string.IsNullOrWhiteSpace(alumnos.Nombre))

            {
                listaerrores.Add("El Nombre no puede ir vacio");

            }
            if (!NombreConCaracteresEspecialess.IsMatch(alumnos.Nombre.ToString())) //validar que escriba apellidos
            {
                listaerrores.Add("Verifique que haya escrito el nombre completo correctamente, sin espacios, caracteres especiales ni doble espacios");
               
            }
            if (alumnos.Nombre.Length > 45)
            {
                listaerrores.Add("El limite para el nombre es de 45");

            }

            if (Context.Alumnos.Any(x => x.Nombre == alumnos.Nombre))  //Validar si ya existe nombre de un alumno.
            {
                listaerrores.Add("Ya existe este Alumno, Por favor verifique sus datos");
               
            }

            return listaerrores;

        }

    

    }
}