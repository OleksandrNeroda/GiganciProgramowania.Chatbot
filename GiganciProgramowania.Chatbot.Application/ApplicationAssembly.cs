using System.Reflection;
using GiganciProgramowania.Chatbot.Application.Messages.SendMessage;

namespace GiganciProgramowania.Chatbot.Application
{
    public static class ApplicationAssembly
    {
        public static readonly Assembly Application = typeof(SendMessageCommand).Assembly;
    }
}
