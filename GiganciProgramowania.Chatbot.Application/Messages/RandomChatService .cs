namespace GiganciProgramowania.Chatbot.Application.Messages;

public class RandomChatService : IChatService
{
    private static readonly string[] sampleResponses = new string[]
    {
        "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
        "Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
        "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
        "Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.",
        "Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
        "Curabitur pretium tincidunt lacus. Nulla gravida orci a odio. Nullam varius, turpis et commodo pharetra, est eros bibendum elit, nec luctus magna felis sollicitudin mauris.",
        "Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas.",
        "Fusce euismod consequat ante. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam.",
        "Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Morbi lacinia, nunc at aliquet vulputate, augue nisi fermentum arcu, vitae vestibulum nisl risus eget lorem."
    };

    private Random _random = new Random();

    public async Task<string> GenerateResponse(string userMessage)
    {
        await Task.Delay(1000);

        int numberOfSentences = _random.Next(1, 4);
        string response = "";

        for (int i = 0; i < numberOfSentences; i++)
        {
            response += sampleResponses[_random.Next(sampleResponses.Length)] + " ";
        }

        return await Task.FromResult(response.Trim());
    }
}