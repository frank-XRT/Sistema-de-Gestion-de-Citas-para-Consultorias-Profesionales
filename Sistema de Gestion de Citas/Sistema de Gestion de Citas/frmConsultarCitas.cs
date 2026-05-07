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
    public partial class frmConsultarCitas : Form
    {
        private CConsultor consultorActual;
        CControlador controlador = new CControlador();
        // Constructor requerido por el diseñador de Visual Studio
        public frmConsultarCitas()
        {
            InitializeComponent();
        }

        public frmConsultarCitas(CConsultor consultor)
        {
            InitializeComponent();

            if (this.DesignMode) return;

            consultorActual = consultor;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(236, 253, 245);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DateTime fecha = dtpFecha.Value.Date;

            var citas = controlador.ListarCitasPorConsultor(consultorActual.Codigo)
                .Where(c =>
                {
                    CHorarioConsultor horario = CControlador.ListaHorarios
                        .Find(h => h.Codigo == c.CodigoHorario);

                    if (horario == null)
                    {
                        return false;
                    }

                    return horario.FechaHoraInicio.Date == fecha;
                })
                .ToList();

            dgvCitas.DataSource = null;
            dgvCitas.DataSource = citas;
        }

        private void btnAtender_Click(object sender, EventArgs e)
        {
            if (dgvCitas.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una cita");
                return;
            }

            CCita cita = (CCita)dgvCitas.CurrentRow.DataBoundItem;

            bool atendida = controlador.MarcarCitaComoAtendida(cita.Codigo);

            if (atendida)
            {
                MessageBox.Show("Cita marcada como atendida");
                MostrarCitas();
            }
            else
            {
                MessageBox.Show("No se pudo actualizar la cita");
            }
        }

        private void MostrarCitas()
        {
            dgvCitas.DataSource = null;
            dgvCitas.DataSource = controlador.ListarCitasPorConsultor(consultorActual.Codigo);
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            frmMenuConsultor form = new frmMenuConsultor(consultorActual);
            form.Show();
            this.Hide();
        }
    }
}
