namespace Sistema_de_Gestion_de_Citas
{
    partial class frmDiagramaCitasServicio
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.chartCitas = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartCitas)).BeginInit();
            this.SuspendLayout();
            // 
            // chartCitas
            // 
            chartArea1.AxisX.Interval = 1D;
            chartArea1.AxisX.Title = "Rubro de Servicio";
            chartArea1.AxisY.Title = "Cantidad de Citas";
            chartArea1.Name = "ChartArea1";
            this.chartCitas.ChartAreas.Add(chartArea1);
            this.chartCitas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartCitas.Location = new System.Drawing.Point(0, 0);
            this.chartCitas.Name = "chartCitas";
            this.chartCitas.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.IsValueShownAsLabel = true;
            series1.Label = "#PERCENT{P0}";
            series1.Name = "Series1";
            this.chartCitas.Series.Add(series1);
            this.chartCitas.Size = new System.Drawing.Size(800, 450);
            this.chartCitas.TabIndex = 0;
            this.chartCitas.Text = "chart1";
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.Name = "Title1";
            title1.Text = "Distribución de Citas por Rubro";
            this.chartCitas.Titles.Add(title1);
            // 
            // frmDiagramaCitasServicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.chartCitas);
            this.Name = "frmDiagramaCitasServicio";
            this.Text = "Reporte Gráfico de Citas";
            ((System.ComponentModel.ISupportInitialize)(this.chartCitas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartCitas;
    }
}