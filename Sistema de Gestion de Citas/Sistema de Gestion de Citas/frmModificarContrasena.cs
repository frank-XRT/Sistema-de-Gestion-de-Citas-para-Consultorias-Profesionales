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
    public partial class frmModificarContrasena : Form
    {
        private CConsultor consultorActual;

        // Constructor requerido por el diseñador de Visual Studio
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
            string actual = txtContrasenaActual.Text.Trim();
            string nueva = txtContrasenaNueva.Text.Trim();
            string verificar = txtVerificarContrasena.Text.Trim();

            // Validar que no esten vacios
            if (string.IsNullOrEmpty(actual) || string.IsNullOrEmpty(nueva) || string.IsNullOrEmpty(verificar))
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar contraseña actual
            if (actual != consultorActual.Contraseña)
            {
                MessageBox.Show("La contrasena actual es incorrecta.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validar que las nuevas coincidan
            if (nueva != verificar)
            {
                MessageBox.Show("Las contrasenas no coinciden.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validar que la nueva sea diferente a la actual
            if (nueva == actual)
            {
                MessageBox.Show("La nueva contrasena debe ser diferente a la actual.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Cambiar la contraseña
            consultorActual.Contraseña = nueva;
            MessageBox.Show("Contrasena modificada exitosamente.", "Exito",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
