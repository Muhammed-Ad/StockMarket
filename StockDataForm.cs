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
        List<DataPoint> dataTypeObj = new List<DataPoint>();
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
            
            DataChart.Series[0].Name = stockName;
            foreach (string line in DataRows)
            {
                double tol = 0.2;

                string[] dataPoints = line.Split(',');
                if (dataPoints[0] == "Date") continue;

                double high = double.Parse(dataPoints[2]),
                       low = double.Parse(dataPoints[3]),
                       open = double.Parse(dataPoints[1]),
                       close = double.Parse(dataPoints[4]);
                DateTime date = DateTime.Parse(dataPoints[0]);
                DataPoint temp = new DataPoint();
                temp.SetValueXY(date.ToBinary(), high, low, open, close);
                dataTypeObj.Add(temp);
                //double dateDouble = double.Parse(date.ToString());
                bool bullish = close > open;

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

                double range = high - low;
                double midpoint = (high + low) / 2;
                
                if(Math.Abs(close - open) <= (tol * (range)))
                {
                    dataDescription += "Doji";
                }
                else if(Math.Abs(close - open) >= (1 - (4 * tol)) * range/*Math.Abs(high - low)*//*Math.Abs(close - high) < (tol * (high - low)) && Math.Abs(open - low) < (tol * (high - low))*/)
                {
                    dataDescription += "Marubozu";
                }
                else if(Math.Abs(close - open) >= (1 - (4 * tol)) * range /*Math.Abs(high - low)*/ /*Math.Abs(close - open) < ((tol + 0.19) * (high - low))*/)
                { //haramis
                    dataDescription += "Harami";
                }
                double htol = 1 + tol;
                double ltol = 1 - tol;
                double highest = bullish ? close : open;
                double lowest = !bullish ? close : open;
                //0 - hi, 1 - low, 2 - open, 3 - close
                bool neutral = (dataDescription == "Doji") && (open < 1.2 * midpoint && open > 0.8 * midpoint) && (close < 1.2 * midpoint && close > 0.8 * midpoint);/*((open - (high + low) / 2) < tol * (high - low)) && ((close - (high + low) / 2) < tol * (high - low))*/;
                bool long_legged =  neutral && (range >= 50 * Math.Abs(open - close)); /*(dataDescription == "Doji") && ((open - (high + low)/2) < tol * (high - low)) && ((close - (high + low) / 2) < tol * (high - low))*/
                bool dragonfly = /*(dataDescription == "Doji") && *//*(open < 1.0001 * high && open >= 0.8 * high) && (close < 1.0001 * high && close >= 0.8 * high)*/(Math.Abs(open - high) < .4 * (range)) && (Math.Abs(close - high) < .4 * (range));
                bool gravestone = /*(dataDescription == "Doji") &&*/ /*(open <= 1.1 * low && open > 0.99 * low) && (close <= 1.1 * low && close > 0.99 * low)*/(Math.Abs(open - low) < .4 * (range)) && (Math.Abs(close - low) < .4 * (range));
                bool bullishMarubozu = (dataDescription == "Marubozu") && (close > open);
                bool bearishMarubozu = (dataDescription == "Marubozu") && (close <= open);
                bool bullishHarami = (dataDescription == "Harami") && (close > open);
                bool bearishHarami = (dataDescription == "Harami") && (close <= open);

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
                else if (neutral)
                {
                    dataDescription = dataDescription.Insert(0, "Neutral ");
                }
                

                if (bullishMarubozu)
                {
                    dataDescription = dataDescription.Insert(0, "Bullish ");
                }
                else if (bearishMarubozu)
                {
                    dataDescription = dataDescription.Insert(0, "Bearish ");
                }

                /*if (bullishHarami)
                {
                    dataDescription = dataDescription.Insert(0, "Bullish ");
                }
                else if (bearishHarami)
                {
                    dataDescription = dataDescription.Insert(0, "Bearish ");
                }*/

                dataType.Add(dataDescription);
                if (dataTypeHash.ContainsKey(dataDescription)){
                    dataTypeHash[dataDescription].Add(count);
                }
                else
                {
                    dataTypeHash.Add(dataDescription, new List<int>());
                    dataTypeHash[dataDescription].Add(count);
                }

                //if(!dataDescription.Contains("Harami"))
                calcRectangle(count, bullish);
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
            
        }

        private void CandleStickPatternComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(CandleStickPatternComboBox.Text))
            {
                DataChart.Annotations.Clear();
                string candleType = CandleStickPatternComboBox.Text;
                int size = -1;

                if (!candleType.Contains("Harami"))
                {
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
                }
                else
                {
                    bool bullish = candleType.Contains("Bullish");
                    int size1 = -1;
                    int numFound = 0;
                    try
                    {
                        size1 = dataTypeHash[candleType].Count();
                    }
                    catch (KeyNotFoundException)
                    {
                        MessageBox.Show("No Candlesticks of type " + candleType + " currently available ", "Notice!");
                        return;
                    }
                    
                    for(int i = 0; i < size1; i++)
                    {
                        int index = dataTypeHash[candleType][i];
                        double[] temp1 = dataTypeObj[index].YValues;
                        double[] temp2;
                        if(index + 1 < dataTypeObj.Count())
                        {
                            if(dataType[index + 1] != "")
                            {
                                continue;
                            }
                            temp2 = dataTypeObj[index + 1].YValues;
                        }
                        else
                        {
                            break;
                        }

                        bool isValid = temp1[0] > temp2[0] && temp1[1] < temp2[1];  //temp1 high is higher than temp2 and temp1 low is lower than temp 2
                        bool temp2Bearish = temp2[2] > temp2[3]; //open > close

                        if(bullish == temp2Bearish)
                        {
                            rectList[index].Width *= 2;
                            DataChart.Annotations.Add(rectList[index]);
                            //rectList[index].AnchorOffsetX = 
                        }
                    }

                   
                }
                DataChart.Update();
            }
            
        }

        private void calcRectangle(int index, bool bullish = false, int heightAdj = 0, int widthAdj = 0, int anchorAdj = 0)
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

            rectangleAnnotation.LineColor = Color.Black/*bullish ? Color.Green : Color.Red*/;//DataChart.Series[0].Points[index].Color;
            rectangleAnnotation.LineWidth = 1;
            rectangleAnnotation.LineDashStyle = ChartDashStyle.Solid;
            rectangleAnnotation.BackColor = Color.Transparent;
            rectList.Add(rectangleAnnotation);
            //DataChart.Annotations.Add(rectangleAnnotation);
            //DataChart.Update();
        }
    }
}
