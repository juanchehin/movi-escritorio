using movi_escritorio.Logica;
using System;
using System.Data;
using System.Windows.Forms;

namespace movi_escritorio.Presentacion.Personal
{
    public partial class NuevoEditarPersonal : Form
    {
        public NuevoEditarPersonal(int parametro, bool IsNuevoEditar)
        {
            InitializeComponent();
            this.IdPersonal = parametro;
            this.bandera = IsNuevoEditar;
        }

        CL_Personal objetoCN = new CL_Personal();
        DataTable respuesta;
        // int parametroActual;
        bool bandera;
        bool IsNuevo = false;
        bool IsEditar = false;

        private int IdPersonal;
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



        // Carga los valores en los campos de texto del formulario para que se modifiquen los que se desean
        private void MostrarPersonal(int IdPersona)
        {
            respuesta = objetoCN.MostrarPersonal(IdPersona);

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
                txtCorreo.Text = Correo;

            }
        }


        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NuevoEditarPersonal_Load(object sender, EventArgs e)
        {
            // Relleno valores de TipoDocumento
            cbTipoDoc.DisplayMember = "Text";
            cbTipoDoc.ValueMember = "Value";

            var items = new[] {
                new { Text = "DNI", Value = "1" },
                new { Text = "CI", Value = "2" },
                new { Text = "CU", Value = "3" }
            };

            cbTipoDoc.DataSource = items;

            // Relleno valores de Sexo
            cbSexo.DisplayMember = "Text";
            cbSexo.ValueMember = "Value";

            var items1 = new[] {
                new { Text = "Hombre", Value = "0" },
                new { Text = "Mujer", Value = "1" }
            };

            cbSexo.DataSource = items1;

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
                Console.WriteLine("this.IdPersonal es : ", this.IdPersonal);
                this.MostrarPersonal(this.IdPersonal);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnGuardar_Click_1(object sender, EventArgs e)
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
                        string selected = this.cbTipoDoc.GetItemText(this.cbTipoDoc.SelectedItem);
                        MessageBox.Show(selected);

                        rpta = CL_Personal.Insertar(this.txtApellidos.Text.Trim(), this.txtNombres.Text.Trim(), this.txtDocumento.Text.Trim(), Convert.ToString(this.cbTipoDoc.SelectedValue), this.dtpFechaNac.Value.Date.ToString("yyyy-MM-dd"),Convert.ToInt32(this.txtNro.Text),this.txtTelefono.Text.Trim(), this.cbSexo.Text.Trim(), this.txtCorreo.Text.Trim(), this.txtCalle.Text.Trim(),this.rtbObservaciones.Text.Trim(),this.txtPassword.Text.Trim(), this.txtUsuario.Text.Trim());
                    }
                    else
                    {
                        rpta = CL_Personal.Editar(this.IdPersonal, this.txtDocumento.Text.Trim(), this.txtApellidos.Text.Trim(), this.txtTelefono.Text.Trim());
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
            MessageBox.Show(mensaje, "Movi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Movi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

    }
}
