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
    public partial class frmRegistroCliente : Form
    {
        CControlador controlador = new CControlador();
        public frmRegistroCliente()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            txtDni.UseSystemPasswordChar = true;
        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text.Trim() == "" ||
                txtDni.Text.Trim() == "" ||
                cboxSexo.Text.Trim() == "" ||
                txtTelefono.Text.Trim() == "" ||
                txtCorreo.Text.Trim() == "" ||
                txtContraseña.Text.Trim() == "" ||
                txtConfirmarContraseña.Text.Trim() == "")
            {
                MessageBox.Show("Complete todos los campos");
                return;
            }

            if (txtContraseña.Text != txtConfirmarContraseña.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden");
                return;
            }

            CCliente cliente = new CCliente();

            cliente.Nombre = txtNombre.Text.Trim();
            cliente.Dni = txtDni.Text.Trim();
            cliente.Sexo = cboxSexo.Text.Trim();
            cliente.Telefono = txtTelefono.Text.Trim();
            cliente.Correo = txtCorreo.Text.Trim();
            cliente.Contraseña = txtContraseña.Text.Trim();

            bool registrado = controlador.RegistrarCliente(cliente);

            if (registrado)
            {
                MessageBox.Show("Cliente registrado correctamente");

                frmLogin form = new frmLogin();
                form.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("El DNI ya esta registrado");
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            frmLogin form = new frmLogin();
            form.Show();
            this.Hide();
        }
    }
}

