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
    public partial class frmMisCitas : Form
    {
        private CCliente clienteActual;
        CControlador controlador = new CControlador();
        public frmMisCitas(CCliente cliente)
        {
            InitializeComponent();
            clienteActual = cliente;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(236, 253, 245);
        }
        private void MostrarMisCitas()
        {
            dgvMisCitas.DataSource = null;
            dgvMisCitas.DataSource = controlador.ListarCitasPorCliente(clienteActual.Codigo);
        }
        private void btnVolver_Click(object sender, EventArgs e)
        {
            frmMenuCliente form = new frmMenuCliente(clienteActual);
            form.Show();
            this.Hide();
        }
    }
}
