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
            CReporte reporte = new CReporte();

            decimal total = reporte.IngresosPorTrimestre(consultorActual.Codigo, 1);

            MessageBox.Show("Ingresos del primer trimestre: S/ " + total.ToString("0.00"));
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
