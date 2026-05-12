namespace Sistema_de_Gestion_de_Citas
{
    partial class frmEditarConsultor
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTituloActual = new System.Windows.Forms.Label();
            
            this.lblLabelNombre = new System.Windows.Forms.Label();
            this.lblLabelDni = new System.Windows.Forms.Label();
            this.lblLabelSexo = new System.Windows.Forms.Label();
            this.lblLabelTelefono = new System.Windows.Forms.Label();
            this.lblLabelCorreo = new System.Windows.Forms.Label();
            this.lblLabelRubro = new System.Windows.Forms.Label();
            this.lblLabelDescripcion = new System.Windows.Forms.Label();
            this.lblLabelMonto = new System.Windows.Forms.Label();

            this.lblActualNombre = new System.Windows.Forms.Label();
            this.lblActualDni = new System.Windows.Forms.Label();
            this.lblActualSexo = new System.Windows.Forms.Label();
            this.lblActualTelefono = new System.Windows.Forms.Label();
            this.lblActualCorreo = new System.Windows.Forms.Label();
            this.lblActualRubro = new System.Windows.Forms.Label();
            this.lblActualDescripcion = new System.Windows.Forms.Label();
            this.lblActualMonto = new System.Windows.Forms.Label();

            this.lblTituloEditar = new System.Windows.Forms.Label();
            
            this.lblEditNombre = new System.Windows.Forms.Label();
            this.lblEditDni = new System.Windows.Forms.Label();
            this.lblEditSexo = new System.Windows.Forms.Label();
            this.lblEditTelefono = new System.Windows.Forms.Label();
            this.lblEditCorreo = new System.Windows.Forms.Label();
            this.lblEditRubro = new System.Windows.Forms.Label();
            this.lblEditDescripcion = new System.Windows.Forms.Label();
            this.lblEditMonto = new System.Windows.Forms.Label();

            this.txtEditarNombre = new System.Windows.Forms.TextBox();
            this.txtEditarDni = new System.Windows.Forms.TextBox();
            this.cboxEditarSexo = new System.Windows.Forms.ComboBox();
            this.txtEditarTelefono = new System.Windows.Forms.TextBox();
            this.txtEditarCorreo = new System.Windows.Forms.TextBox();
            this.cboxEditarRubro = new System.Windows.Forms.ComboBox();
            this.txtEditarDescripcion = new System.Windows.Forms.TextBox();
            this.txtEditarMonto = new System.Windows.Forms.TextBox();

            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // 
            // Left Column - Labels
            // 
            this.lblTituloActual.AutoSize = true;
            this.lblTituloActual.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloActual.Location = new System.Drawing.Point(30, 20);
            this.lblTituloActual.Name = "lblTituloActual";
            this.lblTituloActual.Size = new System.Drawing.Size(225, 24);
            this.lblTituloActual.Text = "CONSULTOR ACTUAL:";

            this.lblLabelNombre.AutoSize = true;
            this.lblLabelNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLabelNombre.Location = new System.Drawing.Point(30, 60);
            this.lblLabelNombre.Text = "Nombre";

            this.lblLabelDni.AutoSize = true;
            this.lblLabelDni.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLabelDni.Location = new System.Drawing.Point(30, 100);
            this.lblLabelDni.Text = "Dni";

            this.lblLabelSexo.AutoSize = true;
            this.lblLabelSexo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLabelSexo.Location = new System.Drawing.Point(30, 140);
            this.lblLabelSexo.Text = "Sexo";

            this.lblLabelTelefono.AutoSize = true;
            this.lblLabelTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLabelTelefono.Location = new System.Drawing.Point(30, 180);
            this.lblLabelTelefono.Text = "Telefono";

            this.lblLabelCorreo.AutoSize = true;
            this.lblLabelCorreo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLabelCorreo.Location = new System.Drawing.Point(30, 220);
            this.lblLabelCorreo.Text = "Correo";

            this.lblLabelRubro.AutoSize = true;
            this.lblLabelRubro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLabelRubro.Location = new System.Drawing.Point(30, 260);
            this.lblLabelRubro.Text = "Rubro";

            this.lblLabelDescripcion.AutoSize = true;
            this.lblLabelDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLabelDescripcion.Location = new System.Drawing.Point(30, 300);
            this.lblLabelDescripcion.Text = "Descripcion";

            this.lblLabelMonto.AutoSize = true;
            this.lblLabelMonto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLabelMonto.Location = new System.Drawing.Point(30, 340);
            this.lblLabelMonto.Text = "Monto";

            // 
            // Left Column - Values
            // 
            this.lblActualNombre.AutoSize = true;
            this.lblActualNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActualNombre.Location = new System.Drawing.Point(150, 60);
            this.lblActualNombre.Text = "-";

            this.lblActualDni.AutoSize = true;
            this.lblActualDni.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActualDni.Location = new System.Drawing.Point(150, 100);
            this.lblActualDni.Text = "-";

            this.lblActualSexo.AutoSize = true;
            this.lblActualSexo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActualSexo.Location = new System.Drawing.Point(150, 140);
            this.lblActualSexo.Text = "-";

            this.lblActualTelefono.AutoSize = true;
            this.lblActualTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActualTelefono.Location = new System.Drawing.Point(150, 180);
            this.lblActualTelefono.Text = "-";

            this.lblActualCorreo.AutoSize = true;
            this.lblActualCorreo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActualCorreo.Location = new System.Drawing.Point(150, 220);
            this.lblActualCorreo.Text = "-";

            this.lblActualRubro.AutoSize = true;
            this.lblActualRubro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActualRubro.Location = new System.Drawing.Point(150, 260);
            this.lblActualRubro.Text = "-";

            this.lblActualDescripcion.AutoSize = true;
            this.lblActualDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActualDescripcion.Location = new System.Drawing.Point(150, 300);
            this.lblActualDescripcion.Text = "-";

            this.lblActualMonto.AutoSize = true;
            this.lblActualMonto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActualMonto.Location = new System.Drawing.Point(150, 340);
            this.lblActualMonto.Text = "-";


            // 
            // Right Column
            // 
            this.lblTituloEditar.AutoSize = true;
            this.lblTituloEditar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloEditar.Location = new System.Drawing.Point(400, 20);
            this.lblTituloEditar.Name = "lblTituloEditar";
            this.lblTituloEditar.Size = new System.Drawing.Size(200, 24);
            this.lblTituloEditar.Text = "EDITAR CONSULTOR";

            this.lblEditNombre.AutoSize = true;
            this.lblEditNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEditNombre.Location = new System.Drawing.Point(400, 60);
            this.lblEditNombre.Text = "Nombre";

            this.lblEditDni.AutoSize = true;
            this.lblEditDni.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEditDni.Location = new System.Drawing.Point(400, 100);
            this.lblEditDni.Text = "Dni";

            this.lblEditSexo.AutoSize = true;
            this.lblEditSexo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEditSexo.Location = new System.Drawing.Point(400, 140);
            this.lblEditSexo.Text = "Sexo";

            this.lblEditTelefono.AutoSize = true;
            this.lblEditTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEditTelefono.Location = new System.Drawing.Point(400, 180);
            this.lblEditTelefono.Text = "Telefono";

            this.lblEditCorreo.AutoSize = true;
            this.lblEditCorreo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEditCorreo.Location = new System.Drawing.Point(400, 220);
            this.lblEditCorreo.Text = "Correo";

            this.lblEditRubro.AutoSize = true;
            this.lblEditRubro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEditRubro.Location = new System.Drawing.Point(400, 260);
            this.lblEditRubro.Text = "Rubro";

            this.lblEditDescripcion.AutoSize = true;
            this.lblEditDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEditDescripcion.Location = new System.Drawing.Point(400, 300);
            this.lblEditDescripcion.Text = "Descripcion";

            this.lblEditMonto.AutoSize = true;
            this.lblEditMonto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEditMonto.Location = new System.Drawing.Point(400, 340);
            this.lblEditMonto.Text = "Monto";


            // 
            // Input Fields
            // 
            this.txtEditarNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEditarNombre.Location = new System.Drawing.Point(580, 57);
            this.txtEditarNombre.Size = new System.Drawing.Size(200, 26);

            this.txtEditarDni.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEditarDni.Location = new System.Drawing.Point(580, 97);
            this.txtEditarDni.Size = new System.Drawing.Size(200, 26);

            this.cboxEditarSexo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxEditarSexo.FormattingEnabled = true;
            this.cboxEditarSexo.Items.AddRange(new object[] { "Masculino", "Femenino" });
            this.cboxEditarSexo.Location = new System.Drawing.Point(580, 137);
            this.cboxEditarSexo.Size = new System.Drawing.Size(200, 28);

            this.txtEditarTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEditarTelefono.Location = new System.Drawing.Point(580, 177);
            this.txtEditarTelefono.Size = new System.Drawing.Size(200, 26);

            this.txtEditarCorreo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEditarCorreo.Location = new System.Drawing.Point(580, 217);
            this.txtEditarCorreo.Size = new System.Drawing.Size(200, 26);

            this.cboxEditarRubro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxEditarRubro.FormattingEnabled = true;
            this.cboxEditarRubro.Items.AddRange(new object[] { "Legal", "Contable", "Psicologia", "Empresarial", "Tecnologico", "Salud", "Educacion" });
            this.cboxEditarRubro.Location = new System.Drawing.Point(580, 257);
            this.cboxEditarRubro.Size = new System.Drawing.Size(200, 28);

            this.txtEditarDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEditarDescripcion.Location = new System.Drawing.Point(580, 297);
            this.txtEditarDescripcion.Size = new System.Drawing.Size(200, 26);

            this.txtEditarMonto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEditarMonto.Location = new System.Drawing.Point(580, 337);
            this.txtEditarMonto.Size = new System.Drawing.Size(200, 26);

            // 
            // Buttons
            // 
            this.btnActualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar.Location = new System.Drawing.Point(400, 390);
            this.btnActualizar.Size = new System.Drawing.Size(150, 35);
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);

            this.btnVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolver.Location = new System.Drawing.Point(600, 390);
            this.btnVolver.Size = new System.Drawing.Size(150, 35);
            this.btnVolver.Text = "Volver";
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);

            // 
            // frmEditarConsultor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 460);

            this.Controls.Add(this.lblTituloActual);

            this.Controls.Add(this.lblLabelNombre);
            this.Controls.Add(this.lblLabelDni);
            this.Controls.Add(this.lblLabelSexo);
            this.Controls.Add(this.lblLabelTelefono);
            this.Controls.Add(this.lblLabelCorreo);
            this.Controls.Add(this.lblLabelRubro);
            this.Controls.Add(this.lblLabelDescripcion);
            this.Controls.Add(this.lblLabelMonto);

            this.Controls.Add(this.lblActualNombre);
            this.Controls.Add(this.lblActualDni);
            this.Controls.Add(this.lblActualSexo);
            this.Controls.Add(this.lblActualTelefono);
            this.Controls.Add(this.lblActualCorreo);
            this.Controls.Add(this.lblActualRubro);
            this.Controls.Add(this.lblActualDescripcion);
            this.Controls.Add(this.lblActualMonto);

            this.Controls.Add(this.lblTituloEditar);

            this.Controls.Add(this.lblEditNombre);
            this.Controls.Add(this.lblEditDni);
            this.Controls.Add(this.lblEditSexo);
            this.Controls.Add(this.lblEditTelefono);
            this.Controls.Add(this.lblEditCorreo);
            this.Controls.Add(this.lblEditRubro);
            this.Controls.Add(this.lblEditDescripcion);
            this.Controls.Add(this.lblEditMonto);

            this.Controls.Add(this.txtEditarNombre);
            this.Controls.Add(this.txtEditarDni);
            this.Controls.Add(this.cboxEditarSexo);
            this.Controls.Add(this.txtEditarTelefono);
            this.Controls.Add(this.txtEditarCorreo);
            this.Controls.Add(this.cboxEditarRubro);
            this.Controls.Add(this.txtEditarDescripcion);
            this.Controls.Add(this.txtEditarMonto);

            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnVolver);

            this.Name = "frmEditarConsultor";
            this.Text = "Editar Consultor";
            this.Load += new System.EventHandler(this.frmEditarConsultor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTituloActual;
        private System.Windows.Forms.Label lblLabelNombre;
        private System.Windows.Forms.Label lblLabelDni;
        private System.Windows.Forms.Label lblLabelSexo;
        private System.Windows.Forms.Label lblLabelTelefono;
        private System.Windows.Forms.Label lblLabelCorreo;
        private System.Windows.Forms.Label lblLabelRubro;
        private System.Windows.Forms.Label lblLabelDescripcion;
        private System.Windows.Forms.Label lblLabelMonto;

        private System.Windows.Forms.Label lblActualNombre;
        private System.Windows.Forms.Label lblActualDni;
        private System.Windows.Forms.Label lblActualSexo;
        private System.Windows.Forms.Label lblActualTelefono;
        private System.Windows.Forms.Label lblActualCorreo;
        private System.Windows.Forms.Label lblActualRubro;
        private System.Windows.Forms.Label lblActualDescripcion;
        private System.Windows.Forms.Label lblActualMonto;

        private System.Windows.Forms.Label lblTituloEditar;

        private System.Windows.Forms.Label lblEditNombre;
        private System.Windows.Forms.Label lblEditDni;
        private System.Windows.Forms.Label lblEditSexo;
        private System.Windows.Forms.Label lblEditTelefono;
        private System.Windows.Forms.Label lblEditCorreo;
        private System.Windows.Forms.Label lblEditRubro;
        private System.Windows.Forms.Label lblEditDescripcion;
        private System.Windows.Forms.Label lblEditMonto;

        private System.Windows.Forms.TextBox txtEditarNombre;
        private System.Windows.Forms.TextBox txtEditarDni;
        private System.Windows.Forms.ComboBox cboxEditarSexo;
        private System.Windows.Forms.TextBox txtEditarTelefono;
        private System.Windows.Forms.TextBox txtEditarCorreo;
        private System.Windows.Forms.ComboBox cboxEditarRubro;
        private System.Windows.Forms.TextBox txtEditarDescripcion;
        private System.Windows.Forms.TextBox txtEditarMonto;

        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnVolver;
    }
}
