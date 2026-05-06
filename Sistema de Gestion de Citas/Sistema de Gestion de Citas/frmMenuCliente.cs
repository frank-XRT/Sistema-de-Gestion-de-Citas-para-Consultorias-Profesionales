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
    public partial class frmMenuCliente : Form
    {
        private CCliente clienteActual;
        public frmMenuCliente(CCliente cliente)
        {
            InitializeComponent();
            clienteActual = cliente;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(236, 253, 245);
        }

        private void btnBuscarProfesional_Click(object sender, EventArgs e)
        {
            frmBuscarProfesional form = new frmBuscarProfesional(clienteActual);
            form.Show();
            this.Hide();
        }

        private void btnMisCitas_Click(object sender, EventArgs e)
        {
            frmMisCitas form = new frmMisCitas(clienteActual);
            form.Show();
            this.Hide();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            frmLogin form = new frmLogin();
            form.Show();
            this.Hide();
        }
    }
}
