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
            // Seleccionar la primera opcion del combo por defecto si tiene items
            if (cmbArea.Items.Count > 0) cmbArea.SelectedIndex = 0;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cmbArea.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione un area.");
                return;
            }

            string areaSeleccionada = cmbArea.SelectedItem.ToString();
            DateTime inicio = dtpFechaInicial.Value;
            DateTime fin = dtpFechaFinal.Value;

            CReporte reporte = new CReporte();
            var resultados = reporte.EstadisticasPorArea(areaSeleccionada, inicio, fin);

            // Mostrar los resultados en los labels
            lblAsistidas.Text = resultados.Asistidas.ToString();
            lblCanceladas.Text = resultados.Canceladas.ToString();
            lblNoAsistidas.Text = resultados.NoAsistidas.ToString();
        }
    }
}
