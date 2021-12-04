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
    /// <summary>
    /// class Stock Datat inherit Form
    /// </summary>
    public partial class StockDataForm : Form
    {
        /// <summary>
        /// the Dictionary to store dataTypeHash
        /// </summary>
        Dictionary<string, List<int>> dataTypeHash = new Dictionary<string, List<int>>();
        /// <summary>
        /// the list of dataType as string
        /// </summary>
        List<string> dataType = new List<string>();
        /// <summary>
        /// the list of DataType as DataPoint Object
        /// </summary>
        List<DataPoint> dataTypeObj = new List<DataPoint>();
        /// <summary>
        /// the list or rectangle to store the rectangle
        /// </summary>
        List<RectangleAnnotation> rectList = new List<RectangleAnnotation>();
        /// <summary>
        /// maximum variable to store the max of the Y-axis
        /// </summary>
        private double maximum = 0;
        /// <summary>
        /// minimum variable to store the max of the Y-axis
        /// </summary>
        private double minimum = -1;

        /// <summary>
        /// for default constructor
        /// </summary>
        public StockDataForm()
        {
            InitializeComponent();
            //string url = "https://query1.finance.yahoo.com/v7/finance/download/AAPL?period1=1605639981&period2=1637175981&interval=1d&events=history&includeAdjustedClose=true";
            //string output = webClient.DownloadString(url);
        }
        /// <summary>
        /// The constructor that gets data fromyahoo website to use to populate stock. It also categorizes the candles of the stock
        /// </summary>
        /// <param name="stockName"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="interval"></param>
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
                //temp.SetValueXY(date, high, low, open, close);

                dataTypeObj.Add(temp);
                //double dateDouble = double.Parse(date.ToString());
                bool bullish = close > open;

                DataChart.Series[0].Points.AddXY(dataPoints[0], high, low, open, close);

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
                DataChart.ChartAreas["ChartArea1"].AxisY.Maximum = (int)(maximum + 5);
                DataChart.ChartAreas["ChartArea1"].AxisY.Minimum = (int)(minimum - 5);

                string dataDescription = "";

                double range = high - low;
                double midpoint = (high + low) / 2;
                
                if(Math.Abs(close - open) <= (1.5 * tol * (range)))
                {
                    dataDescription += "Doji";
                }
                else if(Math.Abs(close - open) >= (1 - (2.5 * tol)) * range/*Math.Abs(high - low)*//*Math.Abs(close - high) < (tol * (high - low)) && Math.Abs(open - low) < (tol * (high - low))*/)
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

                //check each case
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

                if (bullishHarami)
                {
                    dataDescription = dataDescription.Insert(0, "Bearish ");
                }
                else if (bearishHarami)
                {
                    dataDescription = dataDescription.Insert(0, "Bullish ");
                }

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
        /// <summary>
        /// when selected candelstick type is changed, function is called to update the chart of and highlight the specific types 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CandleStickPatternComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(CandleStickPatternComboBox.Text))
            {
                double sumOffset = 0;
                for(int i = 0; i < DataChart.Series[0].Points.Count(); i++)
                {
                    sumOffset += (DataChart.Series[0].Points[i].LabelBorderWidth - 1.5 * DataChart.Series[0].Points[i].BorderWidth) / 2.0;
                }
                
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
                            /*if(dataType[index + 1] != "")
                            {
                                continue;
                            }*/
                            temp2 = dataTypeObj[index + 1].YValues;
                        }
                        else
                        {
                            MessageBox.Show("No Candlesticks of type " + candleType + " currently available ", "Notice!");
                            return;

                        }

                        bool isValid = temp1[0] >= .99 * temp2[0] && temp1[1] <= 1.01 * temp2[1];  //temp1 high is higher than temp2 and temp1 low is lower than temp 2;
                        //temp1bullish
                        bool temp2Bearish = temp2[2] > temp2[3]; //open > close
                        bool para = !bullish ? temp1[3] > temp2[2] && temp1[2] < temp2[3] /*temp1 closing is higher than temp2 opening  and temp1 opening lwer than temp 2 closing*/: temp1[3] < temp2[2] && temp1[2] > temp2[3] /*temp1 closing is lower than temp2 opening  and temp1 opening lwer than temp 2 closing*/;
                        /*if (bullish)
                        {
                            para = temp1[3] > temp2[0] && temp1[2] < temp2[3];
                        }*/
                        if (!bullish == temp2Bearish && isValid && para)
                        {
                            double xOffset = sumOffset / (DataChart.Series[0].Points.Count() / 2.0);
                            double yOffset = Math.Abs(rectList[index].Height - rectList[index + 1].Height) /*/ 2.0*/;
                            //if(index + 1)
                            double heightUpper = DataChart.Series[0].Points[index].YValues[0] > DataChart.Series[0].Points[index + 1].YValues[0] ? DataChart.Series[0].Points[index].YValues[0] : DataChart.Series[0].Points[index + 1].YValues[0];
                            double heightLower = DataChart.Series[0].Points[index].YValues[1] < DataChart.Series[0].Points[index + 1].YValues[1] ? DataChart.Series[0].Points[index].YValues[1] : DataChart.Series[0].Points[index + 1].YValues[1];

                            rectList[index].Width = 3.5 * (DataChart.Series[0].Points[index].LabelBorderWidth - 1.5 * DataChart.Series[0].Points[index].BorderWidth);/*+= DataChart.Series[0].Points[index].LabelBorderWidth - 1.5 * DataChart.Series[0].Points[index].BorderWidth;*/
                            rectList[index].Height =  (heightUpper - heightLower); 
                            DataChart.Annotations.Add(rectList[index]);
                            rectList[index].AnchorOffsetX = 1.5 * xOffset;
                            //rectList[index].AnchorOffsetY = yOffset;
                            numFound++;
                        }
                    }
                    if(numFound == 0)
                    {
                        MessageBox.Show("No Candlesticks of type " + candleType + " currently available ", "Notice!");
                        return;
                    }
                    

                }
                DataChart.Update();
            }
            
        }
        /// <summary>
        /// calculate the rectnagle that should be drawn around specific candlestick
        /// </summary>
        /// <param name="index"></param>
        /// <param name="bullish"></param>
        /// <param name="heightAdj"></param>
        /// <param name="widthAdj"></param>
        /// <param name="anchorAdj"></param>
        private void calcRectangle(int index, bool bullish = false)
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
