using System;
using System.Windows.Forms;
using movi_escritorio.Presentacion.Caja;
using movi_escritorio.Presentacion.Clientes;
using movi_escritorio.Presentacion.Personal;
using movi_escritorio.Presentacion.Planes;

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
            ClientesPrincipal frm = new ClientesPrincipal();
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void btnPlanes_Click(object sender, EventArgs e)
        {
            PlanesPrincipal frm = new PlanesPrincipal();
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void btnCaja_Click(object sender, EventArgs e)
        {
            CajaPrincipal frm = new CajaPrincipal();
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void btnPersonal_Click(object sender, EventArgs e)
        {
            PersonalPrincipal frm = new PersonalPrincipal();
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
