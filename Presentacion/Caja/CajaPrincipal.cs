using movi_escritorio.Logica;
using System;
using System.Windows.Forms;

namespace movi_escritorio.Presentacion.Caja
{
    public partial class CajaPrincipal : Form
    {
        public CajaPrincipal()
        {
            InitializeComponent();
            MostrarTransacciones();
        }

        CL_Caja objetoCL = new CL_Caja();

        private int IdTransaccion;

        public void MostrarTransacciones()
        {

            dataListadoClientes.DataSource = objetoCL.BuscarTransacciones(this.dtpFecha.Value.ToString("yyyy-MM-dd"));
            dataListadoClientes.Columns[0].Visible = false;
            lblTotalClientes.Text = "Total de Registros: " + Convert.ToString(dataListadoClientes.Rows.Count);
            // this.banderaFormularioHijo = false;
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente Desea Eliminar el cliente", "Movi", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Opcion == DialogResult.OK)
                {
                    CL_Clientes.Eliminar(this.IdTransaccion);
                    this.MostrarTransacciones();
                }
                this.MensajeOk("Se elimino de forma correcta el registro");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
            this.Close();
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente Desea Eliminar la transaccion", "Movi", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Opcion == DialogResult.OK)
                {
                    CL_Clientes.Eliminar(this.IdTransaccion);
                    this.MostrarTransacciones();
                    this.MensajeOk("Se elimino de forma correcta el registro");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
            this.Close();
        }


        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            this.MostrarTransacciones();
        }

        private void ClientesPrincipal_Load(object sender, EventArgs e)
        {
            MostrarTransacciones();
        }

        private void btnFicha_Click(object sender, EventArgs e)
        {
            NuevoEditarTransaccion frm = new NuevoEditarTransaccion(this.IdTransaccion);
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
            if (dataListadoClientes.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataListadoClientes.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataListadoClientes.Rows[selectedrowindex];
                this.IdTransaccion = Convert.ToInt32(selectedRow.Cells["IdPersona"].Value);
            }
        }

        private void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            NuevoEditarTransaccion frm = new NuevoEditarTransaccion(this.IdTransaccion);
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            this.MostrarTransacciones();
        }
    }
}
