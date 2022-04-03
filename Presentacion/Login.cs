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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnAyuda_Click(object sender, EventArgs e)
        {
            Informacion frm = new Informacion();
            frm.Show();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            string Datos = Logica.CL_Usuarios.Login(this.txtUsuario.Text, this.txtContraseña.Text);
            //Evaluar si existe el Usuario
            if (Datos != "Ok")
            {
                MessageBox.Show("Error de login", "Movi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Dashboard frm = new Dashboard();
                frm.Show();
                this.Hide();

            }
        }
    }
}
