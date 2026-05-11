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
    public partial class frmModificarContrasena : Form
    {
        private CConsultor consultorActual;

        public frmModificarContrasena()
        {
            InitializeComponent();
        }

        public frmModificarContrasena(CConsultor consultor)
        {
            InitializeComponent();
            consultorActual = consultor;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            string actual = txtContrasenaActual.Text;
            string nueva = txtContrasenaNueva.Text;
            string verificar = txtVerificarContrasena.Text;

            if (actual == "" || nueva == "" || verificar == "")
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (actual != consultorActual.Contrasena)
            {
                MessageBox.Show("La contrasena actual es incorrecta.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (nueva != verificar)
            {
                MessageBox.Show("Las contrasenas no coinciden.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (nueva == actual)
            {
                MessageBox.Show("La nueva contrasena debe ser diferente a la actual.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            consultorActual.Contrasena = nueva;
            MessageBox.Show("contrasena modificada exitosamente.", "Exito",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
