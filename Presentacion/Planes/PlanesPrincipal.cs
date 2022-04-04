using movi_escritorio.Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace movi_escritorio.Presentacion.Planes
{
    public partial class PlanesPrincipal : Form
    {
        CL_Planes objetoCL = new CL_Planes();
        public PlanesPrincipal()
        {
            InitializeComponent();
            MostrarPlanes();
        }
        private int IdPlan;

        private void btnNuevoPlan_Click(object sender, EventArgs e)
        {
            NuevoEditarPlan frm = new NuevoEditarPlan(this.IdPlan, true);
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void MostrarPlanes()
        {
            dataListadoEmpleados.DataSource = objetoCL.MostrarPlanes();
            // Oculto el IdEmpleado. Lo puedo seguir usando como parametro de eliminacion
            dataListadoEmpleados.Columns[0].Visible = false;
            lblTotalEmpleados.Text = "Total de Registros: " + Convert.ToString(dataListadoEmpleados.Rows.Count);

            // dataListadoEmpleados.Columns[0].ReadOnly = true;
        }
    }
}
