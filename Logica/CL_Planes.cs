using movi_escritorio.Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace movi_escritorio.Logica
{
    public class CL_Planes
    {
        private CD_Planes objetoCD = new CD_Planes();

        public DataTable MostrarPlanes()
        {

            DataTable tabla = new DataTable();
            tabla = objetoCD.Mostrar();
            return tabla;
        }

        public DataTable MostrarPlan(int IdPlan)
        {

            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarPlan(IdPlan);
            Console.WriteLine("tabla TableName en capa negocio es : " + tabla.TableName);
            Console.WriteLine("tabla Rows en capa negocio es : " + tabla.Rows);
            return tabla;
        }
    }
}
