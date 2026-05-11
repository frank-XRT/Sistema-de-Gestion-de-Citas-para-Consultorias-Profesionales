namespace Sistema_de_Gestion_de_Citas
{
    partial class frmDiagramaConsultoresRubro
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
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.chartConsultores = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartConsultores)).BeginInit();
            this.SuspendLayout();
            // 
            // chartConsultores
            // 
            chartArea1.AxisX.Interval = 1D;
            chartArea1.AxisX.Title = "Rubro";
            chartArea1.AxisY.Title = "Número de Consultores";
            chartArea1.Name = "ChartArea1";
            this.chartConsultores.ChartAreas.Add(chartArea1);
            this.chartConsultores.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chartConsultores.Legends.Add(legend1);
            this.chartConsultores.Location = new System.Drawing.Point(0, 0);
            this.chartConsultores.Name = "chartConsultores";
            this.chartConsultores.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            series1.IsValueShownAsLabel = true;
            series1.Legend = "Legend1";
            series1.LegendText = "Consultores";
            series1.Name = "Series1";
            this.chartConsultores.Series.Add(series1);
            this.chartConsultores.Size = new System.Drawing.Size(800, 450);
            this.chartConsultores.TabIndex = 0;
            this.chartConsultores.Text = "chart1";
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.Name = "Title1";
            title1.Text = "Reporte de Consultores por Rubro";
            this.chartConsultores.Titles.Add(title1);
            // 
            // frmDiagramaConsultoresRubro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.chartConsultores);
            this.Name = "frmDiagramaConsultoresRubro";
            this.Text = "Consultores por Rubro";
            ((System.ComponentModel.ISupportInitialize)(this.chartConsultores)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartConsultores;
    }
}
