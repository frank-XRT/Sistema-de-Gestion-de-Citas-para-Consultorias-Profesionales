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
    public partial class frmReporteCitas : Form
    {
        // Constructor requerido por el diseñador de Visual Studio
        public frmReporteCitas() 
        { 
            InitializeComponent(); 
        }

        public frmReporteCitas(dynamic resumen) : this()
        {
            this.StartPosition = FormStartPosition.CenterScreen;

            // Asignar los valores a los labels si hay datos
            if (resumen != null)
            {
                lblCitasHoy.Text = resumen.Hoy.ToString();
                lblCitasMes.Text = resumen.Mes.ToString();
                lblTotalCitas.Text = resumen.Total.ToString();
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
