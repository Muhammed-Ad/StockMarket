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
        Dictionary<string, List<int>> dataTypeHash = new Dictionary<string, List<int>>();
        List<string> dataType = new List<string>();
        List<RectangleAnnotation> rectList = new List<RectangleAnnotation>();
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
            int count = 0;
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
                DateTime date = DateTime.Parse(dataPoints[0]);
                //double dateDouble = double.Parse(date.ToString());
                bool doji = false;

                DataChart.Series[0].Points.AddXY(date, high, low, open, close);

                //dataPoints[0]; //Date
                //dataPoints[1]; //Open
                //dataPoints[2]; //High
                //dataPoints[3]; //Low
                //dataPoints[4]; //Close
                //dataPoints[5]; //Adj. Close
                //dataPoints[6]; //Volume

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
                    dataDescription += "Doji";
                }
                else if(Math.Abs(close - high) < (tol * high) && Math.Abs(open - low) < (tol * low))
                {
                    dataDescription += "Marubozu";
                }
                else if(Math.Abs(close - open) < ((tol + 0.19) * (high - low)))
                { //haramis
                    dataDescription += "Harami";
                }

                var neutral = (dataDescription == "Doji") && ((open - (high + low) / 2) < tol * (high - low)) && ((close - (high + low) / 2) < tol * (high - low));
                var long_legged = (dataDescription == "Doji") && ((open - (high + low)/2) < tol * (high - low)) && ((close - (high + low) / 2) < tol * (high - low)) && (Math.Abs(open- close) <= (high -low) / 10);
                var dragonfly = (dataDescription == "Doji") && (open - high < tol * high) && (close - high < tol * high);
                var gravestone = (dataDescription == "Doji") && (open - low < tol * low) && (close - low < tol * low);
                var bullishMarubozu = (dataDescription == "Marubozu") && (close > open);
                var bearishMarubozu = (dataDescription == "Marubozu") && (close <= open);
                var bullishHarami = (dataDescription == "Harami") && (close > open);
                var bearishHarami = (dataDescription == "Harami") && (close <= open);
                if (neutral)
                {
                    dataDescription = dataDescription.Insert(0, "Neutral ");
                }
                if (long_legged)
                {
                    dataDescription = dataDescription.Insert(0, "Long-Legged ");
                }
                else if (dragonfly)
                {
                    dataDescription = dataDescription.Insert(0, "Dragonfly ");
                }
                else if (gravestone)
                {
                    dataDescription = dataDescription.Insert(0, "Gravestone ");
                }

                if (bullishMarubozu)
                {
                    dataDescription = dataDescription.Insert(0, "Bullish ");
                }
                else if (bearishMarubozu)
                {
                    dataDescription = dataDescription.Insert(0, "Bearish ");
                }

                if (dataTypeHash.ContainsKey(dataDescription)){
                    dataTypeHash[dataDescription].Add(count);
                }
                else
                {
                    dataTypeHash.Add(dataDescription, new List<int>());
                    dataTypeHash[dataDescription].Add(count);
                }
                calcRectangle(count);
                count++;

                //Neutral Doji
                /*Long-Legged Doji
                  Gravestone Doji
                  Dragonfly Doji
                  Bullish Marubozus
                  Bearish Marubozus
                  Bullish Harami
                  Bearish Harami*/
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
            if (!string.IsNullOrEmpty(CandleStickPatternComboBox.Text))
            {
                DataChart.Annotations.Clear();
                string candleType = CandleStickPatternComboBox.Text;
                int size = -1;
                try
                {
                    size = dataTypeHash[candleType].Count();
                }
                catch (KeyNotFoundException)
                {
                    MessageBox.Show("No Candlesticks of type " + candleType + " currently available ", "Notice!");
                    return;
                }
                for (int i = 0; i < size; i++)
                {
                    DataChart.Annotations.Add(rectList[dataTypeHash[candleType][i]]);
                }
                DataChart.Update();
            }
            
        }

        private void calcRectangle(int index)
        {
            RectangleAnnotation rectangleAnnotation = new RectangleAnnotation();

            rectangleAnnotation.IsSizeAlwaysRelative = false;
            rectangleAnnotation.AxisX = DataChart.ChartAreas[0].AxisX;
            rectangleAnnotation.AxisY = DataChart.ChartAreas[0].AxisY;
            //rectangleAnnotation.

            /*rectangleAnnotation.X = DataChart.Series[0].Points[index].XValue;
            rectangleAnnotation.Y = DataChart.Series[0].Points[index].YValues[3];*/
            rectangleAnnotation.SetAnchor(DataChart.Series[0].Points[index]);
            rectangleAnnotation.Width = DataChart.Series[0].Points[index].LabelBorderWidth - 1.5 * DataChart.Series[0].Points[index].BorderWidth;//DataChart.Series[0].Points.Count / 50;
            rectangleAnnotation.Height = DataChart.Series[0].Points[index].YValues[0] - DataChart.Series[0].Points[index].YValues[1];

            rectangleAnnotation.LineColor = Color.Black;//DataChart.Series[0].Points[index].Color;
            rectangleAnnotation.LineWidth = 1;
            rectangleAnnotation.LineDashStyle = ChartDashStyle.Solid;
            rectangleAnnotation.BackColor = Color.Transparent;
            rectList.Add(rectangleAnnotation);
            //DataChart.Annotations.Add(rectangleAnnotation);
            //DataChart.Update();
        }
    }
}
