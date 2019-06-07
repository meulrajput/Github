using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Github.Models
{
    public class UserView
    {
        public string Name { get; set; }

        public string Location { get; set; }
        public string Avatar_url { get; set; }
        public string Repos_url { get; set; }

        public List<Repository> Repositories { get; set; }
    }
}