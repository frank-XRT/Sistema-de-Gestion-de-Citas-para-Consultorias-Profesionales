using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Sistema_de_Gestion_de_Citas
{
    public partial class frmMenuConsultor : Form
    {
        private CConsultor consultorActual;
        public frmMenuConsultor() { InitializeComponent(); }

        public frmMenuConsultor(CConsultor consultor)
        {
            InitializeComponent();
            consultorActual = consultor;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnConsultarCitas_Click(object sender, EventArgs e)
        {
            frmConsultarCitas form = new frmConsultarCitas(consultorActual);
            form.Show();
            this.Hide();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            frmSubmenuReportesConsultor form = new frmSubmenuReportesConsultor(consultorActual);
            form.ShowDialog();
        }

        private void btnModificarContrasena_Click(object sender, EventArgs e)
        {
            frmModificarContrasena form = new frmModificarContrasena(consultorActual);
            form.ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            frmLogin form = new frmLogin();
            form.Show();
            this.Hide();
        }
    }
}
