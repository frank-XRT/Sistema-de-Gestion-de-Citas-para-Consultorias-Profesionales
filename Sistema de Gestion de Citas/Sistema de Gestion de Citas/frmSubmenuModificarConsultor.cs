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
    public partial class frmSubmenuModificarConsultor : Form
    {
        public frmSubmenuModificarConsultor()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnEditarConsultor_Click(object sender, EventArgs e)
        {
            frmOpcionesEditarConsultor form = new frmOpcionesEditarConsultor();
            form.Show();
            this.Hide();
        }

        private void btnEliminarConsultor_Click(object sender, EventArgs e)
        {
            frmEliminarConsultor form = new frmEliminarConsultor();
            form.Show();
            this.Hide();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            frmMenuAdministrador form = new frmMenuAdministrador();
            form.Show();
            this.Hide();
        }
    }
}
