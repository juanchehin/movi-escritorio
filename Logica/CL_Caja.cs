using movi_escritorio.Datos;
using System;
using System.Data;

namespace movi_escritorio.Logica
{
    internal class CL_Caja
    {
        private CD_Caja objetoCD = new CD_Caja();

        //Método Insertar que llama al método Insertar de la clase DArticulo
        //de la CapaDatos
        public static string Insertar(string Apellidos, string Nombres, string Documento,
            string Telefono, string Sexo, string Correo, string Calle, string Observaciones)
        {
            // Console.WriteLine("En insertar , nombre es " + nombre);

            Datos.CD_Clientes Obj = new Datos.CD_Clientes();

            Obj.Apellidos = Apellidos;
            Obj.Nombres = Nombres;
            Obj.Documento = Documento;
            Obj.Telefono = Telefono;
            Obj.Sexo = Sexo;
            Obj.Correo = Correo;
            Obj.Calle = Calle;
            Obj.Observaciones = Observaciones;

            return Obj.Insertar(Obj);
        }

        public DataTable BuscarTransacciones(string Fecha)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.BuscarTransacciones(Fecha);
            return tabla;
        }
        public static string Eliminar(int IdCliente)
        {
            Datos.CD_Clientes Obj = new Datos.CD_Clientes();
            // Obj.IdCliente = IdCliente;
            return Obj.Eliminar(Obj);
        }

        // Devuelve solo un Cliente
        public DataTable MostrarCliente(int IdCliente)
        {

            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarCliente(IdCliente);
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

        public DataTable BuscarCliente(string textobuscar)
        {
            Console.WriteLine("textobuscar en capa negocio es : " + textobuscar);
            Datos.CD_Clientes Obj = new Datos.CD_Clientes();
            // Obj.TextoBuscar = textobuscar;
            return Obj.BuscarCliente(Obj);
        }
    }
}
