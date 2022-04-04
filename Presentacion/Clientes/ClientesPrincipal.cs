using movi_escritorio.Logica;
using System;
using System.Windows.Forms;

namespace movi_escritorio.Presentacion.Clientes
{
    public partial class ClientesPrincipal : Form
    {
        public ClientesPrincipal()
        {
            InitializeComponent();
            MostrarClientes();
        }

        CL_Clientes objetoCL = new CL_Clientes();

        private int IdCliente;

        public void MostrarClientes()
        {
            dataListadoClientes.DataSource = objetoCL.BuscarClientes(this.txtApellidos.Text, this.txtNombres.Text, 0);
            dataListadoClientes.Columns[0].Visible = false;
            lblTotalClientes.Text = "Total de Registros: " + Convert.ToString(dataListadoClientes.Rows.Count);
            // this.banderaFormularioHijo = false;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente Desea Eliminar el cliente", "Movi", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Opcion == DialogResult.OK)
                {
                    CL_Clientes.Eliminar(this.IdCliente);
                    this.MostrarClientes();
                }
                this.MensajeOk("Se elimino de forma correcta el registro");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
            this.Close();
        }

        private void BuscarCliente()
        {
            Console.WriteLine("this.txtBuscar.Text es " + this.txtNombres.Text);
            this.dataListadoClientes.DataSource = objetoCL.BuscarCliente(this.txtNombres.Text);
            // this.OcultarColumnas();
            lblTotalClientes.Text = "Total de Registros: " + Convert.ToString(dataListadoClientes.Rows.Count);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarCliente();
        }

        private void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            Console.WriteLine("this.IdCliente en click nuevo es  : " + this.IdCliente);
            //Presentacion.Clientes.NuevoEditarCliente frm = new NuevoEditarCliente(this.IdCliente, true);
            //frm.MdiParent = this.MdiParent;
            //frm.Show();
            this.Close();
        }

        private void dataListadoClientes_SelectionChanged(object sender, EventArgs e)
        {
            if (dataListadoClientes.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataListadoClientes.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataListadoClientes.Rows[selectedrowindex];
                this.IdCliente = Convert.ToInt32(selectedRow.Cells["IdCliente"].Value);
                Console.WriteLine("El id IdCliente es " + this.IdCliente);
            }
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
                    CL_Clientes.Eliminar(this.IdCliente);
                    this.MostrarClientes();
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
            this.MostrarClientes();
        }

        private void ClientesPrincipal_Load(object sender, EventArgs e)
        {
            MostrarClientes();
        }
    }
}
