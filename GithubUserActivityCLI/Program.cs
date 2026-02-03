using GithubUserActivityCLI;

using HttpClient client = GitHubClientFactory.Create();

while (true)
{
    var baseKeyword = string.Empty;
    var userName = string.Empty;
    Console.WriteLine("Enter command: ");
    var input = Console.ReadLine();

    if (input == "exit")
    {
        Console.WriteLine("Exiting program...");
        break;
    }

    try
    {
        if (!string.IsNullOrEmpty(input) && ValidationHelper.TryValidate(input, out string error))
        {
            baseKeyword = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).FirstOrDefault();
            userName = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).LastOrDefault() ?? string.Empty;
        }

        var repos = await GithubApi.GetUserEventsAsync(client, userName);

        Console.WriteLine("Output: ");
        foreach(var repo in repos)
        {
            Console.WriteLine($"{repo.type} happened on {repo.repo.name}");
        }
    }
    catch (Exception)
    {
        throw;
    }

}


