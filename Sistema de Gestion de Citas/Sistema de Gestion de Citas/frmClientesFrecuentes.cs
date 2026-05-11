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
    public partial class frmClientesFrecuentes : Form
    {
        public frmClientesFrecuentes()
        {
            InitializeComponent();
        }

        public frmClientesFrecuentes(int IDConsultor) : this()
        {
            this.StartPosition = FormStartPosition.CenterScreen;

            CReporte reporte = new CReporte();
            var datos = reporte.ClientesMasFrecuentes(IDConsultor);

            dgvClientes.Rows.Clear();
            foreach (dynamic item in datos)
            {
                dgvClientes.Rows.Add(item.NombreCliente, item.NumeroCitas);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
