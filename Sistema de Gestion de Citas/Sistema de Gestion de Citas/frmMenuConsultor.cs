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
        public frmMenuConsultor(CConsultor consultor)
        {
            InitializeComponent();
            consultorActual = consultor;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(236, 253, 245);
        }

        private void btnConsultarCitas_Click(object sender, EventArgs e)
        {
            frmConsultarCitas form = new frmConsultarCitas(consultorActual);
            form.Show();
            this.Hide();
        }

        private void btnReporteCitas_Click(object sender, EventArgs e)
        {
            CControlador controlador = new CControlador();

            var datos = controlador.ListarCitasPorConsultor(consultorActual.Codigo);

            Form form = new Form();
            form.Text = "Reporte de citas";
            form.Width = 600;
            form.Height = 400;

            DataGridView dgv = new DataGridView();
            dgv.Dock = DockStyle.Fill;
            dgv.DataSource = datos;

            form.Controls.Add(dgv);
            form.ShowDialog();
        }

        private void btnReporteIngresos_Click(object sender, EventArgs e)
        {
            int trimestre = 2; // Por ahora primer trimestre

            CReporte reporte = new CReporte();

            var datos = reporte.IngresosMensualesPorTrimestre(consultorActual.Codigo, trimestre);

            if (datos.Count == 0)
            {   
                MessageBox.Show("No hay ingresos registrados para este trimestre.");
                return;
            }

            Form form = new Form();
            form.Text = "Reporte de ingresos por trimestre";
            form.Width = 800;
            form.Height = 500;
            form.StartPosition = FormStartPosition.CenterScreen;

            Chart chart = new Chart();
            chart.Dock = DockStyle.Fill;

            ChartArea area = new ChartArea("Area1");
            area.AxisX.Title = "Mes";
            area.AxisY.Title = "Ingresos";
            area.AxisX.Interval = 1;
            chart.ChartAreas.Add(area);

            Series serie = new Series("Ingresos");
            serie.ChartType = SeriesChartType.Column;
            serie.IsValueShownAsLabel = true;
            serie.Label = "S/ #VALY";

            decimal total = 0;

            foreach (dynamic item in datos)
            {
                serie.Points.AddXY(item.Mes, item.Ingreso);
                total += item.Ingreso;
            }

            chart.Series.Add(serie);
            chart.Titles.Add("Ingresos por trimestre - Total: S/ " + total.ToString("0.00"));

            form.Controls.Add(chart);
            form.ShowDialog();
        }

        private void btnReporteClientesFrecuentes_Click(object sender, EventArgs e)
        {
            CReporte reporte = new CReporte();

            var datos = reporte.ClientesMasFrecuentes(consultorActual.Codigo);

            Form form = new Form();
            form.Text = "Clientes más frecuentes";
            form.Width = 600;
            form.Height = 400;

            DataGridView dgv = new DataGridView();
            dgv.Dock = DockStyle.Fill;
            dgv.DataSource = datos;

            form.Controls.Add(dgv);
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
