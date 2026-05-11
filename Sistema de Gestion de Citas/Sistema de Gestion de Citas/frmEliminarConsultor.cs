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
    public partial class frmEliminarConsultor : Form
    {
        CControlador controlador = new CControlador();

        public frmEliminarConsultor()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el DNI del consultor");
                return;
            }

            string dni = txtCodigo.Text.Trim();

            var resultado = CControlador.ListaConsultores
                .Where(c => c.Dni == dni)
                .ToList();

            dgvConsultores.DataSource = null;
            dgvConsultores.DataSource = resultado;

            if (dgvConsultores.Columns["Codigo"] != null) dgvConsultores.Columns["Codigo"].Visible = false;

            if (resultado.Count == 0)
                MessageBox.Show("No se encontro ningun consultor con ese DNI");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el DNI del consultor");
                return;
            }

            string dni = txtCodigo.Text.Trim();

            var consultor = CControlador.ListaConsultores.FirstOrDefault(c => c.Dni == dni);

            if (consultor == null)
            {
                MessageBox.Show("No se encontro el consultor con ese DNI");
                return;
            }

            bool eliminado = controlador.EliminarConsultor(consultor.Codigo);

            if (eliminado)
            {
                MessageBox.Show("Consultor eliminado correctamente");
                txtCodigo.Clear();
                MostrarConsultores();
            }
            else
            {
                MessageBox.Show("No se pudo eliminar el consultor");
            }
        }

        private void btnHabilitar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el DNI del consultor");
                return;
            }

            string dni = txtCodigo.Text.Trim();

            var consultor = CControlador.ListaConsultores.FirstOrDefault(c => c.Dni == dni);

            if (consultor == null)
            {
                MessageBox.Show("No se encontro el consultor con ese DNI");
                return;
            }

            bool habilitado = controlador.HabilitarConsultor(consultor.Codigo);

            if (habilitado)
            {
                MessageBox.Show("Consultor habilitado correctamente");
                txtCodigo.Clear();
                MostrarConsultores();
            }
            else
            {
                MessageBox.Show("No se pudo habilitar el consultor");
            }
        }
        private void MostrarConsultores()
        {
            dgvConsultores.DataSource = null;
            dgvConsultores.DataSource = CControlador.ListaConsultores;

            if (dgvConsultores.Columns["Codigo"] != null) dgvConsultores.Columns["Codigo"].Visible = false;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            frmMenuAdministrador form = new frmMenuAdministrador();
            form.Show();
            this.Hide();
        }
    }
}

