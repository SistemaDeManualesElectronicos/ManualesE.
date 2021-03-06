﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ManualesElectronicosFInalFinal2.Helpers
{
    public static class EncriptarLaContraseñaConverter
    {
      public static string Encriptar(string Contraseña)
        {
            

            using (SHA256 sha256Hash = SHA256.Create())
            {
               
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(Contraseña));

                
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }


        }

    }
}
