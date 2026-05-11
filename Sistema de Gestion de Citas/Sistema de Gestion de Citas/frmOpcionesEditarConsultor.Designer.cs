namespace Sistema_de_Gestion_de_Citas
{
    partial class frmOpcionesEditarConsultor
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblDni = new System.Windows.Forms.Label();
            this.txtDniBuscar = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblConsultorEncontrado = new System.Windows.Forms.Label();
            this.btnEditarContrasena = new System.Windows.Forms.Button();
            this.btnEditarOtrosCampos = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(50, 30);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(255, 24);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Opciones Editar Consultor";
            this.lblDni.AutoSize = true;
            this.lblDni.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDni.Location = new System.Drawing.Point(50, 80);
            this.lblDni.Name = "lblDni";
            this.lblDni.Size = new System.Drawing.Size(41, 20);
            this.lblDni.TabIndex = 1;
            this.lblDni.Text = "DNI:";
            this.txtDniBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDniBuscar.Location = new System.Drawing.Point(100, 77);
            this.txtDniBuscar.Name = "txtDniBuscar";
            this.txtDniBuscar.Size = new System.Drawing.Size(150, 26);
            this.txtDniBuscar.TabIndex = 2;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(270, 75);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(100, 30);
            this.btnBuscar.TabIndex = 3;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            this.lblConsultorEncontrado.AutoSize = true;
            this.lblConsultorEncontrado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConsultorEncontrado.Location = new System.Drawing.Point(137, 135);
            this.lblConsultorEncontrado.Name = "lblConsultorEncontrado";
            this.lblConsultorEncontrado.Size = new System.Drawing.Size(15, 20);
            this.lblConsultorEncontrado.TabIndex = 4;
            this.lblConsultorEncontrado.Text = "-";
            this.btnEditarContrasena.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarContrasena.Location = new System.Drawing.Point(50, 180);
            this.btnEditarContrasena.Name = "btnEditarContrasena";
            this.btnEditarContrasena.Size = new System.Drawing.Size(320, 35);
            this.btnEditarContrasena.TabIndex = 5;
            this.btnEditarContrasena.Text = "Editar solo Contrasena";
            this.btnEditarContrasena.Click += new System.EventHandler(this.btnEditarContrasena_Click);
            this.btnEditarOtrosCampos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarOtrosCampos.Location = new System.Drawing.Point(50, 230);
            this.btnEditarOtrosCampos.Name = "btnEditarOtrosCampos";
            this.btnEditarOtrosCampos.Size = new System.Drawing.Size(320, 35);
            this.btnEditarOtrosCampos.TabIndex = 6;
            this.btnEditarOtrosCampos.Text = "Editar otros campos";
            this.btnEditarOtrosCampos.Click += new System.EventHandler(this.btnEditarOtrosCampos_Click);
            this.btnVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolver.Location = new System.Drawing.Point(50, 280);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(320, 35);
            this.btnVolver.TabIndex = 7;
            this.btnVolver.Text = "Volver";
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(50, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Consultor:";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 350);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblDni);
            this.Controls.Add(this.txtDniBuscar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.lblConsultorEncontrado);
            this.Controls.Add(this.btnEditarContrasena);
            this.Controls.Add(this.btnEditarOtrosCampos);
            this.Controls.Add(this.btnVolver);
            this.Name = "frmOpcionesEditarConsultor";
            this.Text = "Opciones Editar Consultor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblDni;
        private System.Windows.Forms.TextBox txtDniBuscar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lblConsultorEncontrado;
        private System.Windows.Forms.Button btnEditarContrasena;
        private System.Windows.Forms.Button btnEditarOtrosCampos;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Label label1;
    }
}
