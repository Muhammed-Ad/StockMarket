using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
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
            EndDatePicker.Value = DateTime.Now;
            EndDatePicker.MaxDate = DateTime.Now;
            StartDatePicker.Value = DateTime.Now;
            StartDatePicker.MaxDate = DateTime.Now;
            //System.Net.WebClient webClient = new System.Net.WebClient();
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

            int i = 0;
            
            StockNames = Resources.StockNames.Split('\n');
            StockNames = StockNames.Select(row => {
                    var temp = row.Split(',');
                    return temp[0].ToUpper() + " (" + temp[1].ToUpper() + ")";
            }).ToArray();
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
            long startTime = new DateTimeOffset(start.Year, start.Month, start.Day, start.Hour, start.Minute, start.Second, TimeSpan.Zero).ToUnixTimeSeconds();//since unix epoch
            long endTime = new DateTimeOffset(end.Year, end.Month, end.Day, end.Hour, end.Minute, end.Second, TimeSpan.Zero).ToUnixTimeSeconds();
            
            /*
            if(startTime == endTime)
            {
                MessageBox.Show("Cannot input same value for start and end", "Error!");
                return;
            }*/
            if(startTime > endTime)
            {
                MessageBox.Show("Cannot have end be more recent than start", "Error!");
                return;
            }

            var textString = StocksComboBox.Text.Split(' ');
            string text = textString[0];
            string text2 = StocksComboBox.Text ;
            
            //check the Stock box is empty
            if (text == "")
            {
                MessageBox.Show("The Ticket Cannot be EMPTY!", "Error");
                return;
            }

            
            Console.WriteLine(text);
                        
            //check the typed string is in Collection
            if (!StockNames.Contains<string>(text2.ToUpper()))
            {
                
                
                MessageBox.Show("Stock does not exist in S&P 500", "Error!");
                return;
            }
            //check the peridod box is empty
            if(PeriodComboBox.Text == "")
            {
                MessageBox.Show("Period Cannot Be EMPTY", "Error!");
                return;
            }

            if (text[text.Length - 1] == '\r')
            {
                text = text = text.Remove(text.Length - 1, 1);
                //text = text + "\r";
            }
             
            

            string Interval = PeriodComboBox.Text == "Daily" ? "1d" : PeriodComboBox.Text == "Weekly" ? "1wk" : PeriodComboBox.Text == "Monthly" ? "1mo" : "1d";
            df = new StockDataForm(text, startTime.ToString(), endTime.ToString(), Interval);
            df.Text = text + " Data";
            df.Show();
        }

       
    }
}
