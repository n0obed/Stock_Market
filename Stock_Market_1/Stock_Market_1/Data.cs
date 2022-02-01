using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScottPlot;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Stock_Market_1
{
    internal class Data
    {
        public struct FileSystem
        {
            public FileInfo[] daily { get; set; }
            public FileInfo[] weekly { get; set; }
            public FileInfo[] monthly { get; set; }
        }


        public string path = "D:/Apps/VisualStudio/source/repos/Stock_Market_1/Stock_Market_1/Data/";
        public Dictionary<int, string> saveWith = new Dictionary<int, string> { { 0, "Daily/" }, { 1, "Weekly/" }, { 2, "Monthly/" } };
        public Class1.InputLists listValues;


        public void Save(Class1.InputLists input, int value)
        {


            var array1 = JArray.FromObject(input.dates);
            var array2 = JArray.FromObject(input.vols);
            var array3 = JArray.FromObject(input.opens);
            var array4 = JArray.FromObject(input.highs);
            var array5 = JArray.FromObject(input.lows);
            var array6 = JArray.FromObject(input.closes);

            var array7 = new JArray { array1, array2, array3, array4, array5, array6 };

            var json = JsonConvert.SerializeObject(array7);
            System.IO.File.WriteAllText(path + saveWith[value] + input.name.Replace(":", "_") + ".json", json);
            Console.WriteLine("Saved to " + path + saveWith[value] + input.name.Replace(":", "_") + ".json");
            Console.WriteLine();
        }

        public FileSystem ReadDirectoires()
        {
            FileSystem filesystem = new FileSystem();
            for (int i = 0; i < 3; i++)
            {
                DirectoryInfo d = new DirectoryInfo("D:/Apps/VisualStudio/source/repos/Stock_Market_1/Stock_Market_1/Data/" + saveWith[i]);
                switch (i)
                {
                    case 0:
                        filesystem.daily = d.GetFiles("*.json");
                        break;
                    case 1:
                        filesystem.weekly = d.GetFiles("*.json");
                        break;
                    case 2:
                        filesystem.monthly = d.GetFiles("*.json");
                        break;
                }
            }
            return filesystem;
        }
        
        public Class1.InputLists LocalLoad(int n, string name)
        {
            //dates vols opens highs lows closes
            listValues = new Class1.InputLists();
            string path_load = path + saveWith[n] + name;
            Console.WriteLine(path_load);
            int count = 0;
            using (StreamReader r = new StreamReader(path_load))
            {
                string json = r.ReadToEnd();
                JArray items = JsonConvert.DeserializeObject<JArray>(json);
                listValues.length = items[0].Count();
                listValues.name = name.Replace(".json", "");
                foreach (JArray item in items)
                {
                    switch (count)
                    {
                        case 0:
                            listValues.dates = item.ToObject<List<DateTime>>(); ;
                            count++;
                            break;

                        case 1:
                            listValues.vols = item.ToObject<List<double>>();
                            count++;
                            break;

                        case 2:
                            listValues.opens = item.ToObject<List<double>>();
                            count++;
                            break;

                        case 3:
                            listValues.highs = item.ToObject<List<double>>();
                            count++;
                            break;

                        case 4:
                            listValues.lows = item.ToObject<List<double>>();
                            count++;
                            break;

                        case 5:
                            listValues.closes = item.ToObject<List<double>>();
                            count = 0;
                            break;
                    }
                }
            }
            TimeSpan timespan = TimeSpan.Parse("1.00:00:00");
            listValues.input_data = new OHLC[listValues.length];
            switch (n)
            {
                case 0:
                    timespan = TimeSpan.Parse("1.00:00:00");
                    break;
                case 1:
                    timespan = TimeSpan.Parse("7.00:00:00");
                    break;
                case 2:
                    timespan = TimeSpan.Parse("30.00:00:00");
                    break;
            }
            for (int i = 0; i < listValues.length; i++)
            {
                listValues.input_data[i] = new OHLC(listValues.opens[i], listValues.highs[i], listValues.lows[i], listValues.closes[i], listValues.dates[i], timespan);
            }

            Console.WriteLine("Loaded from local directory.");
            Console.WriteLine();
            return listValues;
        }
    }
}