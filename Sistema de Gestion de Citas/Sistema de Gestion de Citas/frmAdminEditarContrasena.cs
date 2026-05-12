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
    public partial class frmAdminEditarContrasena : System.Windows.Forms.Form
    {
        private CConsultor consultorAEditar;

        public frmAdminEditarContrasena(CConsultor consultor)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.consultorAEditar = consultor;
        }

        private void frmAdminEditarContrasena_Load(object sender, EventArgs e)
        {
            lblConsultorNombre.Text = "Consultor: " + consultorAEditar.Nombre;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNuevaContrasena.Text == "" || txtConfirmarContrasena.Text == "")
            {
                MessageBox.Show("Debe completar ambos campos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtNuevaContrasena.Text != txtConfirmarContrasena.Text)
            {
                MessageBox.Show("Las contrasenas no coinciden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            consultorAEditar.Contrasena = txtNuevaContrasena.Text;
            
            MessageBox.Show("contrasena actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
