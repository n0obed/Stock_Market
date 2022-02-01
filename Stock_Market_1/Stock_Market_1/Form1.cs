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
using System.Diagnostics;

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
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
            Console.WriteLine("starting...");
            inputvalues = class1.Data_Load("IBM", 0);
            InitializeComponent();
            this.Text = "StockMarketApp";
            Width = 1000;
            Height = 800;
            //BackColor = Color.Azure;
            Color col = ColorTranslator.FromHtml("#f5f5f5");
            Font font = new Font(Font.FontFamily, 10);
            BackColor = col;
            checkedListBox1.BackColor = col;
            NSEButton.BackColor = col;
            localLoad.BackColor = col;
            Save.BackColor = col;
            Search.BackColor = col;
            Indicators.BackColor = col;
            checkedListBox1.Font = font;
            NSEButton.Font = font;
            localLoad.Font = font;
            Save.Font = font;
            Search.Font = font;
            Indicators.Font = font;

            Color col1 = ColorTranslator.FromHtml("#8f8f8f");
            button1.BackColor = col1;
            button1.ForeColor = Color.Transparent;
            
            tableLayoutPanel1.Enabled = true;
            tableLayoutPanel1.Size = new Size(Size.Width, Size.Height);
            filesystem = data.ReadDirectoires();

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.W)
            {
                Application.Exit();
            }
        }

        public void Form1_Load(object sender, EventArgs e)  // styling the graph. and uploading input to graph.
        {
            

            //OHLCs are open, high, low, and closing prices for a time range.
            var fp = formsPlot1.Plot.AddCandlesticks(inputvalues.input_data);
            fp.ColorUp = ColorTranslator.FromHtml("#11D911");
            fp.ColorDown = ColorTranslator.FromHtml("#D91111");

            searchComboBox.SelectedIndex = 0;
            loadComboBox1.SelectedIndex = 0;
            loadComboBox2.SelectedIndex = 0;
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

        private void Indicators_Click(object sender, EventArgs e)
        {
            formsPlot1.Plot.Clear();
            var a = formsPlot1.Plot.AddCandlesticks(inputvalues.input_data);
            a.ColorUp = ColorTranslator.FromHtml("#11D911");
            a.ColorDown = ColorTranslator.FromHtml("#D91111");
            for (int i = 0; i < 3; i++)
            {
                if (checkedListBox1.GetItemChecked(i))
                {
                    switch (i)
                    {
                        case 0:
                            var sma5 = a.GetSMA(5);
                            var smaplot5 = formsPlot1.Plot.AddScatterLines(sma5.xs, sma5.ys, Color.LightBlue, 1, LineStyle.Dash, "5 day SMA");
                            break;

                        case 1:
                            var sma8 = a.GetSMA(8);
                            var smaplot8 = formsPlot1.Plot.AddScatterLines(sma8.xs, sma8.ys, Color.Yellow, 1, LineStyle.Dash, "8 day SMA");
                            break;

                        case 2:
                            var sma20 = a.GetSMA(20);
                            var smaplot20 = formsPlot1.Plot.AddScatterLines(sma20.xs, sma20.ys, Color.Orange, 1, LineStyle.Dash, "20 day SMA");
                            break;
                    }
                }
            }
            var legend = formsPlot1.Plot.Legend();
            legend.FontSize = 16;
            legend.FillColor = Color.Black;
            legend.OutlineColor = Color.White;
            legend.Font.Color = Color.White;
            legend.Font.Bold = true;
            formsPlot1.Plot.Render();
            formsPlot1.Refresh();
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
            loadComboBox2.SelectedIndex = 0;
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

        private void NSEButton_Click(object sender, EventArgs e)
        {
            var psi = new ProcessStartInfo();
            psi.FileName = @"C:/Users/nikhil/AppData/Local/Programs/Python/Python39/python.exe";
            var script = @"D:\Apps\VisualStudio\source\repos\Stock_Market_1\Stock_Market_1\Data\NSEpy.py";
            string Symbol = NSEBox.Text;
            //psi.Arguments = $"\"{script}\"\"{Symbol}\"";
            psi.Arguments = string.Format("{0} {1}", script, Symbol);
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;

            // Errors and prints
            var errors = "";
            var results = "";
            using (var process = Process.Start(psi))
            {
                errors = process.StandardError.ReadToEnd();
                results = process.StandardOutput.ReadToEnd();
            }

            Console.WriteLine("Errors");
            Console.WriteLine(errors);
            Console.WriteLine();
            Console.WriteLine("Results");
            Console.WriteLine(results);
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