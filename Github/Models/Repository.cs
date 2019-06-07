using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Github.Models
{
    public class Repository
    {
        public string name { get; set; }
        public string language { get; set; }
        public string updated_at { get; set; }
        public int stargazers_count { get; set; }
    }
}