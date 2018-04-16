using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace ConsoleApp1
{
    
    public class Settings
    {
        public bool is_public { get; set; }
        public bool is_trial { get; set; }
    }

    public class Self
    {
        public string href { get; set; }
    }

    public class Theme
    {
        public string href { get; set; }
    }

    public class Links
    {
        public string display { get; set; }
    }

    public class Item
    {
        public string id { get; set; }
        public string title { get; set; }
        public DateTime last_updated_at { get; set; }
        public Settings settings { get; set; }
        public Self self { get; set; }
        public Theme theme { get; set; }
        public Links _links { get; set; }
    }

    public class RootObject
    {
        public int total_items { get; set; }
        public int page_count { get; set; }
        public List<Item> items { get; set; }
    }

    class Program
    {
        async static Task req()
        {
            
            string url = "https://api.typeform.com/forms/uB6Jj8/responses";
            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.TryAddWithoutValidation("authorization", "bearer BWGey6f4itiRXzCXk2MwrfKhtsEgNqLaM8ygNZR17dtj");
                    
                    var response = await client.GetAsync(url);
                    Task<string> responseString = response.Content.ReadAsStringAsync();
                    string outputJson = await responseString;
                Console.WriteLine("finis");
                var res = JsonConvert.DeserializeObject<RootObject>(outputJson);



                return;
            }
            

        }
        static void Main(string[] args)
        {
            req().Wait();
            

        }
    }
}
