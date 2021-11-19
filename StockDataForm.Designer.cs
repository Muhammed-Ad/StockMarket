
namespace StockMarketProject
{
    partial class StockDataForm
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
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.DataChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.DataChart)).BeginInit();
            this.SuspendLayout();
            // 
            // DataChart
            // 
            chartArea1.AxisX.InterlacedColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.DataChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.DataChart.Legends.Add(legend1);
            this.DataChart.Location = new System.Drawing.Point(83, 15);
            this.DataChart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DataChart.Name = "DataChart";
            this.DataChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            this.DataChart.PaletteCustomColors = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))))};
            series1.BorderColor = System.Drawing.Color.Black;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series1.CustomProperties = "PriceDownColor=192\\, 0\\, 0, PriceUpColor=0\\, 192\\, 0";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series1.YValuesPerPoint = 4;
            this.DataChart.Series.Add(series1);
            this.DataChart.Size = new System.Drawing.Size(895, 524);
            this.DataChart.TabIndex = 0;
            this.DataChart.Text = "Data Chart";
            // 
            // StockDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.DataChart);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "StockDataForm";
            this.Text = "Stock Data";
            ((System.ComponentModel.ISupportInitialize)(this.DataChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart DataChart;
    }
}