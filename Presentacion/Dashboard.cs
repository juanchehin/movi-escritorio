using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace movi_escritorio.Presentacion
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void btnAyuda_Click(object sender, EventArgs e)
        {
            Informacion frm = new Informacion();
            frm.Show();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            Clientes frm = new Clientes();
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void btnPlanes_Click(object sender, EventArgs e)
        {
            Planes frm = new Planes();
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void btnCaja_Click(object sender, EventArgs e)
        {
            Caja frm = new Caja();
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void btnPersonal_Click(object sender, EventArgs e)
        {
            Personal frm = new Personal();
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void btnAsistencias_Click(object sender, EventArgs e)
        {
            Asistencias frm = new Asistencias();
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void Dashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
