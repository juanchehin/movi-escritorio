using movi_escritorio.Logica;
using System;
using System.Data;
using System.Windows.Forms;

namespace movi_escritorio.Presentacion.Clientes
{
    public partial class NuevoIngreso : Form
    {
        public NuevoIngreso()
        {
            InitializeComponent();
            CargarPlanesComboBox();
        }

        // Defino valores para usar en el metodo Cargar productos
        DataTable planes;
        CL_Planes objetoCL_planes = new CL_Planes();
        private string planActual;

        private void CargarPlanesComboBox()
        {
            planes = objetoCL_planes.MostrarPlanes();

            cbPlanes.DataSource = planes;

            // cbTrabajos.ValueMember = cbTrabajos;
            Console.WriteLine(" cbTrabajos.ValueMember es  " + cbPlanes.ValueMember);
            cbPlanes.DisplayMember = "Plan";
            cbPlanes.ValueMember = "IdPlan";

            this.planActual = cbPlanes.ValueMember.ToString();
        }
    }
}
