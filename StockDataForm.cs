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
        }

        public StockDataForm(string stockName, string start, string end, string interval)
        {
            //start and end time must be in unix epoch time
            string URL = "https://query1.finance.yahoo.com/v7/finance/download/" + stockName + "?period1=" + start + "&period2=" + end + "&interval=" + interval + "&events=history&includeAdjustedClose=true";
            System.Net.WebClient webClient = new System.Net.WebClient();
            string url = "https://query1.finance.yahoo.com/v7/finance/download/AAPL?period1=1605639981&period2=1637175981&interval=1d&events=history&includeAdjustedClose=true";
            string output = webClient.DownloadString(URL);
            //string output = webClient.DownloadString(url);
            string[] DataRows = output.Split('\n');
            foreach (string line in DataRows)
            {
                string[] dataPoints = line.Split(',');
                //dataPoints[0]; //Date
                //dataPoints[1]; //Open
                //dataPoints[2]; //High
                //dataPoints[3]; //Low
                //dataPoints[4]; //Close
                //dataPoints[5]; //Adj. Close
                //dataPoints[6]; //Volume
            }
            Console.Write(output);
            InitializeComponent();
        }
    }
}
