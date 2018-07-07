using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Xamarin.Forms;
using Newtonsoft.Json;

namespace MiningMonitor
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            refreshStats();
        }

        private void refreshButton_clicked(object sender, EventArgs e)
        {
            refreshStats();

        }

        private void refreshStats() 
        {
            string URL = "https://api.ethermine.org/miner/:0xcC61A3210F9feF03038eE100fA9Dd4a1dA8BfdC2/currentStats";
            using (var webClient = new System.Net.WebClient())
            {
                var json = webClient.DownloadString(URL);

                RootObject miningOutput = JsonConvert.DeserializeObject<RootObject>(json);

                repHashrate.Text = "Reported Hashrate: " + (Math.Round((double)miningOutput.data.reportedHashrate / 1000000, 2)).ToString() + " MH/s";
                curHashrate.Text = "Current Hashrate: " + (Math.Round(miningOutput.data.currentHashrate / 1000000, 2)).ToString() + " MH/s";
                workers.Text = "Active Workers: " + miningOutput.data.activeWorkers;
                earnings.Text = "Daily Earnings: $" + (Math.Round(miningOutput.data.usdPerMin * 60 * 24, 2)).ToString() + "/day";
            }
        }
    }
}
