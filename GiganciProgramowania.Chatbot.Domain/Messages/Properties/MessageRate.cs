using GiganciProgramowania.BuildingBlocks.Domain;
using System.Reflection;

namespace GiganciProgramowania.Chatbot.Domain.Messages.Properties;

public record MessageRate : ValueObject
{
    public string Code { get; set; }
    public string Name { get; set; }

    public static MessageRate Missing => new(nameof(Missing), "Missing");

    public static MessageRate Negative => new(nameof(Negative), "Dislike");

    public static MessageRate Positive => new(nameof(Positive), "Like");

    private MessageRate(string code, string name)
    {
        Code = code;
        Name = name;
    }

    public static MessageRate OfCode(string code)
    {
        return code switch
        {
            nameof(Missing) => Missing,
            nameof(Negative) => Negative,
            nameof(Positive) => Positive,
            _ => throw new ArgumentOutOfRangeException(nameof(code), code, "Unknown name for the MessageRate.")
        };
    }
}
