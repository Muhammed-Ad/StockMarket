using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace StockMarketProject
{
    public partial class StockDataForm : Form
    {
        List<string> dataType = new List<string>();
        private double maximum = 0;
        private double minimum = -1;

        public StockDataForm()
        {
            InitializeComponent();
            //string url = "https://query1.finance.yahoo.com/v7/finance/download/AAPL?period1=1605639981&period2=1637175981&interval=1d&events=history&includeAdjustedClose=true";
            //string output = webClient.DownloadString(url);
        }

        public StockDataForm(string stockName, string start, string end, string interval)
        {
            //start and end time must be in unix epoch time
            string URL = "https://query1.finance.yahoo.com/v7/finance/download/" + stockName + "?period1=" + start + "&period2=" + end + "&interval=" + interval + "&events=history&includeAdjustedClose=true";
            System.Net.WebClient webClient = new System.Net.WebClient();
            
            string output = webClient.DownloadString(URL);
            InitializeComponent();

            string[] DataRows = output.Split('\n');
            double min = double.MaxValue;
            DataChart.Series[0].Name = stockName;
            foreach (string line in DataRows)
            {
                double tol = .05;

                string[] dataPoints = line.Split(',');
                if (dataPoints[0] == "Date") continue;

                double high = double.Parse(dataPoints[2]),
                       low = double.Parse(dataPoints[3]),
                       open = double.Parse(dataPoints[1]),
                       close = double.Parse(dataPoints[4]);
                bool doji = false;

                DataChart.Series[0].Points.AddXY(dataPoints[0], dataPoints[2], dataPoints[3], dataPoints[1], dataPoints[4]);

                for (int i = 1; i <= 4; i++)
                {
                    if (Double.Parse(dataPoints[i]) > maximum)
                    {
                        maximum = Double.Parse(dataPoints[i]);
                    }

                    if (minimum == -1 || Double.Parse(dataPoints[i]) < minimum)
                    {
                        minimum = Double.Parse(dataPoints[i]);
                    }
                }
                //min = double.Parse(dataPoints[3]) < min ? double.Parse(dataPoints[3]) : min;
                //DataChart.ChartAreas[0].AxisY.Minimum = min - min/20.0;
                DataChart.ChartAreas["ChartArea1"].AxisY.Maximum = (int)(maximum + 10);
                DataChart.ChartAreas["ChartArea1"].AxisY.Minimum = (int)(minimum - 10);

                string dataDescription = "";
                if(Math.Abs(close - open) < (tol * (high - low)))
                {
                    dataDescription += "doji ";
                }
                else if(Math.Abs(close - high) < (tol * high) && Math.Abs(open - low) < (tol * low))
                {
                    dataDescription += "marubozu ";
                }
                else if(Math.Abs(close - open) < ((tol + 0.19) * (high - low)))
                { //haramis
                    dataDescription += "harami ";
                }

                var long_legged = (dataDescription == "doji ") && ((open - (high + low)/2) < tol * (high - low)) && ((close - (high + low) / 2) < tol * (high - low));
                var dragonfly = (dataDescription == "doji ") && (open - high < tol * high) && (close - high < tol * high);
                var gravestone = (dataDescription == "doji ") && (open - low < tol * low) && (close - low < tol * low);
                var bullishMarubozu = (dataDescription == "marubozu ") && (close > open);
                var bearishMarubozu = (dataDescription == "marubozu ") && (close <= open);
                var bullishHarami = (dataDescription == "harami ") && (close > open);
                var bearishHarami = (dataDescription == "harami ") && (close <= open);

                if (long_legged)
                {
                    dataDescription += "long-legged ";
                }
                else if (dragonfly)
                {
                    dataDescription += "dragonfly ";
                }
                else if (gravestone)
                {
                    dataDescription += "gravestone ";
                }

                if (bullishMarubozu)
                {
                    dataDescription += "bullish ";
                }
                else if (bearishMarubozu)
                {
                    dataDescription += "bearish ";
                }

                dataType.Add(dataDescription);
                //dataPoints[0]; //Date
                //dataPoints[1]; //Open
                //dataPoints[2]; //High
                //dataPoints[3]; //Low
                //dataPoints[4]; //Close
                //dataPoints[5]; //Adj. Close
                //dataPoints[6]; //Volume
            }
            //Console.Write(output);
            Console.Write(output);
        }

        private void CandleStickPatternComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            for(int i = 0; i < dataType.Count(); i++)
            {
                /* if(CandleStickPatternComboBox.Text.Contains("Doji") && dataType[i].Contains("doji"))
                 {
                     calcRectangle(i);
                 }*/
                calcRectangle(i);
            }
        }

        private void calcRectangle(int index)
        {
            RectangleAnnotation rectangleAnnotation = new RectangleAnnotation();

            rectangleAnnotation.IsSizeAlwaysRelative = false;
           /*rectangleAnnotation.AxisX = DataChart.ChartAreas[0].AxisX;
            rectangleAnnotation.AxisY = DataChart.ChartAreas[0].AxisY;*/

            /*rectangleAnnotation.X = DataChart.Series[0].Points[index].XValue;
            rectangleAnnotation.Y = DataChart.Series[0].Points[index].YValues[1];*/
            rectangleAnnotation.SetAnchor(DataChart.Series[0].Points[index]);
            rectangleAnnotation.Width = DataChart.Series[0].Points.Count / 50;//DataChart.Series[0].Points[index].BorderWidth;
            rectangleAnnotation.Height = DataChart.Series[0].Points[index].YValues[0] - DataChart.Series[0].Points[index].YValues[1];

            rectangleAnnotation.LineColor = Color.Black;//DataChart.Series[0].Points[index].Color;
            rectangleAnnotation.LineWidth = 2;
            rectangleAnnotation.LineDashStyle = ChartDashStyle.Dash;
            rectangleAnnotation.BackColor = Color.White;
            DataChart.Annotations.Add(rectangleAnnotation);
            DataChart.Update();
        }
    }
}
