using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace movi_escritorio.Datos
{
    public class CD_Clientes
    {
        private int _IdPersona;
        private string _IdPlan;
        private string _Apellidos;
        private string _Nombres;
        private string _Password;
        private string _Documento;
        private string _Telefono;
        private string _Sexo;
        private string _Correo;
        private string _Calle;
        private string _Observaciones;

        private string _Estado;
        private string _Ocupacion;
        private string _FechaInicio;
        private string _Horario;
        private string _ClasesDisponibles;
        private string _MesesCredito;

        private string _TextoBuscar;


        public int IdPersona { get => _IdPersona; set => _IdPersona = value; }
        public string Apellidos { get => _Apellidos; set => _Apellidos = value; }
        public string Nombres { get => _Nombres; set => _Nombres = value; }
        public string Password { get => _Password; set => _Password = value; }
        public string Documento { get => _Documento; set => _Documento = value; }
        public string Telefono { get => _Telefono; set => _Telefono = value; }
        public string Sexo { get => _Sexo; set => _Sexo = value; }
        public string Correo { get => _Correo; set => _Correo = value; }
        public string Calle { get => _Calle; set => _Calle = value; }
        public string Observaciones { get => _Observaciones; set => _Observaciones = value; }
        public string IdPlan { get => _IdPlan; set => _IdPlan = value; }
        public string Estado { get => _Estado; set => _Estado = value; }
        public string Ocupacion { get => _Ocupacion; set => _Ocupacion = value; }
        public string FechaInicio { get => _FechaInicio; set => _FechaInicio = value; }
        public string Horario { get => _Horario; set => _Horario = value; }
        public string ClasesDisponibles { get => _ClasesDisponibles; set => _ClasesDisponibles = value; }
        public string MesesCredito { get => _MesesCredito; set => _MesesCredito = value; }

        //Constructores
        public CD_Clientes()
        {

        }

        public CD_Clientes(int IdPersona, string IdPlan, string Estado, string Ocupacion, string FechaInicio, string Horario, 
            string ClasesDisponibles, string MesesCredito, string Apellidos, string Nombres, string Password, string Documento
            , string Telefono, string Sexo, string Correo, string Calle, string Observaciones)
        {
            this.IdPersona = IdPersona;
            this.IdPlan = IdPlan;
            this.Estado = Estado;
            this.Ocupacion = Ocupacion;
            this.FechaInicio = FechaInicio;
            this.Horario = Horario;
            this.ClasesDisponibles = ClasesDisponibles;
            this.MesesCredito = MesesCredito;

            this.Apellidos = Apellidos;
            this.Nombres = Nombres;
            this.Password = Password;
            this.Documento = Documento;
            this.Telefono = Telefono;
            this.Sexo = Sexo;
            this.Correo = Correo;
            this.Calle = Calle;
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
        public DataTable BuscarClientes(string Apellidos,string Nombres,int IdPlan)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "bsp_buscar_cliente_plan_estado";
            comando.Parameters.Clear();            

            MySqlParameter pApellidos = new MySqlParameter();
            pApellidos.ParameterName = "@pApellidos";
            pApellidos.MySqlDbType = MySqlDbType.VarChar;
            pApellidos.Size = 60;
            pApellidos.Value = Apellidos;
            comando.Parameters.Add(pApellidos);

            MySqlParameter pNombres = new MySqlParameter();
            pNombres.ParameterName = "@pNombres";
            pNombres.MySqlDbType = MySqlDbType.VarChar;
            pNombres.Size = 30;
            pNombres.Value = Nombres;
            comando.Parameters.Add(pNombres);

            MySqlParameter pIdPlan = new MySqlParameter();
            pIdPlan.ParameterName = "@pIdPlan";
            pIdPlan.MySqlDbType = MySqlDbType.Int32;
            pIdPlan.Size = 15;
            pIdPlan.Value = IdPlan;
            comando.Parameters.Add(pIdPlan);

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
