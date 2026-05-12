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
    public partial class frmSubmenuReportesConsultor : Form
    {
        private CConsultor consultorActual;

        public frmSubmenuReportesConsultor() { InitializeComponent(); }

        public frmSubmenuReportesConsultor(CConsultor consultor)
        {
            InitializeComponent();
            consultorActual = consultor;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnReporteCitas_Click(object sender, EventArgs e)
        {
            CReporte reporte = new CReporte();
            CResumenCitas resumen = reporte.ObtenerResumenCitas(consultorActual.ID);
            frmReporteCitas form = new frmReporteCitas(resumen);
            form.ShowDialog();
        }

        private void btnReporteIngresos_Click(object sender, EventArgs e)
        {
            frmDiagramaIngresosConsultor form = new frmDiagramaIngresosConsultor(consultorActual);
            form.ShowDialog();
        }

        private void btnReporteClientesFrecuentes_Click(object sender, EventArgs e)
        {
            frmClientesFrecuentes form = new frmClientesFrecuentes(consultorActual.ID);
            form.ShowDialog();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
