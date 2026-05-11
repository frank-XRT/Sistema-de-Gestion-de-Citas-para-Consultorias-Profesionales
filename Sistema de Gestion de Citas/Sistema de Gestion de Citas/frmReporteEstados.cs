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
    public partial class frmReporteEstados : Form
    {
        public frmReporteEstados()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            if (cmbRubro.Items.Count > 0) cmbRubro.SelectedIndex = 0;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cmbRubro.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione un rubro.");
                return;
            }

            string rubroSeleccionada = cmbRubro.SelectedItem.ToString();
            DateTime inicio = dtpFechaInicial.Value;
            DateTime fin = dtpFechaFinal.Value;

            CReporte reporte = new CReporte();
            var resultados = reporte.EstadisticasPorRubro(rubroSeleccionada, inicio, fin);

            lblAsistidas.Text = resultados.Asistidas.ToString();
            lblCanceladas.Text = resultados.Canceladas.ToString();
            lblNoAsistidas.Text = resultados.NoAsistidas.ToString();
        }
    }
}
