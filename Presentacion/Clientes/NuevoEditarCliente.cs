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
        private string Telefono;
        public NuevoEditarCliente(int parametro, bool IsNuevoEditar)
        {
            InitializeComponent();
        }


        private void formNuevoEditarClientes_Load(object sender, EventArgs e)
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

        // Carga los valores en los campos de texto del formulario para que se modifiquen los que se desean
        private void MostrarCliente(int IdCliente)
        {
            respuesta = objetoCN.MostrarCliente(IdCliente);

            Console.WriteLine("Respuesta es ; " + respuesta.Rows.Count);
            foreach (DataRow row in respuesta.Rows)
            {
                Console.WriteLine("row es :" + row["Transporte"]);

                IdCliente = Convert.ToInt32(row["IdCliente"]);
                Transporte = Convert.ToString(row["Transporte"]);
                Titular = Convert.ToString(row["Titular"]);
                Telefono = Convert.ToString(row["Telefono"]);



                txtApellidos.Text = Transporte;
                txtDocumento.Text = Titular;
                txtTelefono.Text = Telefono;
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
        //Mostrar Mensaje de Error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Gomeria Leon", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Gomeria Leon", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
