namespace Sistema_de_Gestion_de_Citas
{
    partial class frmDiagramaIngresosConsultor
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.chartIngresos = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartIngresos)).BeginInit();
            this.SuspendLayout();
            // 
            // chartIngresos
            // 
            chartArea1.AxisX.Title = "Trimestres";
            chartArea1.AxisY.Title = "Ingresos Totales (S/)";
            chartArea1.Name = "ChartArea1";
            this.chartIngresos.ChartAreas.Add(chartArea1);
            this.chartIngresos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartIngresos.Location = new System.Drawing.Point(0, 0);
            this.chartIngresos.Name = "chartIngresos";
            this.chartIngresos.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Excel;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            series1.IsValueShownAsLabel = true;
            series1.Label = "S/ #VALY";
            series1.Name = "Series1";
            this.chartIngresos.Series.Add(series1);
            this.chartIngresos.Size = new System.Drawing.Size(800, 450);
            this.chartIngresos.TabIndex = 0;
            this.chartIngresos.Text = "chart1";
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.Name = "Title1";
            title1.Text = "Comparativa de Ingresos por Trimestre";
            this.chartIngresos.Titles.Add(title1);
            // 
            // frmDiagramaIngresosConsultor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.chartIngresos);
            this.Name = "frmDiagramaIngresosConsultor";
            this.Text = "Reporte de Ingresos por Trimestres";
            ((System.ComponentModel.ISupportInitialize)(this.chartIngresos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartIngresos;
    }
}
