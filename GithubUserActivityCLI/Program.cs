using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

//while(true)
//{
//    Console.WriteLine("Enter command: ");
//    var input = Console.ReadLine();

//    if(input == "exit")
//    {
//        Console.WriteLine("Exiting program...");
//        break;
//    }
//}

using HttpClient client = new();
client.BaseAddress = new Uri("https://api.github.com");
client.DefaultRequestHeaders.Accept.Clear();
client.DefaultRequestHeaders.Accept.Add(
    new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
client.DefaultRequestHeaders.Add("User-Agent", "Edward's GithubActivityCLI");

await ProcessRepositoriesAsync(client);

static async Task ProcessRepositoriesAsync(HttpClient client)
{
    var json = await client.GetStringAsync(client.BaseAddress + "users/edward-solutions/events/public");
    //Console.WriteLine(json);

    var result = await client.GetFromJsonAsync<List<Repository>>("https://api.github.com/users/edward-solutions/events/public") ?? new List<Repository>();

    Console.WriteLine("Here are the events");
    foreach (var item in result)
    {
        Console.WriteLine($"Event Type: {item.type} Repo: {item.repo.name}");
    }
}
public record Repository(string type, Repo repo);
public record Repo(string name);
