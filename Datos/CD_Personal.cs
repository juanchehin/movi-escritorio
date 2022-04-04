using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace movi_escritorio.Datos
{
    internal class CD_Personal
    {
        private int _IdPersona;
        private string _IdPlan;
        private string _Apellidos;
        private string _Nombres;
        private string _Password;
        private string _Documento;
        private string _TipoDocumento;
        private string _Telefono;
        private string _Sexo;
        private string _Correo;
        private string _Calle;
        private int _NumeroCalle;        
        private string _Observaciones;

        private string _Estado;
        private string _Ocupacion;
        private string _FechaInicio;
        private string _FechaNac;
        private string _Horario;
        private string _ClasesDisponibles;
        private string _MesesCredito;

        private string _TextoBuscar;


        public int IdPersona { get => _IdPersona; set => _IdPersona = value; }
        public string Apellidos { get => _Apellidos; set => _Apellidos = value; }
        public string Nombres { get => _Nombres; set => _Nombres = value; }
        public string Password { get => _Password; set => _Password = value; }
        public string Documento { get => _Documento; set => _Documento = value; }
        public string TipoDocumento { get => _TipoDocumento; set => _TipoDocumento = value; }
        public string Telefono { get => _Telefono; set => _Telefono = value; }
        public string Sexo { get => _Sexo; set => _Sexo = value; }
        public string Correo { get => _Correo; set => _Correo = value; }
        public string Calle { get => _Calle; set => _Calle = value; }
        public int NumeroCalle { get => _NumeroCalle; set => _NumeroCalle = value; }
        public string Observaciones { get => _Observaciones; set => _Observaciones = value; }
        public string Estado { get => _Estado; set => _Estado = value; }
        public string FechaInicio { get => _FechaInicio; set => _FechaInicio = value; }
        public string FechaNac { get => _FechaNac; set => _FechaNac = value; }
        public string Horario { get => _Horario; set => _Horario = value; }

        //Constructores
        public CD_Personal()
        {

        }

        public CD_Personal(int IdPersona, string Estado, string FechaInicio, string Horario,
            string Apellidos, string Nombres, string Password, string Documento
            , string Telefono, string Sexo, string Correo, string Calle, string Observaciones)
        {
            this.IdPersona = IdPersona;
            this.Estado = Estado;
            this.FechaInicio = FechaInicio;
            this.Horario = Horario;

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
        public DataTable BuscarPersonal(string busqueda,int incluyeBajas)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "bsp_buscar_personal";
            comando.Parameters.Clear();

            MySqlParameter pBusqueda = new MySqlParameter();
            pBusqueda.ParameterName = "@pBusqueda";
            pBusqueda.MySqlDbType = MySqlDbType.VarChar;
            pBusqueda.Size = 60;
            pBusqueda.Value = busqueda;
            comando.Parameters.Add(pBusqueda);

            MySqlParameter pIncluyeBajas = new MySqlParameter();
            pIncluyeBajas.ParameterName = "@pIncluyeBajas";
            pIncluyeBajas.MySqlDbType = MySqlDbType.Int32;
            // pIdEmpleado.Size = 60;
            pIncluyeBajas.Value = incluyeBajas;
            comando.Parameters.Add(pIncluyeBajas);

            tabla.Clear();
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;

        }

        // devuelve solo 1 cliente de la BD
        public DataTable MostrarPersonal(int IdPersona)
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

        public string Editar(CD_Personal Personal)
        {
            Console.WriteLine("Cliente.IdPersona es 1 : " + Personal.IdPersona);
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
                pIdPersona.Value = Personal.IdPersona;
                comando.Parameters.Add(pIdPersona);

                MySqlParameter pTelefono = new MySqlParameter();
                pTelefono.ParameterName = "@pTelefono";
                pTelefono.MySqlDbType = MySqlDbType.VarChar;
                pTelefono.Size = 15;
                //pTelefono.Value = Cliente.Telefono;
                comando.Parameters.Add(pTelefono);

                MySqlParameter pSexo = new MySqlParameter();
                pSexo.ParameterName = "@pSexo";
                pSexo.MySqlDbType = MySqlDbType.Int32;
                pSexo.Size = 15;
                //pTelefono.Value = Cliente.Telefono;
                comando.Parameters.Add(pSexo);

                MySqlParameter pFechaNac = new MySqlParameter();
                pFechaNac.ParameterName = "@pFechaNac";
                pFechaNac.MySqlDbType = MySqlDbType.Date;
                // pFechaNac.Size = 15;
                //pTelefono.Value = Cliente.Telefono;
                comando.Parameters.Add(pFechaNac);

                MySqlParameter pCorreo = new MySqlParameter();
                pCorreo.ParameterName = "@pCorreo";
                pCorreo.MySqlDbType = MySqlDbType.VarChar;
                pCorreo.Size = 60;
                //pTelefono.Value = Cliente.Telefono;
                comando.Parameters.Add(pCorreo);

                MySqlParameter pCalle = new MySqlParameter();
                pCalle.ParameterName = "@pCalle";
                pCalle.MySqlDbType = MySqlDbType.VarChar;
                pCalle.Size = 60;
                //pTelefono.Value = Cliente.Telefono;
                comando.Parameters.Add(pCalle);

                MySqlParameter pNro = new MySqlParameter();
                pNro.ParameterName = "@pNro";
                pNro.MySqlDbType = MySqlDbType.Int32;
                // pNro.Size = 60;
                //pTelefono.Value = Cliente.Telefono;
                comando.Parameters.Add(pNro);

                MySqlParameter pObservaciones = new MySqlParameter();
                pObservaciones.ParameterName = "@pObservaciones";
                pObservaciones.MySqlDbType = MySqlDbType.VarChar;
                pObservaciones.Size = 60;
                //pTelefono.Value = Cliente.Telefono;
                comando.Parameters.Add(pObservaciones);

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
        public string Insertar(CD_Personal Personal)
        {
            string rpta = "";
            try
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "bsp_alta_entrenador";

                MySqlParameter pApellidos = new MySqlParameter();
                pApellidos.ParameterName = "@pApellidos";
                pApellidos.MySqlDbType = MySqlDbType.VarChar;
                pApellidos.Size = 60;
                pApellidos.Value = Personal.Apellidos;
                comando.Parameters.Add(pApellidos);

                MySqlParameter pNombres = new MySqlParameter();
                pNombres.ParameterName = "@pNombres";
                pNombres.MySqlDbType = MySqlDbType.VarChar;
                pNombres.Size = 60;
                pNombres.Value = Personal.Nombres;
                comando.Parameters.Add(pNombres);

                MySqlParameter pDocumento = new MySqlParameter();
                pDocumento.ParameterName = "@pDocumento";
                pDocumento.MySqlDbType = MySqlDbType.VarChar;
                pDocumento.Size = 60;
                pDocumento.Value = Personal.Documento;
                comando.Parameters.Add(pDocumento);

                MySqlParameter pTipoDoc = new MySqlParameter();
                pTipoDoc.ParameterName = "@pTipoDoc";
                pTipoDoc.MySqlDbType = MySqlDbType.VarChar;
                pTipoDoc.Size = 60;
                pTipoDoc.Value = Personal.TipoDocumento;
                comando.Parameters.Add(pTipoDoc);

                MySqlParameter pTelefono = new MySqlParameter();
                pTelefono.ParameterName = "@pTelefono";
                pTelefono.MySqlDbType = MySqlDbType.Int32;
                pTelefono.Size = 15;
                //pTelefono.Value = Cliente.Telefono;
                comando.Parameters.Add(pTelefono);

                MySqlParameter pSexo = new MySqlParameter();
                pSexo.ParameterName = "@pSexo";
                pSexo.MySqlDbType = MySqlDbType.VarChar;
                pSexo.Size = 15;
                pTelefono.Value = Personal.Sexo;
                comando.Parameters.Add(pSexo);

                MySqlParameter pFechaNac = new MySqlParameter();
                pFechaNac.ParameterName = "@pFechaNac";
                pFechaNac.MySqlDbType = MySqlDbType.VarChar;
                pFechaNac.Size = 15;
                pFechaNac.Value = Personal.FechaNac;
                comando.Parameters.Add(pFechaNac);

                MySqlParameter pCorreo = new MySqlParameter();
                pCorreo.ParameterName = "@pCorreo";
                pCorreo.MySqlDbType = MySqlDbType.VarChar;
                pCorreo.Size = 60;
                pTelefono.Value = Personal.Telefono;
                comando.Parameters.Add(pCorreo);

                MySqlParameter pCalle = new MySqlParameter();
                pCalle.ParameterName = "@pCalle";
                pCalle.MySqlDbType = MySqlDbType.VarChar;
                pCalle.Size = 60;
                pTelefono.Value = Personal.Telefono;
                comando.Parameters.Add(pCalle);

                MySqlParameter pNro = new MySqlParameter();
                pNro.ParameterName = "@pNro";
                pNro.MySqlDbType = MySqlDbType.Int32;
                // pNro.Size = 60;
                pTelefono.Value = Personal.NumeroCalle;
                comando.Parameters.Add(pNro);

                MySqlParameter pObservaciones = new MySqlParameter();
                pObservaciones.ParameterName = "@pObservaciones";
                pObservaciones.MySqlDbType = MySqlDbType.VarChar;
                pObservaciones.Size = 60;
                pTelefono.Value = Personal.Observaciones;
                comando.Parameters.Add(pObservaciones);

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
                comando.CommandText = "bsp_eliminar_personal";

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

        public DataTable BuscarPersonal(CD_Personal Personal)
        {
            try
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "bsp_buscar_personal";

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
