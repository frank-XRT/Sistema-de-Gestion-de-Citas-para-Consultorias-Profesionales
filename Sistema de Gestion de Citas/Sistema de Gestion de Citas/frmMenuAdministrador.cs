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
    public partial class frmMenuAdministrador : Form
    {
        public frmMenuAdministrador()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnRegistrarConsultor_Click(object sender, EventArgs e)
        {
            frmRegistrarConsultor form = new frmRegistrarConsultor();
            form.Show();
            this.Hide();
        }

        private void btnEditarEliminarConsultor_Click(object sender, EventArgs e)
        {
            frmSubmenuModificarConsultor form = new frmSubmenuModificarConsultor();
            form.Show();
            this.Hide();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            frmSubmenuReportes form = new frmSubmenuReportes();
            form.Show();
            this.Hide();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            frmLogin form = new frmLogin();
            form.Show();
            this.Hide();
        }
    }
}
