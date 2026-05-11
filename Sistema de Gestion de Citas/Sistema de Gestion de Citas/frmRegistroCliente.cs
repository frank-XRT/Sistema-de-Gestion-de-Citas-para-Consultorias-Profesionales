using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "" ||
                txtDni.Text == "" ||
                cboxSexo.Text == "" ||
                txtTelefono.Text == "" ||
                txtCorreo.Text == "" ||
                txtContrasena.Text == "" ||
                txtConfirmarContrasena.Text == "")
            {
                MessageBox.Show("Complete todos los campos");
                return;
            }

            if (!CControlador.ValidarDni(txtDni.Text))
            {
                MessageBox.Show("El DNI debe tener al menos 8 dígitos y contener solo números");
                return;
            }

            if (txtContrasena.Text != txtConfirmarContrasena.Text)
            {
                MessageBox.Show("Las contrasenas no coinciden");
                return;
            }

            CCliente cliente = new CCliente();

            cliente.Nombre = txtNombre.Text;
            cliente.Dni = txtDni.Text;
            cliente.Sexo = cboxSexo.Text;
            cliente.Telefono = txtTelefono.Text;
            cliente.Correo = txtCorreo.Text;
            cliente.Contrasena = txtContrasena.Text;

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

