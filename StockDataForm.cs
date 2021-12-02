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
                min = double.Parse(dataPoints[3]) < min ? double.Parse(dataPoints[3]) : min;
                DataChart.ChartAreas[0].AxisY.Minimum = min - min/20.0;

                string dataDescription = "";
                if(Math.Abs(close - open) < tol * close)
                {
                    dataDescription += "doji ";
                }
                else if((close - high) < tol * high && (open - low) < tol * low)
                {
                    dataDescription += "marubozu ";
                }

                var long_legged = (dataDescription == "doji ") && ((open - (high + low)/2) < tol * (high - low)) && ((close - (high + low) / 2) < tol * (high - low));
                var dragonfly = (dataDescription == "doji ") && (open - high < tol * high) && (close - high < tol * high);
                var gravestone = (dataDescription == "doji ") && (open - low < tol * low) && (close - low < tol * low);

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
                else
                {
                    dataDescription += "error ";
                }


                //dataPoints[0]; //Date
                //dataPoints[1]; //Open
                //dataPoints[2]; //High
                //dataPoints[3]; //Low
                //dataPoints[4]; //Close
                //dataPoints[5]; //Adj. Close
                //dataPoints[6]; //Volume
            }
            //Console.Write(output);
            
        }

        private void CandleStickPatternComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            RectangleAnnotation rectangleAnnotation = new RectangleAnnotation();

            rectangleAnnotation.IsSizeAlwaysRelative = false;
            rectangleAnnotation.AxisX = DataChart.ChartAreas[0].AxisX;
            rectangleAnnotation.AxisY = DataChart.ChartAreas[0].AxisY;

            rectangleAnnotation.X = 0;
            DataChart.Update();
        }
    }
}
