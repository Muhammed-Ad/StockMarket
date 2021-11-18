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
    public partial class StartingForm : Form
    {
        StockDataForm df;
        string StockName;
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
            string url = "https://query1.finance.yahoo.com/v7/finance/download/AAP?period1=1605639981&period2=1637175981&interval=1d&events=history&includeAdjustedClose=true";

            string output = webClient.DownloadString(url);
            string[] DataRows = output.Split('\n');
            //webClient.DownloadFile(, );
            //Console.Write(output);
            StockName = "AAPL";
            //--streamReader
            //string url = https://query1.finance.yahoo.com/v7/finance/download/AAPL?period1=1605639981&period2=1637175981&interval=1d&events=history&includeAdjustedClose=true
        }

        private void LoadDataButton_Click(object sender, EventArgs e)
        {

            df = new StockDataForm();
            df.Text = StockName + " Data";
            df.Show();
        }
    }
}
