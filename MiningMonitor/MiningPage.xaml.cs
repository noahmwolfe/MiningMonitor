using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Newtonsoft.Json;
using Xamarin.Forms.Xaml;

namespace MiningMonitor
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MiningPage : TabbedPage
    {
        public MiningPage ()
        {
            InitializeComponent();

            refreshStats();
        }
        private void ethrefreshButton_clicked(object sender, EventArgs e)
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

                ethrepHashrate.Text = "Reported Hashrate: " + (Math.Round((double)miningOutput.data.reportedHashrate / 1000000, 2)).ToString() + " MH/s";
                ethcurHashrate.Text = "Current Hashrate: " + (Math.Round(miningOutput.data.currentHashrate / 1000000, 2)).ToString() + " MH/s";
                ethworkers.Text = "Active Workers: " + miningOutput.data.activeWorkers;
                ethearnings.Text = "Daily Earnings: $" + (Math.Round(miningOutput.data.usdPerMin * 60 * 24, 2)).ToString() + "/day";
            }
        }
        private void refresh0xbtcStats()
        {
            string URL = "http://mike.rs/profile/?address=0xcC61A3210F9feF03038eE100fA9Dd4a1dA8BfdC2";
            using (var webClient = new System.Net.WebClient())
            {
                var json = webClient.DownloadString(URL);

                RootObject miningOutput = JsonConvert.DeserializeObject<RootObject>(json);

                ethrepHashrate.Text = "Reported Hashrate: " + (Math.Round((double)miningOutput.data.reportedHashrate / 1000000, 2)).ToString() + " MH/s";
                ethcurHashrate.Text = "Current Hashrate: " + (Math.Round(miningOutput.data.currentHashrate / 1000000, 2)).ToString() + " MH/s";
                ethworkers.Text = "Active Workers: " + miningOutput.data.activeWorkers;
                ethearnings.Text = "Daily Earnings: $" + (Math.Round(miningOutput.data.usdPerMin * 60 * 24, 2)).ToString() + "/day";
            }
        }

        private void refreshsiaStats()
        {
            string URL = "https://siamining.com/api/v1/addresses/50285401fe38b97b22cde4ee344a0bea985d80175d30f973343ebb33e4b5892ca223a1c97f9c/summary";
            using (var webClient = new System.Net.WebClient())
            {
                var json = webClient.DownloadString(URL);

                RootObject miningOutput = JsonConvert.DeserializeObject<RootObject>(json);

                //ethrepHashrate.Text = "Reported Hashrate: " + (Math.Round((double)miningOutput.data.reportedHashrate / 1000000, 2)).ToString() + " MH/s";
                siacurHashrate.Text = "Current Hashrate: " + (Math.Round(miningOutput.hashes / 1000000, 2)).ToString() + " MH/s";
                ethworkers.Text = "Unpaid Balance: " + (Math.Round(double.Parse(miningOutput.balance), 2)).ToString() + " Sia";
                siaearnings.Text = "Total Earnings: " + (Math.Round(double.Parse(miningOutput.paid), 2)).ToString() + " Sia";
            }
        }
    }
}