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
    public partial class frmEditarConsultor : Form
    {
        private CConsultor consultorAEditar;

        public frmEditarConsultor(CConsultor consultor)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.consultorAEditar = consultor;
        }

        private void frmEditarConsultor_Load(object sender, EventArgs e)
        {
            MostrarDatosActuales();
            LimpiarCamposEdicion();
        }

        private void MostrarDatosActuales()
        {
            lblActualNombre.Text = consultorAEditar.Nombre;
            lblActualDni.Text = consultorAEditar.Dni;
            lblActualSexo.Text = consultorAEditar.Sexo;
            lblActualTelefono.Text = consultorAEditar.Telefono;
            lblActualCorreo.Text = consultorAEditar.Correo;
            lblActualRubro.Text = consultorAEditar.Rubro;
            lblActualDescripcion.Text = consultorAEditar.Descripcion;
            lblActualMonto.Text = consultorAEditar.Monto.ToString("0.00");
        }

        private void LimpiarCamposEdicion()
        {
            txtEditarNombre.Clear();
            txtEditarDni.Clear();
            cboxEditarSexo.SelectedIndex = -1;
            txtEditarTelefono.Clear();
            txtEditarCorreo.Clear();
            cboxEditarRubro.SelectedIndex = -1;
            txtEditarDescripcion.Clear();
            txtEditarMonto.Clear();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (txtEditarNombre.Text.Trim() == "" ||
                txtEditarDni.Text.Trim() == "" ||
                cboxEditarSexo.Text.Trim() == "" ||
                txtEditarTelefono.Text.Trim() == "" ||
                txtEditarCorreo.Text.Trim() == "" ||
                cboxEditarRubro.Text.Trim() == "" ||
                txtEditarDescripcion.Text.Trim() == "" ||
                txtEditarMonto.Text.Trim() == "")
            {
                MessageBox.Show("Complete todos los campos de edición.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nuevoDni = txtEditarDni.Text.Trim();
            if (nuevoDni != consultorAEditar.Dni)
            {
                bool existe = CControlador.ListaConsultores.Any(c => c.Dni == nuevoDni);
                if (existe)
                {
                    MessageBox.Show("El DNI ingresado ya está registrado para otro consultor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            consultorAEditar.Nombre = txtEditarNombre.Text.Trim();
            consultorAEditar.Dni = nuevoDni;
            consultorAEditar.Sexo = cboxEditarSexo.Text.Trim();
            consultorAEditar.Telefono = txtEditarTelefono.Text.Trim();
            consultorAEditar.Correo = txtEditarCorreo.Text.Trim();
            consultorAEditar.Rubro = cboxEditarRubro.Text.Trim();
            consultorAEditar.Descripcion = txtEditarDescripcion.Text.Trim();
            consultorAEditar.Monto = decimal.Parse(txtEditarMonto.Text.Trim());

            MessageBox.Show("Consultor actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            MostrarDatosActuales();
            LimpiarCamposEdicion();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
