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
        public frmMisCitas() { InitializeComponent(); }

        public frmMisCitas(CCliente cliente)
        {   
            InitializeComponent();
            clienteActual = cliente;
            this.StartPosition = FormStartPosition.CenterScreen;
            MostrarMisCitas();
        }
        private void MostrarMisCitas()
        {
            dgvMisCitas.DataSource = null;
            dgvMisCitas.DataSource = controlador.ListarCitasDetalladasPorCliente(clienteActual.ID);
            if (dgvMisCitas.Columns["id"] != null)
            {
                dgvMisCitas.Columns["id"].Visible = false;
            }
        }
        private void btnVolver_Click(object sender, EventArgs e)
        {
            frmMenuCliente form = new frmMenuCliente(clienteActual);
            form.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (dgvMisCitas.SelectedRows.Count > 0)
            {
                int idCita = Convert.ToInt32(dgvMisCitas.SelectedRows[0].Cells["id"].Value);
                string estadoCita = dgvMisCitas.SelectedRows[0].Cells["Estado"].Value.ToString();
                
                if (estadoCita == "Pendiente")
                {
                    DialogResult dialogResult = MessageBox.Show("¿Está seguro que desea cancelar esta cita?", "Confirmar", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        if (controlador.CancelarCita(idCita))
                        {
                            MessageBox.Show("Cita cancelada correctamente.");
                            MostrarMisCitas();
                        }
                        else
                        {
                            MessageBox.Show("Error al cancelar la cita.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Solo se pueden cancelar citas en estado 'Pendiente'.");
                }
            }
            else
            {
                MessageBox.Show("Seleccione la fila de la cita que desea cancelar.");
            }
        }
    }
}
