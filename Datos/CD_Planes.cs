using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace movi_escritorio.Datos
{
    internal class CD_Planes
    {
        // ==================================================
        //  Permite devolver todos los productos de la BD
        // ==================================================
        private CD_Conexion conexion = new CD_Conexion();

        MySqlDataReader leer;
        DataTable tabla = new DataTable();
        MySqlCommand comando = new MySqlCommand();
        public DataTable Mostrar()
        {

            comando.Connection = conexion.AbrirConexion();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "bsp_listar_planes";

            tabla.Clear();
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;

        }

        // Devuelve un solo producto dado un ID
        public DataTable MostrarPlan(int IdPlan)
        {
            Console.WriteLine("IdPlan en capa datos es : " + IdPlan);
            comando.Connection = conexion.AbrirConexion();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "bsp_dame_plan";

            MySqlParameter pIdPlan = new MySqlParameter();
            pIdPlan.ParameterName = "@pIdPlan";
            pIdPlan.MySqlDbType = MySqlDbType.Int32;
            // pIdProducto.Size = 60;
            pIdPlan.Value = IdPlan;
            comando.Parameters.Add(pIdPlan);

            leer = comando.ExecuteReader();
            tabla.Load(leer);
            Console.WriteLine("tabla en capa datos es : " + tabla);
            Console.WriteLine("leer en capa datos es : " + leer.ToString());
            comando.Parameters.Clear();
            conexion.CerrarConexion();

            return tabla;

        }
    }
}
