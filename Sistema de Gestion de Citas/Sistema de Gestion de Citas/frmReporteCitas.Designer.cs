namespace Sistema_de_Gestion_de_Citas
{
    partial class frmReporteCitas
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCitasHoy = new System.Windows.Forms.Label();
            this.lblCitasMes = new System.Windows.Forms.Label();
            this.lblTotalCitas = new System.Windows.Forms.Label();
            this.btnVolver = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(50, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Citas atendidas hoy";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(50, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(247, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Citas atendidas durante este mes";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(50, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(177, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Total de citas atendidas";
            // 
            // lblCitasHoy
            // 
            this.lblCitasHoy.AutoSize = true;
            this.lblCitasHoy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCitasHoy.Location = new System.Drawing.Point(350, 50);
            this.lblCitasHoy.Name = "lblCitasHoy";
            this.lblCitasHoy.Size = new System.Drawing.Size(19, 20);
            this.lblCitasHoy.TabIndex = 3;
            this.lblCitasHoy.Text = "0";
            this.lblCitasHoy.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblCitasMes
            // 
            this.lblCitasMes.AutoSize = true;
            this.lblCitasMes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCitasMes.Location = new System.Drawing.Point(350, 110);
            this.lblCitasMes.Name = "lblCitasMes";
            this.lblCitasMes.Size = new System.Drawing.Size(19, 20);
            this.lblCitasMes.TabIndex = 4;
            this.lblCitasMes.Text = "0";
            this.lblCitasMes.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblTotalCitas
            // 
            this.lblTotalCitas.AutoSize = true;
            this.lblTotalCitas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCitas.Location = new System.Drawing.Point(350, 170);
            this.lblTotalCitas.Name = "lblTotalCitas";
            this.lblTotalCitas.Size = new System.Drawing.Size(19, 20);
            this.lblTotalCitas.TabIndex = 5;
            this.lblTotalCitas.Text = "0";
            this.lblTotalCitas.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnVolver
            // 
            this.btnVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolver.Location = new System.Drawing.Point(130, 240);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(180, 40);
            this.btnVolver.TabIndex = 6;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // frmReporteCitas
            // 
            this.ClientSize = new System.Drawing.Size(450, 320);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.lblTotalCitas);
            this.Controls.Add(this.lblCitasMes);
            this.Controls.Add(this.lblCitasHoy);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmReporteCitas";
            this.Text = "Reporte de Citas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCitasHoy;
        private System.Windows.Forms.Label lblCitasMes;
        private System.Windows.Forms.Label lblTotalCitas;
        private System.Windows.Forms.Button btnVolver;
    }
}
