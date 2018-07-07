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
        }
        private void refreshButton_clicked(object sender, EventArgs e)
        {
            //RootObject root = new RootObject();

            string URL = "https://api.ethermine.org/miner/:0xcC61A3210F9feF03038eE100fA9Dd4a1dA8BfdC2/currentStats";
            using (var webClient = new System.Net.WebClient())
            {
                var json = webClient.DownloadString(URL);
                // Now parse with JSON.Net
                RootObject miningOutput = JsonConvert.DeserializeObject<RootObject>(json);

                hashrate.Text = miningOutput.data.averageHashrate.ToString();
            }
        }
    }
}
