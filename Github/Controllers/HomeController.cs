using Github.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Github.Controllers
{
    public class HomeController : Controller
    {
        private readonly string githubApi = "https://api.github.com/";
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(string searchTerm)
        {
            if (!string.IsNullOrEmpty(searchTerm))
            {
                #region WebClient
                //var url = githubApi + $"users/{searchTerm}";
                //using (var webClient = new WebClient())
                //{
                //    webClient.Headers.Add("user-agent", "other");
                //    var rawJSON = webClient.DownloadString(url);
                //    UserView userView = JsonConvert.DeserializeObject<UserView>(rawJSON);
                //    if (userView.repos_url != null)
                //    {
                //        webClient.Headers.Add("user-agent", "other");
                //        rawJSON = webClient.DownloadString(userView.repos_url);
                //        List<Models.Repository> repositories = JsonConvert.DeserializeObject<List<Models.Repository>>(rawJSON);
                //        userView.repositories = repositories.OrderByDescending(rep => rep.stargazers_count).Take(5).ToList();
                //    }
                //    return View(userView);
                //}
                #endregion

                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(githubApi);
                    client.DefaultRequestHeaders.Add("user-agent", "other");
                    HttpResponseMessage response = await client.GetAsync($"users/{searchTerm}");
                    if (response.IsSuccessStatusCode)
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        UserView userView = JsonConvert.DeserializeObject<UserView>(data);
                        if (userView.Repos_url != null)
                        {
                            response = await client.GetAsync(userView.Repos_url);
                            if (response.IsSuccessStatusCode)
                            {
                                data = await response.Content.ReadAsStringAsync();
                                List<Models.Repository> repositories = JsonConvert.DeserializeObject<List<Models.Repository>>(data);
                                userView.Repositories = repositories.OrderByDescending(rep => rep.stargazers_count).Take(5).ToList();
                            }
                        }
                        return View(userView);
                    }
                    return View();
                }
            }
            return View();


        }
    }
}
