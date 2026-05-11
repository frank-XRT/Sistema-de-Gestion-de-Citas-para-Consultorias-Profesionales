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
            CReporte reporte = new CReporte();

            List<object> datos = reporte.CitasPorServicio(
                DateTime.Today.AddMonths(-1),
                DateTime.Today
            );

            if (datos.Count == 0)
            {
                MessageBox.Show("No hay citas registradas para mostrar en el reporte.");
                return;
            }

            Form form = new Form();
            form.Text = "Reporte de citas por rubro";
            form.Width = 800;
            form.Height = 500;
            form.StartPosition = FormStartPosition.CenterScreen;

            Chart chart = new Chart();
            chart.Dock = DockStyle.Fill;

            ChartArea area = new ChartArea("Area1");
            chart.ChartAreas.Add(area);

            Legend leyenda = new Legend("Leyenda1");
            chart.Legends.Add(leyenda);

            Series serie = new Series("CitasPorRubro");
            serie.ChartType = SeriesChartType.Pie;
            serie.IsValueShownAsLabel = true;
            serie.Label = "#PERCENT{P0}";
            serie.LegendText = "#VALX";

            foreach (object itemObj in datos)
            {
                CCitaPorRubro item = (CCitaPorRubro)itemObj;
                serie.Points.AddXY(item.Rubro, item.CantidadCitas);
            }

            chart.Series.Add(serie);
            chart.Titles.Add("Distribucion de citas por Rubro");

            form.Controls.Add(chart);
            form.ShowDialog();
        }

        private void btnReporteConsultoresRubro_Click(object sender, EventArgs e)
        {
            CReporte reporte = new CReporte();

            List<object> datos = reporte.ConsultoresPorRubro();

            if (datos.Count == 0)
            {
                MessageBox.Show("No hay datos para mostrar en el reporte.");
                return;
            }

            Form form = new Form();
            form.Text = "Reporte de consultores por rubro";
            form.Width = 800;
            form.Height = 500;
            form.StartPosition = FormStartPosition.CenterScreen;

            Chart chart = new Chart();
            chart.Dock = DockStyle.Fill;

            ChartArea area = new ChartArea("Area1");
            area.AxisX.Title = "Rubro";
            area.AxisY.Title = "Numero de consultores";
            area.AxisX.Interval = 1;
            chart.ChartAreas.Add(area);

            Legend leyenda = new Legend("Leyenda1");
            chart.Legends.Add(leyenda);

            Series serie = new Series("ConsultoresPorRubro");
            serie.ChartType = SeriesChartType.Column; // grafico de barras verticales
            serie.IsValueShownAsLabel = true;
            serie.LegendText = "Consultores";

            foreach (object itemObj in datos)
            {
                CConsultorPorRubro item = (CConsultorPorRubro)itemObj;
                serie.Points.AddXY(item.Rubro, item.CantidadConsultores);
            }

            chart.Series.Add(serie);
            chart.Titles.Add("Reporte de consultores por rubro");

            form.Controls.Add(chart);
            form.ShowDialog();
        }

        private void btnReporteIngresosRubro_Click(object sender, EventArgs e)
        {
            CReporte reporte = new CReporte();

            List<object> datos = reporte.IngresosPorServicio(
                DateTime.Today.AddMonths(-1),
                DateTime.Today
            );

            if (datos.Count == 0)
            {
                MessageBox.Show("No hay ingresos registrados para mostrar en el reporte.");
                return;
            }

            Form form = new Form();
            form.Text = "Reporte de ingresos por rubro";
            form.Width = 800;
            form.Height = 500;
            form.StartPosition = FormStartPosition.CenterScreen;

            Chart chart = new Chart();
            chart.Dock = DockStyle.Fill;

            ChartArea area = new ChartArea("Area1");
            area.AxisX.Title = "Rubro";
            area.AxisY.Title = "Total Ingresos (S/)";
            area.AxisX.Interval = 1;
            chart.ChartAreas.Add(area);

            Series serie = new Series("IngresosPorRubro");
            serie.ChartType = SeriesChartType.Column;
            serie.IsValueShownAsLabel = true;
            serie.Label = "S/ #VALY";

            foreach (object itemObj in datos)
            {
                CIngresoPorRubro item = (CIngresoPorRubro)itemObj;
                serie.Points.AddXY(item.Rubro, item.TotalIngresos);
            }

            chart.Series.Add(serie);
            chart.Titles.Add("Distribucion de ingresos por rubro");

            form.Controls.Add(chart);
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
