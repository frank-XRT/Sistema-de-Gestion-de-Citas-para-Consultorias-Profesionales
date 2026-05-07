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
            CReporte reporte = new CReporte();
            var resumen = reporte.ObtenerResumenCitas(consultorActual.Codigo);

            Form form = new Form();
            form.Text = "Reporte de Citas";
            form.Size = new Size(600, 450);
            form.StartPosition = FormStartPosition.CenterScreen;
            form.BackColor = Color.FromArgb(236, 253, 245); // Color del menú consultor (verde menta claro)
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.MaximizeBox = false;

            Panel pnlContenedor = new Panel();
            pnlContenedor.Dock = DockStyle.Fill;
            pnlContenedor.Padding = new Padding(40);
            form.Controls.Add(pnlContenedor);

            // Estilos de fuente
            Font fontTitulo = new Font("Segoe UI", 24, FontStyle.Bold);
            Font fontValor = new Font("Segoe UI", 24, FontStyle.Bold);
            Color colorTexto = Color.Black;

            // Fila 1: Hoy
            Label lblHoyTitulo = new Label { Text = "Citas atendidas Hoy", Font = fontTitulo, AutoSize = true, Location = new Point(40, 60), ForeColor = colorTexto };
            Label lblHoyValor = new Label { Text = resumen.Hoy.ToString(), Font = fontValor, Size = new Size(100, 50), Location = new Point(450, 60), ForeColor = colorTexto, TextAlign = ContentAlignment.TopRight };

            // Fila 2: Mes
            Label lblMesTitulo = new Label { Text = "Citas atendidas durante el mes", Font = fontTitulo, AutoSize = true, Location = new Point(40, 140), ForeColor = colorTexto };
            Label lblMesValor = new Label { Text = resumen.Mes.ToString(), Font = fontValor, Size = new Size(100, 50), Location = new Point(450, 140), ForeColor = colorTexto, TextAlign = ContentAlignment.TopRight };

            // Fila 3: Total
            Label lblTotalTitulo = new Label { Text = "Total de Citas atendidas", Font = fontTitulo, AutoSize = true, Location = new Point(40, 220), ForeColor = colorTexto };
            Label lblTotalValor = new Label { Text = resumen.Total.ToString(), Font = fontValor, Size = new Size(100, 50), Location = new Point(450, 220), ForeColor = colorTexto, TextAlign = ContentAlignment.TopRight };

            // Botón Volver
            Button btnVolver = new Button();
            btnVolver.Text = "Volver";
            btnVolver.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            btnVolver.Size = new Size(300, 60);
            btnVolver.Location = new Point(150, 320);
            btnVolver.BackColor = Color.White;
            btnVolver.FlatStyle = FlatStyle.Flat;
            btnVolver.Click += (s, ev) => form.Close();

            pnlContenedor.Controls.Add(lblHoyTitulo);
            pnlContenedor.Controls.Add(lblHoyValor);
            pnlContenedor.Controls.Add(lblMesTitulo);
            pnlContenedor.Controls.Add(lblMesValor);
            pnlContenedor.Controls.Add(lblTotalTitulo);
            pnlContenedor.Controls.Add(lblTotalValor);
            pnlContenedor.Controls.Add(btnVolver);

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
