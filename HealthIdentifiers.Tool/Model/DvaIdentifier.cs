using System;
using HealthIdentifiers.Tool.Enums;
using Australian = HealthIdentifiers.Identifiers.Australian.DepartmentVeteransAffairs;
namespace HealthIdentifiers.Tool.Model;

public sealed class DvaIdentifier : Identifier
{
  private Australian.IDVANumber _identifier;
  private readonly Australian.IDVANumberGenerator _generator;
  private readonly Australian.DVANumberParser _parser;
  
  public DvaIdentifier() 
    : base(
      IdentifierType.Hpii, 
      "DVA Number", 
      "Department Of Veterans Affairs",
      @"/Images/unique-identifier.png")
  {
    _identifier = new Australian.DVANumber();
    _generator = new Australian.DVANumberGenerator();
    _parser = new Australian.DVANumberParser();
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
    _identifier = new Australian.DVANumber();
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
    ComponentList.Add(new IdentifierComponent(name: nameof(_identifier.StateCode), _identifier.StateCode ?? String.Empty));
    ComponentList.Add(new IdentifierComponent(name: nameof(_identifier.WarCode), _identifier.WarCode ?? String.Empty));
    ComponentList.Add(new IdentifierComponent(name: nameof(_identifier.Number), _identifier.Number ?? String.Empty));
    ComponentList.Add(new IdentifierComponent(name: nameof(_identifier.SegmentLink), _identifier.SegmentLink ?? String.Empty));
  }
}
