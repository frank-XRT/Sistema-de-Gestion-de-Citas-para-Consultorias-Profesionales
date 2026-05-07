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
        // Constructor requerido por el diseñador de Visual Studio
        public frmBuscarProfesional() { InitializeComponent(); }

        public frmBuscarProfesional(CCliente cliente)
        {
            InitializeComponent();
            clienteActual = cliente;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(236, 253, 245);
        }

        private void MostrarHorarios(System.Collections.IList datos)
        {
            dgvHorarios.DataSource = null;
            dgvHorarios.DataSource = datos;

            // Ocultar columnas internas
            if (dgvHorarios.Columns["Codigo"] != null) dgvHorarios.Columns["Codigo"].Visible = false;
            if (dgvHorarios.Columns["CodigoConsultor"] != null) dgvHorarios.Columns["CodigoConsultor"].Visible = false;
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

            // Ocultar columnas no deseadas
            if (dgvConsultores.Columns["Codigo"] != null) dgvConsultores.Columns["Codigo"].Visible = false;
            if (dgvConsultores.Columns["Dni"] != null) dgvConsultores.Columns["Dni"].Visible = false;
            if (dgvConsultores.Columns["Sexo"] != null) dgvConsultores.Columns["Sexo"].Visible = false;
            if (dgvConsultores.Columns["Contraseña"] != null) dgvConsultores.Columns["Contraseña"].Visible = false;
        }

        private void dgvConsultores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvConsultores.CurrentRow == null)
            {
                return;
            }

            CConsultor consultor = (CConsultor)dgvConsultores.CurrentRow.DataBoundItem;
            MostrarHorarios(controlador.ListarTodosLosHorarios(consultor.Codigo, DateTime.Today));
        }

        private void btnReservar_Click(object sender, EventArgs e)
        {
            if (dgvHorarios.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un horario");
                return;
            }

            if (dgvConsultores.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un consultor");
                return;
            }

            CConsultor consultor = (CConsultor)dgvConsultores.CurrentRow.DataBoundItem;
            CHorarioConsultor horario = (CHorarioConsultor)dgvHorarios.CurrentRow.DataBoundItem;

            CCita cita = new CCita();
            cita.CodigoCliente = clienteActual.Codigo;
            cita.CodigoHorario = horario.Codigo;
            cita.Monto = consultor.Monto;
            cita.Descripcion = txtDescripcion.Text.Trim();

            bool reservado = controlador.ReservarCita(cita);

            if (reservado)
            {
                MessageBox.Show("Cita reservada correctamente");
                MostrarHorarios(controlador.ListarTodosLosHorarios(horario.CodigoConsultor, dtpFecha.Value));
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

        private void btnFiltrarFecha_Click(object sender, EventArgs e)
        {
            if (dgvConsultores.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un consultor primero");
                return;
            }

            CConsultor consultor = (CConsultor)dgvConsultores.CurrentRow.DataBoundItem;
            DateTime fecha = dtpFecha.Value;
            MostrarHorarios(controlador.ListarTodosLosHorarios(consultor.Codigo, fecha));
        }
    }
}
