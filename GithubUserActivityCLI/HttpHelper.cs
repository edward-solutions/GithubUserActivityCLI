using System.Net.Http.Json;
using System.Reflection.Metadata.Ecma335;

namespace GithubUserActivityCLI
{
    public record Repository(string type, Repo repo);
    public record Repo(string name);
    public static class GithubApi
    {
        public static async Task<IReadOnlyList<Repository>> GetUserEventsAsync(HttpClient client, string userName)
        {
            var response = await client.GetAsync($"users/{userName}/events/public");

            if(!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(
            $"GitHub API returned {(int)response.StatusCode} ({response.ReasonPhrase})");
            }

            return await response.Content.ReadFromJsonAsync<List<Repository>>() ?? [];
        }
    }
}
