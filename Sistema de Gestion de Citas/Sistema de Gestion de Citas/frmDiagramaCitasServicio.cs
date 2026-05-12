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
    public partial class frmDiagramaCitasServicio : Form
    {
        public frmDiagramaCitasServicio()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            CargarDatos();
        }

        private void CargarDatos()
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

            chartCitas.Series[0].Points.Clear();

            chartCitas.Series[0].ChartType = SeriesChartType.Pie;
            chartCitas.Series[0].IsValueShownAsLabel = true;
            chartCitas.Series[0].Label = "#VALX: #PERCENT{P0}";
            chartCitas.Series[0]["PieLabelStyle"] = "Outside";
            chartCitas.Series[0]["PieLineColor"] = "Black";
            chartCitas.Series[0].LegendText = "#VALX";
            if (chartCitas.Legends.Count == 0)
            {
                chartCitas.Legends.Add(new Legend("Legend1"));
            }
            chartCitas.Legends[0].Enabled = true;

            foreach (object itemObj in datos)
            {
                CCitaPorRubro item = (CCitaPorRubro)itemObj;
                chartCitas.Series[0].Points.AddXY(item.Rubro, item.CantidadCitas);
            }
        }
    }
}
