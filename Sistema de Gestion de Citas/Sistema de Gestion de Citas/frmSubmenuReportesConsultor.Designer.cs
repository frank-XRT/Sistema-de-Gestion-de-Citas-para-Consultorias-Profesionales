namespace Sistema_de_Gestion_de_Citas
{
    partial class frmSubmenuReportesConsultor
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
            this.btnVolver = new System.Windows.Forms.Button();
            this.btnReporteClientesFrecuentes = new System.Windows.Forms.Button();
            this.btnReporteIngresos = new System.Windows.Forms.Button();
            this.btnReporteCitas = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            
            this.btnVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolver.Location = new System.Drawing.Point(163, 219);
            this.btnVolver.Margin = new System.Windows.Forms.Padding(2);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(274, 31);
            this.btnVolver.TabIndex = 17;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            
            this.btnReporteClientesFrecuentes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReporteClientesFrecuentes.Location = new System.Drawing.Point(163, 169);
            this.btnReporteClientesFrecuentes.Margin = new System.Windows.Forms.Padding(2);
            this.btnReporteClientesFrecuentes.Name = "btnReporteClientesFrecuentes";
            this.btnReporteClientesFrecuentes.Size = new System.Drawing.Size(274, 31);
            this.btnReporteClientesFrecuentes.TabIndex = 16;
            this.btnReporteClientesFrecuentes.Text = "Reporte de Clientes Frecuentes";
            this.btnReporteClientesFrecuentes.UseVisualStyleBackColor = true;
            this.btnReporteClientesFrecuentes.Click += new System.EventHandler(this.btnReporteClientesFrecuentes_Click);
           
            this.btnReporteIngresos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReporteIngresos.Location = new System.Drawing.Point(163, 118);
            this.btnReporteIngresos.Margin = new System.Windows.Forms.Padding(2);
            this.btnReporteIngresos.Name = "btnReporteIngresos";
            this.btnReporteIngresos.Size = new System.Drawing.Size(274, 32);
            this.btnReporteIngresos.TabIndex = 15;
            this.btnReporteIngresos.Text = "Reporte de Ingresos";
            this.btnReporteIngresos.UseVisualStyleBackColor = true;
            this.btnReporteIngresos.Click += new System.EventHandler(this.btnReporteIngresos_Click);
          
            this.btnReporteCitas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReporteCitas.Location = new System.Drawing.Point(163, 68);
            this.btnReporteCitas.Margin = new System.Windows.Forms.Padding(2);
            this.btnReporteCitas.Name = "btnReporteCitas";
            this.btnReporteCitas.Size = new System.Drawing.Size(274, 31);
            this.btnReporteCitas.TabIndex = 14;
            this.btnReporteCitas.Text = "Reporte de Citas";
            this.btnReporteCitas.UseVisualStyleBackColor = true;
            this.btnReporteCitas.Click += new System.EventHandler(this.btnReporteCitas_Click);
           
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(215, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 20);
            this.label1.TabIndex = 18;
            this.label1.Text = "Reportes de Consultor";
            
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnReporteClientesFrecuentes);
            this.Controls.Add(this.btnReporteIngresos);
            this.Controls.Add(this.btnReporteCitas);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmSubmenuReportesConsultor";
            this.Text = "Reportes de Consultor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Button btnReporteClientesFrecuentes;
        private System.Windows.Forms.Button btnReporteIngresos;
        private System.Windows.Forms.Button btnReporteCitas;
        private System.Windows.Forms.Label label1;
    }
}
