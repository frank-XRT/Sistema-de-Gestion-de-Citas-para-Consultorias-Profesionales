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
    public partial class frmBuscarProfesional : Form
    {
        private CCliente clienteActual;
        CControlador controlador = new CControlador();
        public frmBuscarProfesional(CCliente cliente)
        {
            InitializeComponent();
            clienteActual = cliente;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(236, 253, 245);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string rubro = cboxRubro.Text.Trim();

            if (rubro == "")
            {
                MessageBox.Show("Seleccione o escriba un rubro");
                return;
            }

            dgvConsultores.DataSource = null;
            dgvConsultores.DataSource = controlador.BuscarConsultoresPorRubro(rubro);
        }

        private void dgvConsultores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvConsultores.CurrentRow == null)
            {
                return;
            }

            CConsultor consultor = (CConsultor)dgvConsultores.CurrentRow.DataBoundItem;

            controlador.GenerarHorarios(consultor.Codigo, DateTime.Today);

            dgvHorarios.DataSource = null;
            dgvHorarios.DataSource = controlador.ListarHorariosLibres(consultor.Codigo);
        }

        private void btnReservar_Click(object sender, EventArgs e)
        {
            if (dgvHorarios.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un horario");
                return;
            }

            if (txtMonto.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el monto");
                return;
            }

            CHorarioConsultor horario = (CHorarioConsultor)dgvHorarios.CurrentRow.DataBoundItem;

            CCita cita = new CCita();

            cita.CodigoCliente = clienteActual.Codigo;
            cita.CodigoHorario = horario.Codigo;
            cita.Monto = decimal.Parse(txtMonto.Text);
            cita.Descripcion = txtDescripcion.Text.Trim();

            bool reservado = controlador.ReservarCita(cita);

            if (reservado)
            {
                MessageBox.Show("Cita reservada correctamente");

                dgvHorarios.DataSource = null;
                dgvHorarios.DataSource = controlador.ListarHorariosLibres(horario.CodigoConsultor);
            }
            else
            {
                MessageBox.Show("No se pudo reservar la cita");
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            frmMenuCliente form = new frmMenuCliente(clienteActual);
            form.Show();
            this.Hide();
        }
    }
}
