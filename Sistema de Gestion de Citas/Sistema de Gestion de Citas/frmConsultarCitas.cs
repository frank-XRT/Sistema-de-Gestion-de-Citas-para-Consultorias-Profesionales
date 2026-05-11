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
            MostrarCitas();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DateTime fecha = dtpFecha.Value.Date;

            var citas = (from c in controlador.ListarCitasPorConsultor(consultorActual.ID)
                        join cl in CControlador.ListaClientes on c.IDCliente equals cl.ID
                        join h in CControlador.ListaHorarios on c.IDHorario equals h.ID
                        where h.FechaHoraInicio.Date == fecha
                        select new
                        {
                            ID = c.ID,
                            Cliente = cl.Nombre,
                            Fecha = h.FechaHoraInicio.ToString("dd/MM/yyyy"),
                            Hora = h.FechaHoraInicio.ToString("HH:mm") + " - " + h.FechaHoraFin.ToString("HH:mm"),
                            Monto = c.Monto,
                            Descripcion = c.Descripcion,
                            Estado = c.Estado
                        }).ToList();

            dgvCitas.DataSource = null;
            dgvCitas.DataSource = citas;
            if (dgvCitas.Columns["id"] != null) dgvCitas.Columns["id"].Visible = false;
        }

        private void btnAtender_Click(object sender, EventArgs e)
        {
            if (dgvCitas.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una cita");
                return;
            }

            // Al usar un objeto anonimo, obtenemos el id para buscar la cita real
            int idCita = (int)dgvCitas.CurrentRow.Cells["id"].Value;

            bool atendida = controlador.MarcarCitaComoAtendida(idCita);

            if (atendida)
            {
                MessageBox.Show("Cita marcada como atendida");
                btnBuscar_Click(null, null); // Refrescar la busqueda actual
            }
            else
            {
                MessageBox.Show("No se pudo actualizar la cita");
            }
        }

        private void MostrarCitas()
        {
            btnBuscar_Click(null, null);
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            frmMenuConsultor form = new frmMenuConsultor(consultorActual);
            form.Show();
            this.Hide();
        }
    }
}

