namespace GiganciProgramowania.Chatbot.Application.Messages;

public interface IChatService
{
    Task<string> GenerateResponse(string userMessage);
}
