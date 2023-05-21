using System;
using HealthIdentifiers.Tool.Enums;
using Australian = HealthIdentifiers.Identifiers.Australian.NationalHealthcareIdentifier;
namespace HealthIdentifiers.Tool.Model;

public sealed class HpioIdentifier : Identifier
{
  private Australian.IHealthcareProviderIdentifierOrganisation _identifier;
  private readonly Australian.HealthcareProviderIdentifierOrganisationGenerator _generator;
  private readonly Australian.HealthcareProviderIdentifierOrganisationParser _parser;
  
  public HpioIdentifier() 
    : base(
      IdentifierType.Hpio, 
      "HPI-O",
      "Healthcare Provider Identifier - Organisation",
      @"/Images/hpi-o.png")
  {
    _identifier = new Australian.HealthcareProviderIdentifierOrganisation();
    _generator = new Australian.HealthcareProviderIdentifierOrganisationGenerator();
    _parser = new Australian.HealthcareProviderIdentifierOrganisationParser();
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
    _identifier = new Australian.HealthcareProviderIdentifierOrganisation();
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
