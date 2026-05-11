namespace Sistema_de_Gestion_de_Citas
{
    partial class frmMenuAdministrador
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
            this.btnRegistrarConsultor = new System.Windows.Forms.Button();
            this.btnEditarEliminarConsultor = new System.Windows.Forms.Button();
            this.btnReportes = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnRegistrarConsultor
            // 
            this.btnRegistrarConsultor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrarConsultor.Location = new System.Drawing.Point(125, 80);
            this.btnRegistrarConsultor.Name = "btnRegistrarConsultor";
            this.btnRegistrarConsultor.Size = new System.Drawing.Size(250, 35);
            this.btnRegistrarConsultor.TabIndex = 0;
            this.btnRegistrarConsultor.Text = "Registrar Consultor";
            this.btnRegistrarConsultor.Click += new System.EventHandler(this.btnRegistrarConsultor_Click);
            // 
            // btnEditarEliminarConsultor
            // 
            this.btnEditarEliminarConsultor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarEliminarConsultor.Location = new System.Drawing.Point(125, 121);
            this.btnEditarEliminarConsultor.Name = "btnEditarEliminarConsultor";
            this.btnEditarEliminarConsultor.Size = new System.Drawing.Size(250, 56);
            this.btnEditarEliminarConsultor.TabIndex = 1;
            this.btnEditarEliminarConsultor.Text = "Habilitar, editar y eliminar consultor";
            this.btnEditarEliminarConsultor.Click += new System.EventHandler(this.btnEditarEliminarConsultor_Click);
            // 
            // btnReportes
            // 
            this.btnReportes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReportes.Location = new System.Drawing.Point(125, 183);
            this.btnReportes.Name = "btnReportes";
            this.btnReportes.Size = new System.Drawing.Size(250, 35);
            this.btnReportes.TabIndex = 2;
            this.btnReportes.Text = "Reportes";
            this.btnReportes.Click += new System.EventHandler(this.btnReportes_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Location = new System.Drawing.Point(125, 273);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(250, 35);
            this.btnSalir.TabIndex = 3;
            this.btnSalir.Text = "Salir";
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(115, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(268, 26);
            this.label2.TabIndex = 4;
            this.label2.Text = "Menu de Administracion";
            // 
            // frmMenuAdministrador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 320);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnReportes);
            this.Controls.Add(this.btnEditarEliminarConsultor);
            this.Controls.Add(this.btnRegistrarConsultor);
            this.Name = "frmMenuAdministrador";
            this.Text = "Menu Administrador";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Button btnRegistrarConsultor;
        private System.Windows.Forms.Button btnEditarEliminarConsultor;
        private System.Windows.Forms.Button btnReportes;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label label2;
    }
}