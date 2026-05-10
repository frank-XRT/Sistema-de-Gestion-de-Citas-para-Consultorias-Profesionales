namespace Sistema_de_Gestion_de_Citas
{
    partial class frmSubmenuModificarConsultor
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
            this.btnEditarConsultor = new System.Windows.Forms.Button();
            this.btnEliminarConsultor = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // btnEditarConsultor
            this.btnEditarConsultor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarConsultor.Location = new System.Drawing.Point(50, 40);
            this.btnEditarConsultor.Name = "btnEditarConsultor";
            this.btnEditarConsultor.Size = new System.Drawing.Size(250, 35);
            this.btnEditarConsultor.TabIndex = 0;
            this.btnEditarConsultor.Text = "Editar Consultor";
            this.btnEditarConsultor.Click += new System.EventHandler(this.btnEditarConsultor_Click);

            // btnEliminarConsultor
            this.btnEliminarConsultor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarConsultor.Location = new System.Drawing.Point(50, 90);
            this.btnEliminarConsultor.Name = "btnEliminarConsultor";
            this.btnEliminarConsultor.Size = new System.Drawing.Size(250, 35);
            this.btnEliminarConsultor.TabIndex = 1;
            this.btnEliminarConsultor.Text = "Eliminar Consultor";
            this.btnEliminarConsultor.Click += new System.EventHandler(this.btnEliminarConsultor_Click);

            // btnVolver
            this.btnVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolver.Location = new System.Drawing.Point(50, 140);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(250, 35);
            this.btnVolver.TabIndex = 2;
            this.btnVolver.Text = "Volver";
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);

            // frmSubmenuModificarConsultor
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 230);
            this.Controls.Add(this.btnEditarConsultor);
            this.Controls.Add(this.btnEliminarConsultor);
            this.Controls.Add(this.btnVolver);
            this.Name = "frmSubmenuModificarConsultor";
            this.Text = "Editar y Eliminar Consultor";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button btnEditarConsultor;
        private System.Windows.Forms.Button btnEliminarConsultor;
        private System.Windows.Forms.Button btnVolver;
    }
}
