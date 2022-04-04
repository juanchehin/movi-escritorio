using movi_escritorio.Datos;
using System;
using System.Data;

namespace movi_escritorio.Logica
{
    internal class CL_Personal
    {
        private CD_Personal objetoCD = new CD_Personal();

        //Método Insertar que llama al método Insertar de la clase
        //de la CapaDatos
        public static string Insertar(string Apellidos, string Nombres, string Documento, string TipoDocumento,
            string FechaNac, int NumeroCalle, string Usuario, string Password,
            string Telefono, string Sexo, string Correo, string Calle, string Observaciones)
        {

            CD_Personal Obj = new CD_Personal();

            Obj.Apellidos = Apellidos;
            Obj.Nombres = Nombres;
            Obj.Documento = Documento;
            Obj.TipoDocumento = TipoDocumento;
            Obj.Telefono = Telefono;
            Obj.Sexo = Sexo;
            Obj.FechaNac = FechaNac;
            Obj.Correo = Correo;
            Obj.Calle = Calle;
            Obj.Usuario = Usuario;
            Obj.Password = Password;
            Obj.NumeroCalle = NumeroCalle;
            Obj.Observaciones = Observaciones;

            return Obj.Insertar(Obj);
        }

        public DataTable BuscarPersonal(string Busqueda,int pIncluyeBajas)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.BuscarPersonal(Busqueda,pIncluyeBajas);
            return tabla;
        }
        public static string Eliminar(int IdCliente)
        {
            Datos.CD_Clientes Obj = new Datos.CD_Clientes();
            // Obj.IdCliente = IdCliente;
            return Obj.Eliminar(Obj);
        }

        // Devuelve solo un personal
        public DataTable MostrarPersonal(int IdPersona)
        {

            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarPersonal(IdPersona);
            Console.WriteLine("tabla TableName en capa negocio es : " + tabla.TableName);
            Console.WriteLine("tabla Rows en capa negocio es : " + tabla.Rows);
            return tabla;
        }

        public static string Editar(int IdCliente, string Transporte, string Titular, string Telefono)
        {

            Datos.CD_Clientes Obj = new Datos.CD_Clientes();
            /*Obj.IdCliente = IdCliente;

            Obj.Transporte = Transporte;
            Obj.Titular = Titular;
            Obj.Telefono = Telefono;*/

            return Obj.Editar(Obj);
        }

        /*public DataTable BuscarCliente(string textobuscar)
        {
            Console.WriteLine("textobuscar en capa negocio es : " + textobuscar);
            Datos.CD_Clientes Obj = new Datos.CD_Clientes();
            // Obj.TextoBuscar = textobuscar;
            return Obj.BuscarCliente(Obj);
        }*/
    }
}
