namespace HealthIdentifiers.Tool.Model;

public class IdentifierComponent
{
    public IdentifierComponent(string name,
        string value)
    {
        Name = name;
        Value = value;
    }

    public string Name { get; set; }
    public string Value { get; set; }
}