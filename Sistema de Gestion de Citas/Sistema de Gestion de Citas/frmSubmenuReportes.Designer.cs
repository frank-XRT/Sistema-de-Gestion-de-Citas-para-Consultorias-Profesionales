namespace Sistema_de_Gestion_de_Citas
{
    partial class frmSubmenuReportes
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
            this.btnReporteCitasServicio = new System.Windows.Forms.Button();
            this.btnReporteIngresosRubro = new System.Windows.Forms.Button();
            this.btnReporteEstadosPorArea = new System.Windows.Forms.Button();
            this.btnReporteConsultoresRubro = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // btnReporteCitasServicio
            this.btnReporteCitasServicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReporteCitasServicio.Location = new System.Drawing.Point(50, 40);
            this.btnReporteCitasServicio.Name = "btnReporteCitasServicio";
            this.btnReporteCitasServicio.Size = new System.Drawing.Size(250, 35);
            this.btnReporteCitasServicio.TabIndex = 0;
            this.btnReporteCitasServicio.Text = "Reporte de citas por area";
            this.btnReporteCitasServicio.Click += new System.EventHandler(this.btnReporteCitasServicio_Click);

            // btnReporteIngresosRubro
            this.btnReporteIngresosRubro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReporteIngresosRubro.Location = new System.Drawing.Point(50, 90);
            this.btnReporteIngresosRubro.Name = "btnReporteIngresosRubro";
            this.btnReporteIngresosRubro.Size = new System.Drawing.Size(250, 35);
            this.btnReporteIngresosRubro.TabIndex = 1;
            this.btnReporteIngresosRubro.Text = "Reporte de ingresos por area";
            this.btnReporteIngresosRubro.Click += new System.EventHandler(this.btnReporteIngresosRubro_Click);

            // btnReporteEstadosPorArea
            this.btnReporteEstadosPorArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReporteEstadosPorArea.Location = new System.Drawing.Point(50, 140);
            this.btnReporteEstadosPorArea.Name = "btnReporteEstadosPorArea";
            this.btnReporteEstadosPorArea.Size = new System.Drawing.Size(250, 35);
            this.btnReporteEstadosPorArea.TabIndex = 2;
            this.btnReporteEstadosPorArea.Text = "Reporte de estados por area";
            this.btnReporteEstadosPorArea.Click += new System.EventHandler(this.btnReporteEstadosPorArea_Click);

            // btnReporteConsultoresRubro
            this.btnReporteConsultoresRubro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReporteConsultoresRubro.Location = new System.Drawing.Point(50, 190);
            this.btnReporteConsultoresRubro.Name = "btnReporteConsultoresRubro";
            this.btnReporteConsultoresRubro.Size = new System.Drawing.Size(250, 35);
            this.btnReporteConsultoresRubro.TabIndex = 3;
            this.btnReporteConsultoresRubro.Text = "Reporte consultores por area";
            this.btnReporteConsultoresRubro.Click += new System.EventHandler(this.btnReporteConsultoresRubro_Click);

            // btnVolver
            this.btnVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolver.Location = new System.Drawing.Point(50, 240);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(250, 35);
            this.btnVolver.TabIndex = 4;
            this.btnVolver.Text = "Volver";
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);

            // frmSubmenuReportes
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 320);
            this.Controls.Add(this.btnReporteCitasServicio);
            this.Controls.Add(this.btnReporteIngresosRubro);
            this.Controls.Add(this.btnReporteEstadosPorArea);
            this.Controls.Add(this.btnReporteConsultoresRubro);
            this.Controls.Add(this.btnVolver);
            this.Name = "frmSubmenuReportes";
            this.Text = "Submenú Reportes";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button btnReporteCitasServicio;
        private System.Windows.Forms.Button btnReporteIngresosRubro;
        private System.Windows.Forms.Button btnReporteEstadosPorArea;
        private System.Windows.Forms.Button btnReporteConsultoresRubro;
        private System.Windows.Forms.Button btnVolver;
    }
}
