using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StockMarket.Properties;

namespace StockMarketProject
{
    public partial class StartingForm : Form
    {
        StockDataForm df;
        string[] StockNames;
        public StartingForm()
        {
            InitializeComponent();
            System.Net.WebClient webClient = new System.Net.WebClient();
            //get the unix time for the period variables in the URL
            //interval gives you the frequency in which the opening and closing prices are updated
            //events is the what type of csv you want, in the case, we want a historical type
            //includeAdjustedClose just includes extra data about closing
            //Also may need to read in csv of S&P 500 companies
            //WebBrowser object may be useful
            /*string url = "https://query1.finance.yahoo.com/v7/finance/download/AAP?period1=1605639981&period2=1637175981&interval=1d&events=history&includeAdjustedClose=true";

            string output = webClient.DownloadString(url);
            string[] DataRows = output.Split('\n');
            foreach(string line in DataRows)
            {
                string[] dataPoints = line.Split(',');
                //dataPoints[0]; //Date
                //dataPoints[1]; //Open
                //dataPoints[2]; //High
                //dataPoints[3]; //Low
                //dataPoints[4]; //Close
                //dataPoints[5]; //Adj. Close
                //dataPoints[6]; //Volume
            }*/
            //StockMarketProject.Properties.Resources.StockNames;

            StockNames = Resources.StockNameSymbols.Split('\n');
            StocksComboBox.DataSource = StockNames;
            //webClient.DownloadFile(, );
            //Console.Write(output);
            //StockNames[0] = "AAPL";
            //--streamReader
            //string url = https://query1.finance.yahoo.com/v7/finance/download/AAPL?period1=1605639981&period2=1637175981&interval=1d&events=history&includeAdjustedClose=true
        }

        private void LoadDataButton_Click(object sender, EventArgs e)
        {
            ///Validate that input field as put in
            DateTime start = StartDatePicker.Value;
            DateTime end = EndDatePicker.Value;

            string StartTimeSinceEpoch = new DateTimeOffset(start.Year, start.Month, start.Day, start.Hour, start.Minute, start.Second, TimeSpan.Zero).ToUnixTimeSeconds().ToString();
            string EndTimeSinceEpoch = new DateTimeOffset(end.Year, end.Month, end.Day, end.Hour, end.Minute, end.Second, TimeSpan.Zero).ToUnixTimeSeconds().ToString();
            /*string StartTimeSinceEpoch = dto.ToUnixTimeMilliseconds().ToString();
            string EndTimeSinceEpoch = dto.ToUnixTimeMilliseconds().ToString();*/
            string text = StocksComboBox.Text;
            string Interval = PeriodComboBox.Text == "Daily" ? "1d" : PeriodComboBox.Text == "Weekly" ? "1wk" : PeriodComboBox.Text == "Monthly" ? "1mo" : "";
            df = new StockDataForm(text, StartTimeSinceEpoch, EndTimeSinceEpoch, Interval);
            df.Text = text + " Data";
            df.Show();
        }

        /*private bool ValidateData()
        {
            if()
        }*/
    }
}
