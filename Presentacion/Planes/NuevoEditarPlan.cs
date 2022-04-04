using movi_escritorio.Logica;
using System;
using System.Data;
using System.Windows.Forms;

namespace movi_escritorio.Presentacion.Planes
{
    public partial class NuevoEditarPlan : Form
    {
        CL_Planes objetoCL = new CL_Planes();
        DataTable respuesta;
        // int parametroActual;
        bool bandera;
        bool IsNuevo = false;
        bool IsEditar = false;

        private int IdPlan;
        private string Plan;
        private string Descripcion;
        private decimal Precio;
        private int CantClases;

        public NuevoEditarPlan(int parametro, bool IsNuevoEditar)
        {
            InitializeComponent();
            this.IdPlan = parametro;
            this.bandera = IsNuevoEditar;
        }

        private void NuevoEditarPlan_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtPlan;
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
                this.MostrarPlan(this.IdPlan);
            }
        }

        // Carga los valores en los campos de texto del formulario para que se modifiquen los que se desean
        private void MostrarPlan(int IdPlan)
        {
            respuesta = objetoCL.MostrarPlan(IdPlan);

            Console.WriteLine("Respuesta es ; " + respuesta.Rows.Count);
            foreach (DataRow row in respuesta.Rows)
            {
                Console.WriteLine("row IdPlan es :" + row["IdPlan"]);

                IdPlan = Convert.ToInt32(row["IdPlan"]);
                Plan = Convert.ToString(row["Plan"]);
                Precio = Convert.ToInt32(row["Precio"]);
                CantClases = Convert.ToInt32(row["CantClases"]);
                Descripcion = Convert.ToString(row["Descripcion"]);

                txtPlan.Text = Plan;
                txtPrecio.Text = Convert.ToString(Precio);
                txtCantClases.Text = Convert.ToString(CantClases);
                rtbObservaciones.Text = Descripcion;
            }
        }
    }
}
