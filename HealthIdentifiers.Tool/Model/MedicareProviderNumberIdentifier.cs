using System;
using HealthIdentifiers.Tool.Enums;
using Australian = HealthIdentifiers.Identifiers.Australian.MedicareProviderNumber;
namespace HealthIdentifiers.Tool.Model;

public sealed class MedicareProviderNumberIdentifier : Identifier
{
  private Australian.IMedicareProviderNumber _identifier;
  private readonly Australian.IMedicareProviderNumberGenerator _generator;
  private readonly Australian.MedicareProviderNumberParser _parser;
  
  public MedicareProviderNumberIdentifier() 
    : base(IdentifierType.MedicareProviderNumber, "Medicare Provider Number")
  {
    _generator = new Australian.MedicareProviderNumberGenerator();
    _parser = new Australian.MedicareProviderNumberParser();
    _identifier = new Australian.MedicareProviderNumber();
    SetIdentifierComponents();
  }
  public override bool Validate(string value)
  {
    if (_parser.TryParse(value.Replace(" ", String.Empty).Trim(), out var identifier))
    {
      _identifier = identifier;
      SetValidIdentifier();
      return true;
    }
    _identifier = new Australian.MedicareProviderNumber();
    SetInValidIdentifier(value);
    return false;
  }
  public override void GenerateRandomIdentifier()
  {
    if (_parser.TryParse(_generator.Generate(), out var identifier))
    {
      _identifier = identifier;
      SetValidIdentifier();
    }
    else
    {
      throw new ApplicationException("Application generated and invalid identifier");
    }
  }
  public override string FormattedIdentifierValue()
  {
    return _identifier.ValueDisplay;
  }
  public override void SetIdentifierComponents()
  {
    ComponentList.Clear();
    ComponentList.Add(new IdentifierComponent(name: nameof(_identifier.Stem), _identifier.Stem ?? String.Empty));
    ComponentList.Add(new IdentifierComponent(name: nameof(_identifier.LocationCharacter), _identifier.LocationCharacter ?? String.Empty));
    ComponentList.Add(new IdentifierComponent(name: nameof(_identifier.CheckCharacter), _identifier.CheckCharacter ?? String.Empty));
  }
}
