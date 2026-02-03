using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace GithubUserActivityCLI
{
    public class GitHubClientFactory
    {
        public static HttpClient Create()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://api.github.com/");
            client.DefaultRequestHeaders.Accept.Add(
           new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));

            client.DefaultRequestHeaders.UserAgent.ParseAdd("GithubActivityCLI");

            return client;
        }
    }
}
