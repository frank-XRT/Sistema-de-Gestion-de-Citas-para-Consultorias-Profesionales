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
            this.BackColor = Color.FromArgb(236, 253, 245);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el código del consultor");
                return;
            }

            int codigo = int.Parse(txtCodigo.Text);

            var resultado = CControlador.ListaConsultores
                .Where(c => c.Codigo == codigo)
                .ToList();

            dgvConsultores.DataSource = null;
            dgvConsultores.DataSource = resultado;

            if (dgvConsultores.Columns["Codigo"] != null) dgvConsultores.Columns["Codigo"].Visible = false;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el código del consultor");
                return;
            }

            int codigo = int.Parse(txtCodigo.Text);

            bool eliminado = controlador.EliminarConsultor(codigo);

            if (eliminado)
            {
                MessageBox.Show("Consultor eliminado correctamente");
                txtCodigo.Clear();
                MostrarConsultores();
            }
            else
            {
                MessageBox.Show("No se encontró el consultor");
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
