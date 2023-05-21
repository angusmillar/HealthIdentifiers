using System;
using HealthIdentifiers.Tool.Enums;
using Australian = HealthIdentifiers.Identifiers.Australian.NationalHealthcareIdentifier;
namespace HealthIdentifiers.Tool.Model;

public sealed class HpiiIdentifier : Identifier
{
  private Australian.IHealthcareProviderIdentifierIndividual _identifier;
  private readonly Australian.HealthcareProviderIdentifierIndividualGenerator _generator;
  private readonly Australian.HealthcareProviderIdentifierIndividualParser _parser;
  
  public HpiiIdentifier() 
    : base(IdentifierType.Hpii, "HPI-I")
  {
    _identifier = new Australian.HealthcareProviderIdentifierIndividual();
    _generator = new Australian.HealthcareProviderIdentifierIndividualGenerator();
    _parser = new Australian.HealthcareProviderIdentifierIndividualParser();
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
    _identifier = new Australian.HealthcareProviderIdentifierIndividual();
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
