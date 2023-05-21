using System;
using HealthIdentifiers.Tool.Enums;
using Australian = HealthIdentifiers.Identifiers.Australian.MedicareNumber;
namespace HealthIdentifiers.Tool.Model;

public sealed class MedicareNumberIdentifier : Identifier
{
  private Australian.IMedicareNumber _identifier;
  private readonly Australian.IMedicareMedicareNumberGenerator _generator;
  private readonly Australian.IMedicareNumberParser _parser;
  public MedicareNumberIdentifier()
    : base(IdentifierType.MedicareNumber, "Medicare Number")
  {
    _generator = new Australian.MedicareMedicareNumberGenerator();
    _parser = new Australian.MedicareNumberParser();
    _identifier = new Australian.MedicareNumber();
    SetIdentifierComponents();
  }

  public override bool Validate(string value)
  {
    if (_parser.TryParse(value.Replace(" ", String.Empty).Trim(), out Australian.IMedicareNumber identifier))
    {
      _identifier = identifier;
      SetValidIdentifier();
      return true;
    }
    _identifier = new Australian.MedicareNumber();
    SetInValidIdentifier(value);
    return false;
  }
  public override string FormattedIdentifierValue()
  {
    return _identifier.ValueDisplay;
  }
  
  public override void GenerateRandomIdentifier()
  {
    if (_parser.TryParse(_generator.Generate(true), out Australian.IMedicareNumber identifier))
    {
      _identifier = identifier;
      SetValidIdentifier();
    }
    else
    {
      throw new ApplicationException("Application generated and invalid identifier");
    }
  }

  public override void SetIdentifierComponents()
  {
    ComponentList.Clear();
    ComponentList.Add(new IdentifierComponent(name: nameof(_identifier.Identifer), _identifier.Identifer ?? String.Empty));
    ComponentList.Add(new IdentifierComponent(name: nameof(_identifier.IssueNumber), _identifier.IssueNumber ?? String.Empty));
    ComponentList.Add(new IdentifierComponent(name: nameof(_identifier.Checksum), _identifier.Checksum ?? String.Empty));
    ComponentList.Add(new IdentifierComponent(name: nameof(_identifier.IRN), _identifier.IRN ?? String.Empty));
  }
}
