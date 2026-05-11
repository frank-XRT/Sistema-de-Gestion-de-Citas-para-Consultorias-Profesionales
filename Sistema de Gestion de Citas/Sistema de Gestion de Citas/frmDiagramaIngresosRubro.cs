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
    public partial class frmDiagramaIngresosRubro : Form
    {
        public frmDiagramaIngresosRubro()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            CargarDatos();
        }

        private void CargarDatos()
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

            chartIngresos.Series[0].Points.Clear();

            foreach (object itemObj in datos)
            {
                CIngresoPorRubro item = (CIngresoPorRubro)itemObj;
                chartIngresos.Series[0].Points.AddXY(item.Rubro, item.TotalIngresos);
            }
        }
    }
}
