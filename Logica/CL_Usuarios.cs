using movi_escritorio.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace movi_escritorio.Logica
{
    internal class CL_Usuarios
    {
        public static string Login(string usuario, string password)
        {
            CD_Usuarios Obj = new CD_Usuarios();
            Obj.Usuario = usuario;
            Obj.Password = password;
            return Obj.Login(Obj);
        }
    }
}
