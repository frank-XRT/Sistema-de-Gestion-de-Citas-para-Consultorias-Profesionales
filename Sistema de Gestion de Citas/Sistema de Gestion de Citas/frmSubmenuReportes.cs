using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Sistema_de_Gestion_de_Citas
{
    public partial class frmSubmenuReportes : Form
    {
        public frmSubmenuReportes()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnReporteCitasServicio_Click(object sender, EventArgs e)
        {
            frmDiagramaCitasServicio form = new frmDiagramaCitasServicio();
            form.ShowDialog();
        }

        private void btnReporteConsultoresRubro_Click(object sender, EventArgs e)
        {
            frmDiagramaConsultoresRubro form = new frmDiagramaConsultoresRubro();
            form.ShowDialog();
        }

        private void btnReporteIngresosRubro_Click(object sender, EventArgs e)
        {
            frmDiagramaIngresosRubro form = new frmDiagramaIngresosRubro();
            form.ShowDialog();
        }

        private void btnReporteEstadosPorArea_Click(object sender, EventArgs e)
        {
            frmReporteEstados form = new frmReporteEstados();
            form.ShowDialog();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            frmMenuAdministrador form = new frmMenuAdministrador();
            form.Show();
            this.Hide();
        }
    }
}
