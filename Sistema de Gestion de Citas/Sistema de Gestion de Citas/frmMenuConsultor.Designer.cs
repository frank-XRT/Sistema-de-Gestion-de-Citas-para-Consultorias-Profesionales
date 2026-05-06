namespace Sistema_de_Gestion_de_Citas
{
    partial class frmMenuConsultor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnReporteClientesFrecuentes = new System.Windows.Forms.Button();
            this.btnReporteIngresos = new System.Windows.Forms.Button();
            this.btnReporteCitas = new System.Windows.Forms.Button();
            this.btnConsultarCitas = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(287, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(195, 25);
            this.label2.TabIndex = 18;
            this.label2.Text = "Menu de Consultor";
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Location = new System.Drawing.Point(244, 316);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(280, 38);
            this.btnSalir.TabIndex = 17;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnReporteClientesFrecuentes
            // 
            this.btnReporteClientesFrecuentes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReporteClientesFrecuentes.Location = new System.Drawing.Point(192, 272);
            this.btnReporteClientesFrecuentes.Name = "btnReporteClientesFrecuentes";
            this.btnReporteClientesFrecuentes.Size = new System.Drawing.Size(365, 38);
            this.btnReporteClientesFrecuentes.TabIndex = 16;
            this.btnReporteClientesFrecuentes.Text = "Reporte de Clientes Frecuentes";
            this.btnReporteClientesFrecuentes.UseVisualStyleBackColor = true;
            this.btnReporteClientesFrecuentes.Click += new System.EventHandler(this.btnReporteClientesFrecuentes_Click);
            // 
            // btnReporteIngresos
            // 
            this.btnReporteIngresos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReporteIngresos.Location = new System.Drawing.Point(244, 227);
            this.btnReporteIngresos.Name = "btnReporteIngresos";
            this.btnReporteIngresos.Size = new System.Drawing.Size(280, 39);
            this.btnReporteIngresos.TabIndex = 15;
            this.btnReporteIngresos.Text = "Reporte de Ingresos";
            this.btnReporteIngresos.UseVisualStyleBackColor = true;
            this.btnReporteIngresos.Click += new System.EventHandler(this.btnReporteIngresos_Click);
            // 
            // btnReporteCitas
            // 
            this.btnReporteCitas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReporteCitas.Location = new System.Drawing.Point(244, 184);
            this.btnReporteCitas.Name = "btnReporteCitas";
            this.btnReporteCitas.Size = new System.Drawing.Size(280, 38);
            this.btnReporteCitas.TabIndex = 14;
            this.btnReporteCitas.Text = "Reporte de Citas";
            this.btnReporteCitas.UseVisualStyleBackColor = true;
            this.btnReporteCitas.Click += new System.EventHandler(this.btnReporteCitas_Click);
            // 
            // btnConsultarCitas
            // 
            this.btnConsultarCitas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsultarCitas.Location = new System.Drawing.Point(244, 139);
            this.btnConsultarCitas.Name = "btnConsultarCitas";
            this.btnConsultarCitas.Size = new System.Drawing.Size(280, 39);
            this.btnConsultarCitas.TabIndex = 13;
            this.btnConsultarCitas.Text = "Consultar Citas";
            this.btnConsultarCitas.UseVisualStyleBackColor = true;
            this.btnConsultarCitas.Click += new System.EventHandler(this.btnConsultarCitas_Click);
            // 
            // frmMenuConsultor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnReporteClientesFrecuentes);
            this.Controls.Add(this.btnReporteIngresos);
            this.Controls.Add(this.btnReporteCitas);
            this.Controls.Add(this.btnConsultarCitas);
            this.Name = "frmMenuConsultor";
            this.Text = "frmMenuConsultor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnReporteClientesFrecuentes;
        private System.Windows.Forms.Button btnReporteIngresos;
        private System.Windows.Forms.Button btnReporteCitas;
        private System.Windows.Forms.Button btnConsultarCitas;
    }
}