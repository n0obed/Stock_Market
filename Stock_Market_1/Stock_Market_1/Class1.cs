using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScottPlot;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Threading;


namespace Stock_Market_1
{
    public class Class1
    {
        public struct InputLists
        {
            public string name;
            public int length;
            public IList<DateTime> dates { get; set; }
            public IList<double> vols { get; set; }
            public IList<double> opens { get; set; }
            public IList<double> highs { get; set; }
            public IList<double> lows { get; set; }
            public IList<double> closes { get; set; }
            public OHLC[] input_data { get; set; } 
        }

        InputLists returnValues;


        public static JObject jmetadata; // 5 keys with symbol timezone etc.
        public static JObject jdates;
        public static HttpClient client = new HttpClient();


        async public Task<JObject> Request(string symbol, int n) // returns useless string, public jdates and jmetadata is stored.
        {
            client = new HttpClient();
            symbol = symbol.ToUpper();
            string query = " ";
            switch (n)
            {
                case 0:
                    query = "htt" + "ps://www.alphavantage.co/query?function=TIME_SERIES_DAILY&symbol=" + symbol + "&outputsize=compact&apikey=Z2VTC5UXO1MWN9MP";
                    break;
                case 1:
                    query = "htt" + "ps://www.alphavantage.co/query?function=TIME_SERIES_WEEKLY&symbol=" + symbol + "&apikey=Z2VTC5UXO1MWN9MP";
                    break;
                case 2:
                    query = "htt" + "ps://www.alphavantage.co/query?function=TIME_SERIES_MONTHLY&symbol=" + symbol + "&apikey=Z2VTC5UXO1MWN9MP";
                    break;
            }
            
            Uri uri = new Uri(query);
            string response = "";
            HttpResponseMessage response_msg;
            // Call asynchronous network methods in a try/catch block to handle exceptions.

            try
            {
                Console.WriteLine(query);
                response_msg = await client.GetAsync(uri).ConfigureAwait(false); // get the response in HttpResponseMessage
                if (response_msg.IsSuccessStatusCode)
                {
                    response = await response_msg.Content.ReadAsStringAsync().ConfigureAwait(false); // wait for content to be read as string
                }
                
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }

            // to serliaze.
            JObject jdata = JObject.Parse(response); // jdata = converted str to JObject.

            foreach (KeyValuePair<string, JToken> pair in jdata)
            {
                //total of 2 iterations
                //1 Meta Data: all_head_info:(info,symbol,lastrefresh,outputsize,timezone).
                //2 Time Series (Daily): "2021-12-22":(open,high,low,close,volume),more.
                JToken dates = (JToken)pair.Value;
                //obj = (IList<JToken>)pair.Value;
                if (pair.Value.Count() > 5)
                {
                    jdates = JObject.Parse(dates.ToString());
                }
                else
                {
                    jmetadata = JObject.Parse(dates.ToString());
                }
            }
            Console.WriteLine("Response from server recieved.");
            return jdates;
        }

        public InputLists Data_Load(string symbol, int n)  // return data in required format.
        {
            Class1 class1 = new Class1();
            returnValues = new InputLists();
            //if (string.IsNullOrEmpty(symbol) == true) { symbol = "IBM"; }
            Task<JObject> request1 = Request(symbol, n);
            request1.Wait();
            
            returnValues.length = request1.Result.Count;
            Console.WriteLine(returnValues.length);
            Console.WriteLine("why");
            returnValues.dates = new List<DateTime>();
            returnValues.vols = new List<double>();
            returnValues.opens = new List<double>();
            returnValues.highs = new List<double>();
            returnValues.lows = new List<double>();
            returnValues.closes = new List<double>();
            returnValues.name = (string)jmetadata["2. Symbol"];
            Console.WriteLine(returnValues.opens.Count);
            Console.WriteLine();

            foreach (KeyValuePair<string, JToken> item in request1.Result)
            {
                DateTime date = DateTime.Parse(item.Key);
                returnValues.dates.Add(date);
            }
            foreach (KeyValuePair<string, JToken> item in request1.Result) // get the initial data to collect OHLC.
            {
                JToken OHLC2 = item.Value;
                List<JToken> tokens = OHLC2.Children().ToList(); // gets each 5 from data {"1. open": "143.8000","2. high": "144.1800","3. low": "142.4700","4. close": "142.7600","5. volume": "2830079"}
                int count = 0;
                foreach (JToken token in tokens) // token = "1. open": "143.800"
                { // iterations as open, high, low, close, vol.
                    string name = (string)token;
                    double value = Convert.ToDouble(name);
                    switch (count)
                    {
                        case 0:
                            count++;
                            returnValues.opens.Add(value);
                            break;

                        case 1:
                            count++;
                            returnValues.highs.Add(value);
                            break;

                        case 2:
                            count++;
                            returnValues.lows.Add(value);
                            break;

                        case 3:
                            count++;
                            returnValues.closes.Add(value);
                            break;

                        case 4:
                            count = 0;
                            returnValues.vols.Add(value);
                            break;
                    }
                }
            }
            returnValues.length = returnValues.opens.Count;

            returnValues.input_data = new OHLC[returnValues.length];
            TimeSpan timespan = TimeSpan.Parse("1.00:00:00");
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

            for (int i = 0; i < returnValues.length; i++)
            {
                returnValues.input_data[i] = new OHLC(returnValues.opens[i], returnValues.highs[i], returnValues.lows[i], returnValues.closes[i], returnValues.dates[i], timespan);
            }

            Console.WriteLine("Data stored in needed format.  " + returnValues.name);
            return returnValues;
        }
    }
}
