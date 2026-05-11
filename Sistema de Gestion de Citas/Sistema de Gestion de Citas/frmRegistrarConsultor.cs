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
    public partial class frmRegistrarConsultor : Form
    {
        CControlador controlador = new CControlador();
        public frmRegistrarConsultor()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void frmRegistrarConsultor_Load(object sender, EventArgs e)
        {
            MostrarConsultores();
        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "" ||
                txtDni.Text == "" ||
                cboxSexo.Text == "" ||
                txtTelefono.Text == "" ||
                txtCorreo.Text == "" ||
                cboxRubro.Text == "" ||
                txtDescripcion.Text == "" ||
                txtMonto.Text == "" ||
                txtContrasena.Text == "")
            {
                MessageBox.Show("Complete todos los campos");
                return;
            }

            if (!CControlador.ValidarDni(txtDni.Text))
            {
                MessageBox.Show("El DNI debe tener al menos 8 dígitos y contener solo números");
                return;
            }

            CConsultor consultor = new CConsultor();

            consultor.Nombre = txtNombre.Text;
            consultor.Dni = txtDni.Text;
            consultor.Sexo = cboxSexo.Text;
            consultor.Telefono = txtTelefono.Text;
            consultor.Correo = txtCorreo.Text;
            consultor.Rubro = cboxRubro.Text;
            consultor.Descripcion = txtDescripcion.Text;
            consultor.Monto = decimal.Parse(txtMonto.Text);
            consultor.Contrasena = txtContrasena.Text;

            bool registrado = controlador.RegistrarConsultor(consultor);

            if (registrado)
            {
                MessageBox.Show("Consultor registrado correctamente");

                controlador.GenerarHorarios(consultor.ID, DateTime.Today);

                Limpiar();
                MostrarConsultores();
            }
            else
            {
                MessageBox.Show("El DNI ya esta registrado");
            }
        }
        private void MostrarConsultores()
        {
            dgvConsultores.DataSource = null;
            dgvConsultores.DataSource = CControlador.ListaConsultores;

            if (dgvConsultores.Columns["id"] != null)
            {
                dgvConsultores.Columns["id"].Visible = false;
            }
        }

        private void Limpiar()
        {
            txtNombre.Clear();
            txtDni.Clear();
            cboxSexo.SelectedIndex = -1;
            txtTelefono.Clear();
            txtCorreo.Clear();
            cboxRubro.SelectedIndex = -1;
            txtDescripcion.Clear();
            txtMonto.Clear();
            txtContrasena.Clear();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            frmMenuAdministrador form = new frmMenuAdministrador();
            form.Show();
            this.Hide();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}

