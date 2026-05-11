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
    public class CResumenCitaConsultor
    {
        public int ID { get; set; }
        public string Cliente { get; set; }
        public string Fecha { get; set; }
        public string Hora { get; set; }
        public decimal Monto { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
    }

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

            List<CResumenCitaConsultor> citasFiltradas = new List<CResumenCitaConsultor>();

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
                            CResumenCitaConsultor item = new CResumenCitaConsultor();
                            item.ID = c.ID;
                            item.Cliente = clienteEncontrado.Nombre;
                            item.Fecha = horarioEncontrado.FechaHoraInicio.ToString("dd/MM/yyyy");
                            item.Hora = horarioEncontrado.FechaHoraInicio.ToString("HH:mm") + " - " + horarioEncontrado.FechaHoraFin.ToString("HH:mm");
                            item.Monto = c.Monto;
                            item.Descripcion = c.Descripcion;
                            item.Estado = c.Estado;

                            citasFiltradas.Add(item);
                        }
                    }
                }
            }

            dgvCitas.DataSource = null;
            dgvCitas.DataSource = citasFiltradas;
            if (dgvCitas.Columns["id"] != null)
            {
                dgvCitas.Columns["id"].Visible = false;
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

