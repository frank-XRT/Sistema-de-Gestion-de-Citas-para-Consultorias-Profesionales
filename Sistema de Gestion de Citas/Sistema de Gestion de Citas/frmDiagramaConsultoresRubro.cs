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
    public partial class frmDiagramaConsultoresRubro : Form
    {
        public frmDiagramaConsultoresRubro()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            CargarDatos();
        }

        private void CargarDatos()
        {
            CReporte reporte = new CReporte();
            List<object> datos = reporte.ConsultoresPorRubro();

            if (datos.Count == 0)
            {
                MessageBox.Show("No hay datos para mostrar en el reporte.");
                return;
            }

            chartConsultores.Series[0].Points.Clear();

            foreach (object itemObj in datos)
            {
                CConsultorPorRubro item = (CConsultorPorRubro)itemObj;
                chartConsultores.Series[0].Points.AddXY(item.Rubro, item.CantidadConsultores);
            }
        }
    }
}
