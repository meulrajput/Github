using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Github.Models
{
    public class UserView
    {
        public string name { get; set; }

        public string location { get; set; }
        public string avatar_url { get; set; }
        public string repos_url { get; set; }

        public List<Repository> repositories { get; set; }
    }
}