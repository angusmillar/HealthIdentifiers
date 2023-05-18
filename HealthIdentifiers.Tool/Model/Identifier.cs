using System;
using System.Collections.Generic;
using HealthIdentifiers.Tool.Enums;

namespace HealthIdentifiers.Tool.Model;

public abstract class Identifier
{
    public Identifier(IdentifierType type, string displayName)
    {
        Type = type;
        DisplayName = displayName;
        ComponentList = new List<IdentifierComponent>();
        Value = string.Empty;
    }

    public IdentifierType Type { get; set; }
    public string DisplayName { get; set; }
    public IList<IdentifierComponent> ComponentList { get; set; }
    public string Value { get; set; }
    public abstract bool IsValid();
    public abstract string GenerateRandomIdentifier();
}