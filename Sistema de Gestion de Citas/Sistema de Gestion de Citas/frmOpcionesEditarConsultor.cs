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
    public partial class frmOpcionesEditarConsultor : Form
    {
        private CConsultor consultorEncontrado = null;

        public frmOpcionesEditarConsultor()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string dniBuscar = txtDniBuscar.Text;
            if (dniBuscar == "")
            {
                MessageBox.Show("Ingrese un DNI para buscar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!CControlador.ValidarDni(dniBuscar))
            {
                MessageBox.Show("El DNI debe tener al menos 8 dígitos y contener solo números", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            consultorEncontrado = null;
            foreach (CConsultor c in CControlador.ListaConsultores)
            {
                if (c.Dni == dniBuscar)
                {
                    consultorEncontrado = c;
                    break;
                }
            }

            if (consultorEncontrado != null)
            {
                lblConsultorEncontrado.Text = consultorEncontrado.Nombre;
            }
            else
            {
                lblConsultorEncontrado.Text = "-";
                consultorEncontrado = null;
                MessageBox.Show("Consultor no encontrado con ese DNI.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditarContrasena_Click(object sender, EventArgs e)
        {
            if (consultorEncontrado != null)
            {
                frmAdminEditarContrasena form = new frmAdminEditarContrasena(consultorEncontrado);
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Por favor, busque un consultor primero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEditarOtrosCampos_Click(object sender, EventArgs e)
        {
            if (consultorEncontrado != null)
            {
                frmEditarConsultor form = new frmEditarConsultor(consultorEncontrado);
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Por favor, busque un consultor primero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
