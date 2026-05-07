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
    public partial class frmRegistrarConsultor : Form
    {
        CControlador controlador = new CControlador();
        public frmRegistrarConsultor()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(236, 253, 245);
        }

        private void frmRegistrarConsultor_Load(object sender, EventArgs e)
        {
            MostrarConsultores();
        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text.Trim() == "" ||
                txtDni.Text.Trim() == "" ||
                cboxSexo.Text.Trim() == "" ||
                txtTelefono.Text.Trim() == "" ||
                txtCorreo.Text.Trim() == "" ||
                cboxRubro.Text.Trim() == "" ||
                txtDescripcion.Text.Trim() == "" ||
                txtMonto.Text.Trim() == "" ||
                txtContraseña.Text.Trim() == "")
            {
                MessageBox.Show("Complete todos los campos");
                return;
            }

            CConsultor consultor = new CConsultor();

            consultor.Nombre = txtNombre.Text.Trim();
            consultor.Dni = txtDni.Text.Trim();
            consultor.Sexo = cboxSexo.Text.Trim();
            consultor.Telefono = txtTelefono.Text.Trim();
            consultor.Correo = txtCorreo.Text.Trim();
            consultor.Rubro = cboxRubro.Text.Trim();
            consultor.Descripcion = txtDescripcion.Text.Trim();
            consultor.Monto = decimal.Parse(txtMonto.Text.Trim());
            consultor.Contraseña = txtContraseña.Text.Trim();

            bool registrado = controlador.RegistrarConsultor(consultor);

            if (registrado)
            {
                MessageBox.Show("Consultor registrado correctamente");

                controlador.GenerarHorarios(consultor.Codigo, DateTime.Today);

                Limpiar();
                MostrarConsultores();
            }
            else
            {
                MessageBox.Show("El DNI ya está registrado");
            }
        }
        private void MostrarConsultores()
        {
            dgvConsultores.DataSource = null;
            dgvConsultores.DataSource = CControlador.ListaConsultores;

            if (dgvConsultores.Columns["Codigo"] != null) dgvConsultores.Columns["Codigo"].Visible = false;
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
            txtContraseña.Clear();
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
