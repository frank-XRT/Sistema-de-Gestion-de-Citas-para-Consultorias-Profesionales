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
    public partial class frmMenuAdministrador : Form
    {
        public frmMenuAdministrador()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(236, 253, 245);
        }

        private void btnRegistrarConsultor_Click(object sender, EventArgs e)
        {
            frmRegistrarConsultor form = new frmRegistrarConsultor();
            form.Show();
            this.Hide();
        }

        private void btnEliminarConsultor_Click(object sender, EventArgs e)
        {
            frmEliminarConsultor form = new frmEliminarConsultor();
            form.Show();
            this.Hide();
        }

        private void btnReporteCitasServicio_Click(object sender, EventArgs e)
        {
            CReporte reporte = new CReporte();

            var datos = reporte.CitasPorServicio(
                DateTime.Today.AddMonths(-1),
                DateTime.Today
            );

            if (datos.Count == 0)
            {
                MessageBox.Show("No hay citas registradas para mostrar en el reporte.");
                return;
            }

            Form form = new Form();
            form.Text = "Reporte de citas por servicio";
            form.Width = 800;
            form.Height = 500;
            form.StartPosition = FormStartPosition.CenterScreen;

            Chart chart = new Chart();
            chart.Dock = DockStyle.Fill;

            ChartArea area = new ChartArea("Area1");
            chart.ChartAreas.Add(area);

            Legend leyenda = new Legend("Leyenda1");
            chart.Legends.Add(leyenda);

            Series serie = new Series("CitasPorServicio");
            serie.ChartType = SeriesChartType.Pie;
            serie.IsValueShownAsLabel = true;
            serie.Label = "#PERCENT{P0}";
            serie.LegendText = "#VALX";

            foreach (dynamic item in datos)
            {
                serie.Points.AddXY(item.Rubro, item.CantidadCitas);
            }

            chart.Series.Add(serie);
            chart.Titles.Add("Distribución de citas por servicio");

            form.Controls.Add(chart);
            form.ShowDialog();
        }

        private void btnReporteConsultoresRubro_Click(object sender, EventArgs e)
        {
            CReporte reporte = new CReporte();

            var datos = reporte.ConsultoresPorRubro();

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
            area.AxisX.Title = "Tipo de asesoría";
            area.AxisY.Title = "Número de consultores";
            area.AxisX.Interval = 1;
            chart.ChartAreas.Add(area);

            Legend leyenda = new Legend("Leyenda1");
            chart.Legends.Add(leyenda);

            Series serie = new Series("ConsultoresPorRubro");
            serie.ChartType = SeriesChartType.Column; // gráfico de barras verticales
            serie.IsValueShownAsLabel = true;
            serie.LegendText = "Consultores";

            foreach (dynamic item in datos)
            {
                serie.Points.AddXY(item.Rubro, item.CantidadConsultores);
            }

            chart.Series.Add(serie);
            chart.Titles.Add("Reporte de consultores por tipo de asesoría");

            form.Controls.Add(chart);
            form.ShowDialog();
        }

        private void btnReporteIngresosRubro_Click(object sender, EventArgs e)
        {
            CReporte reporte = new CReporte();

            var datos = reporte.IngresosPorServicio(
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

            foreach (dynamic item in datos)
            {
                serie.Points.AddXY(item.Rubro, item.TotalIngresos);
            }

            chart.Series.Add(serie);
            chart.Titles.Add("Distribución de ingresos por rubro");

            form.Controls.Add(chart);
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
