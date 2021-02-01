using System;
using System.Collections.Generic;
using System.Text;

namespace BetBullAssessment.ApiFolder
{
    public class Data
    {
        public int id { get; set; }
        public string email { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string avatar { get; set; }
        public string password { get; set; }
        public string token { get; set; }
        public string error { get; set; }

    }
    public class Support
    {
        public string url { get; set; }
        public string text { get; set; }

    }
    public class Application
    {
        public int page { get; set; }
        public int per_page { get; set; }
        public int total { get; set; }
        public int total_pages { get; set; }
        public List<Data> data { get; set; }
        public Support support { get; set; }

    }
}
