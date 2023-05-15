using HealthIdentifiers.Tool.Enums;

namespace HealthIdentifiers.Tool;

public class Identifier
{
    public Identifier(IdentifierType type,
        string displayName)
    {
        Type = type;
        DisplayName = displayName;
        DisplayData = "Assigning Auth : Medicare\nThis Thing: Ouch \nThird: Test";
    }

    public IdentifierType Type { get; set; }
    public string DisplayName { get; set; }
    
    public string DisplayData { get; set; }
}