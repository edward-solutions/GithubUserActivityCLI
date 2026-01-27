using System.Net.Http.Headers;

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
client.DefaultRequestHeaders.Accept.Clear();
client.DefaultRequestHeaders.Accept.Add(
    new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
client.DefaultRequestHeaders.Add("User-Agent", "Edward's GithubActivityCLI");

await ProcessRepositoriesAsync(client);

static async Task ProcessRepositoriesAsync(HttpClient client)
{
    var json = await client.GetStringAsync($"https://api.github.com/users/edward-solutions/events/public");
    Console.WriteLine(json);
}


