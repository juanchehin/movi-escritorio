using movi_escritorio.Logica;
using System;
using System.Linq;
using System.Windows.Forms;

namespace movi_escritorio.Presentacion.Personal
{
    public partial class PersonalPrincipal : Form
    {
        public PersonalPrincipal()
        {
            InitializeComponent();
        }
        private void PersonalPrincipal_Load(object sender, EventArgs e)
        {
            MostrarPersonal();
        }

        CL_Personal objetoCL = new CL_Personal();

        private int IdPersonal;
        private int pIncluyeBajas;

        public void MostrarPersonal()
        {
            if(this.cbIncluyeBajas.Checked)
            {
                this.pIncluyeBajas = 1;
            }
            else
            {
                this.pIncluyeBajas = 0;
            }

            dataListadoPersonal.DataSource = objetoCL.BuscarPersonal(this.txtBuscar.Text, this.pIncluyeBajas);
            dataListadoPersonal.Columns[0].Visible = false;
            lblTotalPersonal.Text = "Total de Registros: " + Convert.ToString(dataListadoPersonal.Rows.Count);
            // this.banderaFormularioHijo = false;
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente Desea Eliminar el personal", "Movi", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Opcion == DialogResult.OK)
                {
                    CL_Clientes.Eliminar(this.IdPersonal);
                    this.MostrarPersonal();
                }
                this.MensajeOk("Se elimino de forma correcta el registro");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
            this.Close();
        }

        private void BuscarPersonal()
        {
            if (this.cbIncluyeBajas.Checked)
            {
                this.pIncluyeBajas = 1;
            }
            else
            {
                this.pIncluyeBajas = 0;
            }
            Console.WriteLine("this.txtBuscar.Text es " + this.txtBuscar.Text);
            this.dataListadoPersonal.DataSource = objetoCL.BuscarPersonal(this.txtBuscar.Text, this.pIncluyeBajas);
            // this.OcultarColumnas();
            lblTotalPersonal.Text = "Total de Registros: " + Convert.ToString(dataListadoPersonal.Rows.Count);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarPersonal();
        }

        private void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            Console.WriteLine("this.IdCliente en click nuevo es  : " + this.IdPersonal);
            //Presentacion.Clientes.NuevoEditarCliente frm = new NuevoEditarCliente(this.IdCliente, true);
            //frm.MdiParent = this.MdiParent;
            //frm.Show();
            this.Close();
        }

        private void botonEditarListado_Click_1(object sender, EventArgs e)
        {
            //Presentacion.Clientes.NuevoEditarCliente frm = new NuevoEditarCliente(this.IdCliente, false);
            //frm.MdiParent = this.MdiParent;
            //frm.Show();
            this.Close();
        }

        private void formClientes_Load(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente Desea Eliminar el cliente", "Movi", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Opcion == DialogResult.OK)
                {
                    CL_Clientes.Eliminar(this.IdPersonal);
                    this.MostrarPersonal();
                    this.MensajeOk("Se elimino de forma correcta el registro");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
            this.Close();
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnBuscar_Click(this, new EventArgs());
            }
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            this.MostrarPersonal();
        }


        private void btnFicha_Click(object sender, EventArgs e)
        {
            Presentacion.Personal.NuevoEditarPersonal frm = new NuevoEditarPersonal(this.IdPersonal, false);
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }


        //Mostrar Mensaje de Confirmación
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Movi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //Mostrar Mensaje de Error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Movi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dataListadoClientes_SelectionChanged_1(object sender, EventArgs e)
        {
            if (dataListadoPersonal.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataListadoPersonal.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataListadoPersonal.Rows[selectedrowindex];
                this.IdPersonal = Convert.ToInt32(selectedRow.Cells["IdPersona"].Value);
                Console.WriteLine("El id IdPersonal es " + this.IdPersonal);
            }
        }

        private void btnNuevoPersonal_Click(object sender, EventArgs e)
        {

        }

    }
}
