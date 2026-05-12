using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_Gestion_de_Citas
{


    public partial class frmConsultarCitas : Form
    {
        private CConsultor consultorActual;
        CControlador controlador = new CControlador();
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

            dgvCitas.DataSource = null;
            dgvCitas.Rows.Clear();
            dgvCitas.Columns.Clear();

            dgvCitas.Columns.Add("id", "ID");
            dgvCitas.Columns.Add("Cliente", "Cliente");
            dgvCitas.Columns.Add("Fecha", "Fecha");
            dgvCitas.Columns.Add("Hora", "Hora");
            dgvCitas.Columns.Add("Monto", "Monto");
            dgvCitas.Columns.Add("Descripcion", "Descripción");
            dgvCitas.Columns.Add("Estado", "Estado");

            dgvCitas.Columns["id"].Visible = false;

            List<CCita> listaCitasConsultor = controlador.ListarCitasPorConsultor(consultorActual.ID);

            foreach (CCita c in listaCitasConsultor)
            {
                CHorarioConsultor horarioEncontrado = null;
                foreach (CHorarioConsultor h in CControlador.ListaHorarios)
                {
                    if (h.ID == c.IDHorario)
                    {
                        horarioEncontrado = h;
                        break;
                    }
                }

                if (horarioEncontrado != null)
                {
                    if (horarioEncontrado.FechaHoraInicio.Date == fecha)
                    {
                        CCliente clienteEncontrado = null;
                        foreach (CCliente cl in CControlador.ListaClientes)
                        {
                            if (cl.ID == c.IDCliente)
                            {
                                clienteEncontrado = cl;
                                break;
                            }
                        }

                        if (clienteEncontrado != null)
                        {
                            string fechaStr = horarioEncontrado.FechaHoraInicio.ToString("dd/MM/yyyy");
                            string horaStr = horarioEncontrado.FechaHoraInicio.ToString("HH:mm") + " - " + horarioEncontrado.FechaHoraFin.ToString("HH:mm");

                            dgvCitas.Rows.Add(c.ID, clienteEncontrado.Nombre, fechaStr, horaStr, c.Monto, c.Descripcion, c.Estado);
                        }
                    }
                }
            }
        }

        private void btnAtender_Click(object sender, EventArgs e)
        {
            if (dgvCitas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una cita");
                return;
            }

            int idCita = (int)dgvCitas.SelectedRows[0].Cells["id"].Value;

            bool atendida = controlador.MarcarCitaComoAtendida(idCita);

            if (atendida)
            {
                MessageBox.Show("Cita marcada como atendida");
                btnBuscar_Click(null, null); 
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

