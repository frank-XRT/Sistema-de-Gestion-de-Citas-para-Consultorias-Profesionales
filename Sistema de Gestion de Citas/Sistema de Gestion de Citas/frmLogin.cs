using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_Gestion_de_Citas
{
    public partial class frmLogin : Form
    {
        CControlador controlador = new CControlador();
        public frmLogin()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
            txtContrasena.UseSystemPasswordChar = true;
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            string dni = txtUsuario.Text.Trim();
            string contrasena = txtContrasena.Text.Trim();

            if (dni == "" || contrasena == "")
            {
                MessageBox.Show("Ingrese usuario y contrasena");
                return;
            }

            object usuario = controlador.Login(dni, contrasena);

            if (usuario == null)
            {
                MessageBox.Show("Usuario o contrasena incorrectos");
                return;
            }

            if (usuario is CAdministrador)
            {
                frmMenuAdministrador form = new frmMenuAdministrador();
                form.Show();
                this.Hide();
            }
            else if (usuario is CConsultor)
            {
                CConsultor consultor = (CConsultor)usuario;

                frmMenuConsultor form = new frmMenuConsultor(consultor);
                form.Show();
                this.Hide();
            }
            else if (usuario is CCliente)
            {
                CCliente cliente = (CCliente)usuario;

                frmMenuCliente form = new frmMenuCliente(cliente);
                form.Show();
                this.Hide();
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            frmRegistroCliente form = new frmRegistroCliente();
            form.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
