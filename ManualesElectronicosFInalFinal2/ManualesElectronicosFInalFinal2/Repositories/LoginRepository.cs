﻿using ManualesElectronicosFInalFinal2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManualesElectronicosFInalFinal2.Repositories
{
    public class LoginRepository:Repository<Login>
    {

        itesrcne_manualesContext context;
        public void Login(string name, string password)
        {
            context = new itesrcne_manualesContext();
            var result = context.Login.Any(x => x.Nombre == name && x.Password == password);
            if (result)
            {

            }
        }


        public void LoginAlumnos(int Id, string NumeroDeControl)
        {

            var result = context.Login.Any(x => x.Id == Id && x.Password == NumeroDeControl);
            if(result)
            {

            }
         

        }



    }
}
