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

            var datos = reporte.CitasPorServicio();

            Form form = new Form();
            form.Text = "Reporte de citas por servicio";
            form.Width = 600;
            form.Height = 400;

            DataGridView dgv = new DataGridView();
            dgv.Dock = DockStyle.Fill;
            dgv.DataSource = datos;

            form.Controls.Add(dgv);
            form.ShowDialog();
        }

        private void btnReporteConsultoresRubro_Click(object sender, EventArgs e)
        {
            CReporte reporte = new CReporte();

            var datos = reporte.ConsultoresPorRubro();

            Form form = new Form();
            form.Text = "Reporte de consultores por rubro";
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
