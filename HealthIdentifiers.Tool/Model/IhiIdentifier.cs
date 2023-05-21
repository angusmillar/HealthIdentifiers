using System;
using HealthIdentifiers.Tool.Enums;
using Australian = HealthIdentifiers.Identifiers.Australian.NationalHealthcareIdentifier;
namespace HealthIdentifiers.Tool.Model;

public sealed class IhiIdentifier : Identifier
{
  private Australian.IIndividualHealthcareIdentifier _identifier;
  private readonly Australian.IndividualHealthcareIdentifierGenerator _generator;
  private readonly Australian.IndividualHealthcareIdentifierParser _parser;
  
  public IhiIdentifier() 
    : base(IdentifierType.Ihi, "IHI")
  {
    _identifier = new Australian.IndividualHealthcareIdentifier();
    _generator = new Australian.IndividualHealthcareIdentifierGenerator();
    _parser = new Australian.IndividualHealthcareIdentifierParser();
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
    _identifier = new Australian.IndividualHealthcareIdentifier();
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
    ComponentList.Add(new IdentifierComponent(name: nameof(_identifier.IndustryCode), _identifier.IndustryCode ?? String.Empty));
    ComponentList.Add(new IdentifierComponent(name: nameof(_identifier.CountryCode), _identifier.CountryCode ?? String.Empty));
    ComponentList.Add(new IdentifierComponent(name: nameof(_identifier.NumberIssuerCode), _identifier.NumberIssuerCode ?? String.Empty));
    ComponentList.Add(new IdentifierComponent(name: nameof(_identifier.UniqueReference), _identifier.UniqueReference ?? String.Empty));
    ComponentList.Add(new IdentifierComponent(name: nameof(_identifier.CheckDigit), _identifier.CheckDigit ?? String.Empty));
  }
}
