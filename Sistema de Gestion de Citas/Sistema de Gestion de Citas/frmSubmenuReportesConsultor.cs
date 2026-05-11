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
            CReporte reporte = new CReporte();

            List<object> datosT1 = reporte.IngresosMensualesPorTrimestre(consultorActual.ID, 1);
            List<object> datosT2 = reporte.IngresosMensualesPorTrimestre(consultorActual.ID, 2);

            decimal totalT1 = 0;
            foreach (object itemObj in datosT1)
            {
                CIngresoTrimestral item = (CIngresoTrimestral)itemObj;
                totalT1 += item.Ingreso;
            }

            decimal totalT2 = 0;
            foreach (object itemObj in datosT2)
            {
                CIngresoTrimestral item = (CIngresoTrimestral)itemObj;
                totalT2 += item.Ingreso;
            }

            if (totalT1 == 0 && totalT2 == 0)
            {   
                MessageBox.Show("No hay ingresos registrados en el primer semestre.");
                return;
            }

            Form form = new Form();
            form.Text = "Reporte de ingresos por trimestres";
            form.Width = 800;
            form.Height = 500;
            form.StartPosition = FormStartPosition.CenterScreen;

            Chart chart = new Chart();
            chart.Dock = DockStyle.Fill;

            ChartArea area = new ChartArea("Area1");
            area.AxisX.Title = "Trimestres";
            area.AxisY.Title = "Ingresos Totales (S/)";
            chart.ChartAreas.Add(area);

            Series serie = new Series("Ingresos");
            serie.ChartType = SeriesChartType.Column;
            serie.IsValueShownAsLabel = true;
            serie.Label = "S/ #VALY";

            serie.Points.AddXY("Trimestre 1 (ENE-FEB-MAR)", totalT1);
            serie.Points.AddXY("Trimestre 2 (ABR-MAY-JUN)", totalT2);

            chart.Series.Add(serie);
            chart.Titles.Add("Comparativa de Ingresos por Trimestre");

            form.Controls.Add(chart);
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
