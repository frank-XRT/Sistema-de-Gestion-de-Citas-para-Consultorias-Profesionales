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
        // Constructor requerido por el diseñador de Visual Studio
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

        private void btnReporteCitas_Click(object sender, EventArgs e)
        {
            CReporte reporte = new CReporte();
            var resumen = reporte.ObtenerResumenCitas(consultorActual.Codigo);

            // Ahora usamos la ventana independiente que creamos
            frmReporteCitas form = new frmReporteCitas(resumen);
            form.ShowDialog();
        }

        private void btnReporteIngresos_Click(object sender, EventArgs e)
        {
            CReporte reporte = new CReporte();

            // Obtenemos datos para ambos trimestres
            var datosT1 = reporte.IngresosMensualesPorTrimestre(consultorActual.Codigo, 1);
            var datosT2 = reporte.IngresosMensualesPorTrimestre(consultorActual.Codigo, 2);

            // Sumamos los totales de cada trimestre para tener una sola barra por cada uno
            decimal totalT1 = 0;
            foreach (dynamic item in datosT1) totalT1 += item.Ingreso;

            decimal totalT2 = 0;
            foreach (dynamic item in datosT2) totalT2 += item.Ingreso;

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

            // Serie de datos
            Series serie = new Series("Ingresos");
            serie.ChartType = SeriesChartType.Column;
            serie.IsValueShownAsLabel = true;
            serie.Label = "S/ #VALY";

            // Barra 1: Trimestre 1
            serie.Points.AddXY("Trimestre 1 (ENE-FEB-MAR)", totalT1);

            // Barra 2: Trimestre 2
            serie.Points.AddXY("Trimestre 2 (ABR-MAY-JUN)", totalT2);

            chart.Series.Add(serie);
            
            chart.Titles.Add("Comparativa de Ingresos por Trimestre");

            form.Controls.Add(chart);
            form.ShowDialog();
        }

        private void btnReporteClientesFrecuentes_Click(object sender, EventArgs e)
        {
            frmClientesFrecuentes form = new frmClientesFrecuentes(consultorActual.Codigo);
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
