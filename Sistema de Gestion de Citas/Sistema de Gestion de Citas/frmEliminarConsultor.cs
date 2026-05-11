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
            if (txtid.Text == "")
            {
                MessageBox.Show("Ingrese el DNI del consultor");
                return;
            }

            string dni = txtid.Text;

            List<CConsultor> resultado = new List<CConsultor>();

            foreach (CConsultor c in CControlador.ListaConsultores)
            {
                if (c.Dni == dni)
                {
                    resultado.Add(c);
                }
            }

            dgvConsultores.DataSource = null;
            dgvConsultores.DataSource = resultado;

            if (dgvConsultores.Columns["id"] != null)
            {
                dgvConsultores.Columns["id"].Visible = false;
            }

            if (resultado.Count == 0)
            {
                MessageBox.Show("No se encontro ningun consultor con ese DNI");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtid.Text == "")
            {
                MessageBox.Show("Ingrese el DNI del consultor");
                return;
            }

            string dni = txtid.Text;

            CConsultor consultor = null;
            foreach (CConsultor c in CControlador.ListaConsultores)
            {
                if (c.Dni == dni)
                {
                    consultor = c;
                    break;
                }
            }

            if (consultor == null)
            {
                MessageBox.Show("No se encontro el consultor con ese DNI");
                return;
            }

            bool eliminado = controlador.EliminarConsultor(consultor.ID);

            if (eliminado)
            {
                MessageBox.Show("Consultor eliminado correctamente");
                txtid.Clear();
                MostrarConsultores();
            }
            else
            {
                MessageBox.Show("No se pudo eliminar el consultor");
            }
        }

        private void btnHabilitar_Click(object sender, EventArgs e)
        {
            if (txtid.Text == "")
            {
                MessageBox.Show("Ingrese el DNI del consultor");
                return;
            }

            string dni = txtid.Text;

            CConsultor consultor = null;
            foreach (CConsultor c in CControlador.ListaConsultores)
            {
                if (c.Dni == dni)
                {
                    consultor = c;
                    break;
                }
            }

            if (consultor == null)
            {
                MessageBox.Show("No se encontro el consultor con ese DNI");
                return;
            }

            bool habilitado = controlador.HabilitarConsultor(consultor.ID);

            if (habilitado)
            {
                MessageBox.Show("Consultor habilitado correctamente");
                txtid.Clear();
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

            if (dgvConsultores.Columns["id"] != null)
            {
                dgvConsultores.Columns["id"].Visible = false;
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            frmMenuAdministrador form = new frmMenuAdministrador();
            form.Show();
            this.Hide();
        }
    }
}

