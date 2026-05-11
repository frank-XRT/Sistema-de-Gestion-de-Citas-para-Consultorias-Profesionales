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
    public partial class frmDiagramaIngresosConsultor : Form
    {
        private CConsultor consultorActual;

        public frmDiagramaIngresosConsultor(CConsultor consultor)
        {
            InitializeComponent();
            this.consultorActual = consultor;
            this.StartPosition = FormStartPosition.CenterScreen;
            CargarDatos();
        }

        private void CargarDatos()
        {
            CReporte reporte = new CReporte();

            List<object> datosT1 = reporte.IngresosMensualesPorTrimestre(consultorActual.ID, 1);
            List<object> datosT2 = reporte.IngresosMensualesPorTrimestre(consultorActual.ID, 2);

            decimal totalT1 = 0;
            foreach (object itemObj in datosT1)
            {
                CIngresoTrimestral item = (CIngresoTrimestral)itemObj;
                totalT1 += item.Ingreso;
            }

            decimal totalT2 = 0;
            foreach (object itemObj in datosT2)
            {
                CIngresoTrimestral item = (CIngresoTrimestral)itemObj;
                totalT2 += item.Ingreso;
            }

            if (totalT1 == 0 && totalT2 == 0)
            {   
                MessageBox.Show("No hay ingresos registrados en el primer semestre.");
                this.Close();
                return;
            }

            chartIngresos.Series[0].Points.Clear();
            chartIngresos.Series[0].Points.AddXY("Trimestre 1 (ENE-FEB-MAR)", totalT1);
            chartIngresos.Series[0].Points.AddXY("Trimestre 2 (ABR-MAY-JUN)", totalT2);
        }
    }
}
