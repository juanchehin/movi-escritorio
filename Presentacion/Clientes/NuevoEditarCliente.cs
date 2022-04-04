using movi_escritorio.Logica;
using System;
using System.Data;
using System.Windows.Forms;

namespace movi_escritorio.Presentacion.Clientes
{
    public partial class NuevoEditarCliente : Form
    {
        CL_Clientes objetoCN = new CL_Clientes();
        DataTable respuesta;
        // int parametroActual;
        bool bandera;
        bool IsNuevo = false;
        bool IsEditar = false;

        private int IdCliente;
        private string Transporte;
        private string Titular;
        private int Telefono;
        private int IdTipoDocumento;
        private string Apellidos;
        private string Nombres;
        private string Documento;
        private string Sexo;
        private string Observaciones;
        private string FechaNac;
        private string Correo;
        private string Calle;
        private int Usuario;
        private string Objetivo;

        public NuevoEditarCliente(int parametro, bool IsNuevoEditar)
        {
            InitializeComponent();
            this.IdCliente = parametro;
            this.bandera = IsNuevoEditar;
        }

        private void formNuevoEditarClientes_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtApellidos;
            Console.WriteLine("this.bandera es : ", this.bandera);
            if (this.bandera)
            {
                lblEditarNuevo.Text = "Nuevo";
                // this.MostrarProducto(this.IdProducto);
                this.IsNuevo = true;
                this.IsEditar = false;
            }
            else
            {
                lblEditarNuevo.Text = "Ficha";
                this.IsNuevo = false;
                this.IsEditar = true;
                Console.WriteLine("this.Idcliente es : ", this.IdCliente);
                this.MostrarCliente(this.IdCliente);
            }
        }

        // Carga los valores en los campos de texto del formulario para que se modifiquen los que se desean
        private void MostrarCliente(int IdCliente)
        {
            respuesta = objetoCN.MostrarCliente(IdCliente);

            Console.WriteLine("Respuesta es ; " + respuesta.Rows.Count);

            foreach (DataRow row in respuesta.Rows)
            {
                Console.WriteLine("row es :" + row["IdPersona"]);

                IdTipoDocumento = Convert.ToInt32(row["IdTipoDocumento"]);
                Apellidos = Convert.ToString(row["Apellidos"]);
                Nombres = Convert.ToString(row["Nombres"]);
                Documento = Convert.ToString(row["Documento"]);

                Telefono = Convert.ToInt32(row["Telefono"]);
                Sexo = Convert.ToString(row["Sexo"]);
                Observaciones = Convert.ToString(row["Observaciones"]);
                // FechaNac = Convert.ToString(row["FechaNac"]);

                Correo = Convert.ToString(row["Correo"]);
                Calle = Convert.ToString(row["Calle"]);
                Objetivo = Convert.ToString(row["Objetivo"]);


                txtApellidos.Text = Apellidos;
                txtNombres.Text = Nombres;
                txtDocumento.Text = Documento;
                txtTelefono.Text = Convert.ToString(row["Telefono"]);

                txtDocumento.Text = Documento;
                txtCalle.Text = Calle;

                rtbObservaciones.Text = Observaciones;
                rtbObjetivo.Text = Objetivo;
                txtCorreo.Text = Correo;

            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (this.txtApellidos.Text == string.Empty || this.txtDocumento.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos");
                }
                else
                {
                    if (this.IsNuevo)
                    {
                        rpta = CL_Clientes.Insertar(this.txtApellidos.Text.Trim(), this.txtNombres.Text.Trim(), 
                            this.txtDocumento.Text.Trim(), this.txtTelefono.Text.Trim(), this.cbSexo.Text.Trim(), this.txtCorreo.Text.Trim()
                            , this.txtCalle.Text.Trim(), this.rtbObservaciones.Text.Trim());
                    }
                    else
                    {
                        rpta = CL_Clientes.Editar(this.IdCliente, this.txtDocumento.Text.Trim(), this.txtApellidos.Text.Trim(), this.txtTelefono.Text.Trim());
                    }

                    if (rpta.Equals("OK"))
                    {
                        if (this.IsNuevo)
                        {
                            this.MensajeOk("Se Insertó de forma correcta el registro");
                        }
                        else
                        {
                            this.MensajeOk("Se Actualizó de forma correcta el registro");
                        }
                    }
                    else
                    {
                        this.MensajeError(rpta);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
            this.Close();
        }
        

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NuevoEditarCliente_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtApellidos;
            if (this.bandera)
            {
                lblEditarNuevo.Text = "Nuevo";
                // this.MostrarProducto(this.IdProducto);
                this.IsNuevo = true;
                this.IsEditar = false;
            }
            else
            {
                lblEditarNuevo.Text = "Editar";
                this.IsNuevo = false;
                this.IsEditar = true;
                this.MostrarCliente(this.IdCliente);
            }
        }

        //Mostrar Mensaje de Error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Movi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Movi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
