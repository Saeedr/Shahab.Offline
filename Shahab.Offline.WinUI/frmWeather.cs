using System;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Web;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;

namespace Shahab.Offline.WinUI
{
    public partial class frmWeather : Form
    {
        public class Condition
        {
            public string temp { get; set; }
            public string text { get; set; }
        }

        public class Forecast
        {
            public string high { get; set; }
            public string low { get; set; }
            public string text { get; set; }
        }

        public class Item
        {
            public Condition condition { get; set; }
            public string description { get; set; }
            public List<Forecast> forecast { get; set; }
        }

        public class Atmosphere
        {
            public string humidity { get; set; }
        }

        public class Channel
        {
            public Item item { get; set; }
            public Atmosphere atmosphere { get; set; }
        }

        public class Results
        {
            public Channel channel { get; set; }
        }

        public class Query
        {
            public Results results { get; set; }
        }

        public class RootObject
        {
            public Query query { get; set; }
        }

        public class Convert
        {
            public static int FahrenheitToCelsius(double f)
            {
                return (int)((5.0 / 9.0) * (f - 32));
            }

            public static string ConditionTextToPersian(string s)
            {
                string p = "";
                switch (s)
                {
                    case "fair":
                        p = "نسبتا خوب";
                        break;
                    case "cloudy":
                        p = "ابری";
                        break;
                    case "clear":
                        p = "صاف";
                        break;
                    case "sunny":
                        p = "آفتابی";
                        break;
                    case "partly cloudy":
                        p = "نیمه ابری";
                        break;
                    case "mostly cloudy":
                        p = "تمام ابری";
                        break;
                }
                return p;
            }
        }

        public class Weather
        {
            public static RootObject GetData(string city)
            {
                string query = "select * from weather.forecast where woeid in (select woeid from geo.placefinder where text='" + city + "')";
                StringBuilder theWebAddress = new StringBuilder();
                theWebAddress.Append("http://query.yahooapis.com/v1/public/yql?");
                theWebAddress.Append("q=" + HttpUtility.UrlEncode(query));
                theWebAddress.Append("&format=json");
                theWebAddress.Append("&diagnostics=false");
                string results = "";
                using (WebClient wc = new WebClient())
                {
                    wc.Encoding = Encoding.UTF8;
                    results = wc.DownloadString(theWebAddress.ToString());
                }
                return Newtonsoft.Json.JsonConvert.DeserializeObject<RootObject>(results);
            }
        }

        public frmWeather()
        {
            InitializeComponent();
        }

        private void frmWeather_Load(object sender, EventArgs e)
        {
            try
            {
                boCityName.SelectedIndex = 0;
                RootObject obj = Weather.GetData("tehran");
                lblCurrentConditions.Text = Convert.ConditionTextToPersian(obj.query.results.channel.item.condition.text.ToLower());
                lblCurrentTemp.Text = Convert.FahrenheitToCelsius(double.Parse(obj.query.results.channel.item.condition.temp)).ToString();
                lblHighTemp.Text = Convert.FahrenheitToCelsius(double.Parse(obj.query.results.channel.item.forecast[0].high)).ToString();
                lblLowTemp.Text = Convert.FahrenheitToCelsius(double.Parse(obj.query.results.channel.item.forecast[0].low)).ToString();
                lblHumidity.Text = obj.query.results.channel.atmosphere.humidity + "%";
                pictureBoxWeatherForecast.Load(Regex.Match(obj.query.results.channel.item.description, "<img.+?src=[\"'](.+?)[\"'].+?>", RegexOptions.IgnoreCase).Groups[1].Value);
            }
            catch (Exception Ex)
            {
                MessageBox.Show("خطا در اتصال به سرویس" + Environment.NewLine + Ex.Message, "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX3_Click(object sender, System.EventArgs e)
        {
            try
            {
                RootObject obj = Weather.GetData(boCityName.Text);
                lblCurrentConditions.Text = Convert.ConditionTextToPersian(obj.query.results.channel.item.condition.text.ToLower());
                lblCurrentTemp.Text = Convert.FahrenheitToCelsius(double.Parse(obj.query.results.channel.item.condition.temp)).ToString();
                lblHighTemp.Text = Convert.FahrenheitToCelsius(double.Parse(obj.query.results.channel.item.forecast[0].high)).ToString();
                lblLowTemp.Text = Convert.FahrenheitToCelsius(double.Parse(obj.query.results.channel.item.forecast[0].low)).ToString();
                lblHumidity.Text = obj.query.results.channel.atmosphere.humidity + "%";
                pictureBoxWeatherForecast.Load(Regex.Match(obj.query.results.channel.item.description, "<img.+?src=[\"'](.+?)[\"'].+?>", RegexOptions.IgnoreCase).Groups[1].Value);
            }
            catch(Exception Ex)
            {
                MessageBox.Show("خطا در اتصال به سرویس" + Environment.NewLine + Ex.Message, "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX1_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
