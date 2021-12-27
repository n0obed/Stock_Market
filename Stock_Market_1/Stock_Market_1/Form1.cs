using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Text;
using System.Threading.Tasks;
using ScottPlot;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net.Http;
using System.Globalization;
using static Stock_Market_1.Class1;
using ScottPlot.Renderable;
using System.Drawing.Drawing2D;
using System.IO;

namespace Stock_Market_1
{
    public partial class Form1 : Form
    {
        public static HttpClient client = new HttpClient();
        public const string path = "D:/Apps/VisualStudio/source/repos/StockMarket/StockMarket/Data/";
        Class1.InputLists inputvalues = new Class1.InputLists();
        public List<DateTime> dates = new List<DateTime>();
        public Class1 class1 = new Class1();
        public int button_toggle = 0;
        public string chart_header = "";
        Data.FileSystem filesystem = new Data.FileSystem();
        // for input download and format.
        public static JObject jmetadata; // 5 keys with symbol timezone etc.
        public static JObject jdates;
        public int length;
        public OHLC[] input_data;
        Data data = new Data();








        public Form1()  // Main running file.
        {
            Console.WriteLine("starting...");
            inputvalues = class1.Data_Load("IBM", 0);

            InitializeComponent();
            Width = 1000;
            Height = 800;
            //BackColor = Color.Azure;
            Color col = ColorTranslator.FromHtml("#f5f5f5");
            BackColor = col;
            Color col1 = ColorTranslator.FromHtml("#8f8f8f");
            button1.BackColor = col1;
            button1.ForeColor = Color.Transparent;
            

            tableLayoutPanel1.Enabled = true;
            tableLayoutPanel1.Size = new Size(Size.Width, Size.Height);
            filesystem = data.ReadDirectoires();

        }

        public void Form1_Load(object sender, EventArgs e)  // styling the graph. and uploading input to graph.
        {
            

            //OHLCs are open, high, low, and closing prices for a time range.
            var fp = formsPlot1.Plot.AddCandlesticks(inputvalues.input_data);
            fp.ColorUp = ColorTranslator.FromHtml("#11D911");
            fp.ColorDown = ColorTranslator.FromHtml("#D91111");


            searchComboBox.SelectedIndex = 0;
            formsPlot1.Plot.Style(Style.Gray2);
            //formsPlot1.Size = new Size(700, 800); //Size of plot graph.
            formsPlot1.MinimumSize = new Size(300, 300);
            formsPlot1.Location = new Point(0, -15); // location of plot.
            formsPlot1.AutoSize = true;
            //formsPlot1.Anchor = AnchorStyles.Left;
            formsPlot1.Plot.XAxis.DateTimeFormat(true);
            formsPlot1.Plot.XAxis.TickLabelStyle(Color.White);
            formsPlot1.Plot.XAxis.TickMarkColor(Color.GhostWhite, Color.Orange);
            formsPlot1.Plot.XAxis.MajorGrid(color: ColorTranslator.FromHtml("#999999"));
            string val = "Daily_" + inputvalues.name;
            formsPlot1.Plot.XAxis2.Label(val, Color.GhostWhite, 24);
            formsPlot1.Plot.YAxis.TickLabelStyle(Color.White);
            formsPlot1.Plot.YAxis.TickMarkColor(Color.White);
            formsPlot1.Plot.YAxis.MajorGrid(color: ColorTranslator.FromHtml("#AAAAAA"));
            formsPlot1.Plot.YAxis2.Ticks(false);
            formsPlot1.Plot.Benchmark(true);

            // SMA
            var sma8 = fp.GetSMA(8);
            var sma20 = fp.GetSMA(20);
            var sma8plot = formsPlot1.Plot.AddScatterLines(sma8.xs, sma8.ys, Color.Yellow, 1, LineStyle.Dash, "8 day SMA");
            var sma20plot = formsPlot1.Plot.AddScatterLines(sma20.xs, sma20.ys, Color.YellowGreen, (float)2, LineStyle.Dash, "20 day SMA");
            sma8plot.YAxisIndex = 1;
            sma20plot.YAxisIndex = 1;

            // Legend
            var legend = formsPlot1.Plot.Legend();
            legend.FontSize = 16;
            legend.FillColor = Color.Black;
            legend.OutlineColor = Color.White;
            legend.Font.Color = Color.White;
            legend.Font.Bold = true;

            formsPlot1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (button_toggle == 0)
            {
                tableLayoutPanel1.SetColumn(label1, 2);
                label1.Text = "Moved here.";
                button_toggle = 1;
            }
            else
            {
                tableLayoutPanel1.SetColumn(label1, 1);
                button_toggle = 0;
                label1.Text = textBox1.Text;
                chart_header = label1.Text;
                formsPlot1.Plot.XAxis2.Label(chart_header, Color.GhostWhite, 24);
                formsPlot1.Refresh();
            }
        }

        private void Search_Click(object sender, EventArgs e)
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>() { { 0, "Daily" }, { 1, "Weekly" }, { 2, "Monthly" } };
            string symbol = searchBox.Text;
            formsPlot1.Plot.Clear();
            inputvalues = new Class1.InputLists();
            inputvalues = class1.Data_Load(symbol, searchComboBox.SelectedIndex);
            var a = formsPlot1.Plot.AddCandlesticks(inputvalues.input_data);
            a.ColorUp = ColorTranslator.FromHtml("#11D911");
            a.ColorDown = ColorTranslator.FromHtml("#D91111");
            string val = dictionary[searchComboBox.SelectedIndex] + "_" + inputvalues.name;
            formsPlot1.Plot.XAxis2.Label(val, Color.GhostWhite, 24);
            formsPlot1.Plot.Render();
            formsPlot1.Refresh();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            Data data = new Data();
            data.Save(inputvalues, searchComboBox.SelectedIndex);
        }

        private void loadComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            filesystem = data.ReadDirectoires();
            loadComboBox2.Items.Clear();
            int i = loadComboBox1.SelectedIndex;
            FileInfo[] files = filesystem.daily;

            switch (i)
            {
                case 0:
                    files = filesystem.daily;
                    break;
                case 1:
                    files = filesystem.weekly;
                    break;
                case 2:
                    files = filesystem.monthly;
                    break;
            }

            foreach (FileInfo file in files)
            {
                string file_name = file.Name;
                loadComboBox2.Items.Add(file_name);
            }
            
        }

        private void localLoad_Click(object sender, EventArgs e)
        {
            formsPlot1.Plot.Clear();
            int i = (int)loadComboBox1.SelectedIndex;
            int j = (int)loadComboBox2.SelectedIndex;
            Dictionary<int, string> dictionary = new Dictionary<int, string>() { { 0, "Daily" }, { 1, "Weekly" }, { 2, "Monthly" } };
            if (j == -1) { j = 0; }
            string name = loadComboBox2.GetItemText(loadComboBox2.Items[j]);
            inputvalues = new Class1.InputLists();
            inputvalues = data.LocalLoad(i, name);
            var a = formsPlot1.Plot.AddCandlesticks(inputvalues.input_data);
            a.ColorUp = ColorTranslator.FromHtml("#11D911");
            a.ColorDown = ColorTranslator.FromHtml("#D91111");
            string val = dictionary[loadComboBox1.SelectedIndex] + "_" + inputvalues.name;
            formsPlot1.Plot.XAxis2.Label(val, Color.GhostWhite, 24);
            formsPlot1.Plot.Render();
            formsPlot1.Refresh();
        }



    }
}




// [2021-08-04, {   key : value
//   "1. open": "143.8000",
//   "2. high": "144.1800",
//   "3. low": "142.4700",
//   "4. close": "142.7600",
//   "5. volume": "2830079"
// }]