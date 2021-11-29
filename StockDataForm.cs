using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace StockMarketProject
{
    public partial class StockDataForm : Form
    {
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
                string[] dataPoints = line.Split(',');
                if (dataPoints[0] == "Date") continue;
                
                DataChart.Series[0].Points.AddXY(dataPoints[0], dataPoints[2], dataPoints[3], dataPoints[1], dataPoints[4]);
                min = double.Parse(dataPoints[3]) < min ? double.Parse(dataPoints[3]) : min;
                DataChart.ChartAreas[0].AxisY.Minimum = min - min/20.0;
                
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
    }
}
