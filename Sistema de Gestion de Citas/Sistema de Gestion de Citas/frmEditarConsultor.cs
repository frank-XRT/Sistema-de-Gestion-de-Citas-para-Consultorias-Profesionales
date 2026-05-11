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
            if (txtEditarNombre.Text == "" ||
                txtEditarDni.Text == "" ||
                cboxEditarSexo.Text == "" ||
                txtEditarTelefono.Text == "" ||
                txtEditarCorreo.Text == "" ||
                cboxEditarRubro.Text == "" ||
                txtEditarDescripcion.Text == "" ||
                txtEditarMonto.Text == "")
            {
                MessageBox.Show("Complete todos los campos de edición.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!CControlador.ValidarDni(txtEditarDni.Text))
            {
                MessageBox.Show("El DNI debe tener al menos 8 dígitos y contener solo números", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nuevoDni = txtEditarDni.Text;
            if (nuevoDni != consultorAEditar.Dni)
            {
                bool existe = false;
                foreach (CConsultor c in CControlador.ListaConsultores)
                {
                    if (c.Dni == nuevoDni)
                    {
                        existe = true;
                        break;
                    }
                }

                if (existe)
                {
                    MessageBox.Show("El DNI ingresado ya está registrado para otro consultor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            consultorAEditar.Nombre = txtEditarNombre.Text;
            consultorAEditar.Dni = nuevoDni;
            consultorAEditar.Sexo = cboxEditarSexo.Text;
            consultorAEditar.Telefono = txtEditarTelefono.Text;
            consultorAEditar.Correo = txtEditarCorreo.Text;
            consultorAEditar.Rubro = cboxEditarRubro.Text;
            consultorAEditar.Descripcion = txtEditarDescripcion.Text;
            consultorAEditar.Monto = decimal.Parse(txtEditarMonto.Text);

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
