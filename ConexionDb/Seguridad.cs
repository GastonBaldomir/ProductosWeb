using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionDb
{
    public static class Seguridad
    {
        public static bool sesionActiva(object usuario)
        {
            Persona persona = usuario != null ? (Persona)usuario : null;
            if (persona != null && persona.Id != 0)
                return true;
            else
                return false;

        }
        public static bool esAdmin(object usuario)
        {
            Persona persona = usuario != null ? (Persona)usuario : null;
            return persona != null ? persona.Admin : false;
            
        }
    }
}
