using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace movi_escritorio.Datos
{
    public class CD_Caja
    {
        private int _IdTransaccion;
        private string _IdPlan;
        private string _Apellidos;
        private string _Nombres;

        private string _Observaciones;

        private string _Fecha;

        private string _TextoBuscar;


        public int IdTransaccion { get => _IdTransaccion; set => _IdTransaccion = value; }
        public string Apellidos { get => _Apellidos; set => _Apellidos = value; }
        public string Nombres { get => _Nombres; set => _Nombres = value; }
        public string Fecha { get => _Fecha; set => _Fecha = value; }
        public string Observaciones { get => _Observaciones; set => _Observaciones = value; }
        public string IdPlan { get => _IdPlan; set => _IdPlan = value; }
        public string FechaInicio { get => _Fecha; set => _Fecha = value; }

        //Constructores
        public CD_Caja()
        {

        }

        public CD_Caja(int IdTransaccion, string Fecha, string Horario,
            string ClasesDisponibles, string MesesCredito, string Apellidos, string Nombres, string Password, string Documento
            , string Telefono, string Sexo, string Correo, string Calle, string Observaciones)
        {
            this.IdTransaccion = IdTransaccion;
            this.Apellidos = Apellidos;
            this.Nombres = Nombres;
            this.Fecha = Fecha;

            this.Observaciones = Observaciones;

        }



        // ==================================================
        //  Permite devolver todos los clientes activos de la BD
        // ==================================================
        private CD_Conexion conexion = new CD_Conexion();

        MySqlDataReader leer;
        DataTable tabla = new DataTable();
        MySqlCommand comando = new MySqlCommand();

        // ==================================================
        //  Busca clientes en la BD segun coincidencia de busqueda
        //  Inicialmente muestra todos los clientes
        // ==================================================
        public DataTable BuscarTransacciones(string Fecha)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "bsp_listar_transacciones";
            comando.Parameters.Clear();

            MySqlParameter pFecha = new MySqlParameter();
            pFecha.ParameterName = "@pFecha";
            pFecha.MySqlDbType = MySqlDbType.VarChar;
            pFecha.Size = 60;
            pFecha.Value = Fecha;
            comando.Parameters.Add(pFecha);

            tabla.Clear();
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;

        }

        // devuelve solo 1 cliente de la BD
        public DataTable MostrarCliente(int IdPersona)
        {
            Console.WriteLine("IdPersona en capa datos es : " + IdPersona);
            comando.Connection = conexion.AbrirConexion();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "bsp_dame_persona";

            MySqlParameter pIdPersona = new MySqlParameter();
            pIdPersona.ParameterName = "@pIdPersona";
            pIdPersona.MySqlDbType = MySqlDbType.Int32;
            // pIdProducto.Size = 60;
            pIdPersona.Value = IdPersona;
            comando.Parameters.Add(pIdPersona);



            leer = comando.ExecuteReader();
            tabla.Load(leer);

            comando.Parameters.Clear();
            conexion.CerrarConexion();

            return tabla;

        }

        public string Editar(CD_Clientes Cliente)
        {
            Console.WriteLine("Cliente.IdPersona es 1 : " + Cliente.IdPersona);
            string rpta = "";
            comando.Parameters.Clear();// si no ponerlo al comienzo de esta funcion
            try
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "bsp_editar_cliente";

                MySqlParameter pIdPersona = new MySqlParameter();
                pIdPersona.ParameterName = "@pIdPersona";
                pIdPersona.MySqlDbType = MySqlDbType.Int32;
                // pIdEmpleado.Size = 60;
                pIdPersona.Value = Cliente.IdPersona;
                comando.Parameters.Add(pIdPersona);

                MySqlParameter pTransporte = new MySqlParameter();
                pTransporte.ParameterName = "@pTransporte";
                pTransporte.MySqlDbType = MySqlDbType.VarChar;
                pTransporte.Size = 60;
                //pTransporte.Value = Cliente.Transporte;
                comando.Parameters.Add(pTransporte);

                MySqlParameter pTitular = new MySqlParameter();
                pTitular.ParameterName = "@pTitular";
                pTitular.MySqlDbType = MySqlDbType.VarChar;
                pTitular.Size = 30;
                //pTitular.Value = Cliente.Titular;
                comando.Parameters.Add(pTitular);

                MySqlParameter pTelefono = new MySqlParameter();
                pTelefono.ParameterName = "@pTelefono";
                pTelefono.MySqlDbType = MySqlDbType.VarChar;
                pTelefono.Size = 15;
                //pTelefono.Value = Cliente.Telefono;
                comando.Parameters.Add(pTelefono);

                rpta = comando.ExecuteScalar().ToString() == "Ok" ? "OK" : "No se edito el Registro";

            }
            catch (Exception ex)
            {

                rpta = ex.Message;
                Console.WriteLine("rpta es : " + rpta);
            }
            finally
            {
                conexion.CerrarConexion();
            }
            comando.Parameters.Clear();
            return rpta;
        }

        //Métodos
        //Insertar
        public string Insertar(CD_Clientes Cliente)
        {
            string rpta = "";
            try
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "bsp_alta_cliente";

                MySqlParameter pTitular = new MySqlParameter();
                pTitular.ParameterName = "@pTitular";
                pTitular.MySqlDbType = MySqlDbType.VarChar;
                pTitular.Size = 60;
                //pTitular.Value = Cliente.Titular;
                comando.Parameters.Add(pTitular);

                // Console.WriteLine("pNombre es : " + pNombre.Value);

                MySqlParameter pTransporte = new MySqlParameter();
                pTransporte.ParameterName = "@pTransporte";
                pTransporte.MySqlDbType = MySqlDbType.VarChar;
                pTransporte.Size = 60;
                //pTransporte.Value = Cliente.Transporte;
                comando.Parameters.Add(pTransporte);

                MySqlParameter pTelefono = new MySqlParameter();
                pTelefono.ParameterName = "@pTelefono";
                pTelefono.MySqlDbType = MySqlDbType.VarChar;
                pTelefono.Size = 15;
                //pTelefono.Value = Cliente.Telefono;
                comando.Parameters.Add(pTelefono);

                // Console.WriteLine("el comando es : " + comando.CommandText[0]);
                //Ejecutamos nuestro comando

                rpta = comando.ExecuteNonQuery() == 1 ? "OK" : "NO se Ingreso el Registro";


            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                conexion.CerrarConexion();
            }
            return rpta;

        }

        // Metodo ELIMINAR Empleado (da de baja)
        public string Eliminar(CD_Clientes Cliente)
        {
            string rpta = "";
            // SqlConnection SqlCon = new SqlConnection();
            try
            {

                comando.Connection = conexion.AbrirConexion();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "bsp_eliminar_cliente";

                MySqlParameter pIdPersona = new MySqlParameter();
                pIdPersona.ParameterName = "@pIdPersona";
                pIdPersona.MySqlDbType = MySqlDbType.Int32;
                // pIdEmpleado.Size = 60;
                pIdPersona.Value = Cliente.IdPersona;
                comando.Parameters.Add(pIdPersona);

                //Ejecutamos nuestro comando

                rpta = comando.ExecuteNonQuery() == 1 ? "OK" : "NO se Elimino el Registro";


            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                //if (conexion. == ConnectionState.Open) 
                conexion.CerrarConexion();
            }
            return rpta;
        }

        public DataTable BuscarCliente(CD_Clientes Cliente)
        {
            try
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "bsp_buscar_cliente";

                MySqlParameter pTextoBuscar = new MySqlParameter();
                pTextoBuscar.ParameterName = "@pTextoBuscar";
                pTextoBuscar.MySqlDbType = MySqlDbType.VarChar;
                pTextoBuscar.Size = 30;
                // pTextoBuscar.Value = Cliente.TextoBuscar;
                comando.Parameters.Add(pTextoBuscar);

                leer = comando.ExecuteReader();
                tabla.Load(leer);
                Console.WriteLine("tabla en capa datos es : " + tabla);
                Console.WriteLine("leer en capa datos es : " + leer.ToString());
                comando.Parameters.Clear();
                conexion.CerrarConexion();

                // return tabla;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Entro en el catch y tabla es en capa datos" + tabla);
                Console.WriteLine("Entro en el catch y ex es en capa datos" + ex.Message);

                tabla = null;
            }
            return tabla;

        }
    }
}
