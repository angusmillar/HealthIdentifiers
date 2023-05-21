using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealthIdentifiers.Identifiers.Australian.NationalHealthcareIdentifier
{  
  public abstract class NationalHealthcareIdentifierParser
  {

    /// <summary>
    /// Australian Healthcare Identifier Types (IHI, HPI-I, HPI-O)
    /// </summary>
    internal enum NationalHealthcareIdentifierType
    {
      /// <summary>
      /// Individual Healthcare Identifier (IHI)
      /// </summary>
      Individual,
      /// <summary>
      /// Healthcare Provider Identifier-Individual (HPI-I)
      /// </summary>
      Provider,
      /// <summary>
      /// Healthcare Provider Identifier-Orginisation (HPI-O)
      /// </summary>
      Orginisation,

    }

    internal static readonly string _ValidIndustryCode = "80";
    internal static readonly string _ValidCountryCode = "036";
    internal static readonly string _IhiIssueNumber = "0";
    internal static readonly string _HpiiIssueNumber = "1";
    internal static readonly string _HpioIssueNumber = "2";

    internal bool BaseTryParse(string NationalHealthcareIdentifierString, NationalHealthcareIdentifierType IdentifierType, out INationalHealthcareIdentifierBase NationalHealthcareIdentifierBase)
    {
      NationalHealthcareIdentifierBase = null;
      NationalHealthcareIdentifierBase Id = null;
      switch (IdentifierType)
      {
        case NationalHealthcareIdentifierType.Individual:
          Id = new IndividualHealthcareIdentifier();
          break;
        case NationalHealthcareIdentifierType.Provider:
          Id = new HealthcareProviderIdentifierIndividual();
          break;
        case NationalHealthcareIdentifierType.Orginisation:
          Id = new HealthcareProviderIdentifierOrganisation();
          break;
        default:
          break;
      }

      NationalHealthcareIdentifierString = Identifiers.Support.StringSupport.RemoveWhitespace(NationalHealthcareIdentifierString.Trim());

      if (NationalHealthcareIdentifierString.Length != 16)
      {
        return false;
      }

      Id.Value = NationalHealthcareIdentifierString;
      
      switch (IdentifierType)
      {

        case NationalHealthcareIdentifierType.Individual:
          if (!NationalHealthcareIdentifierString.Substring(5, 1).Equals(NationalHealthcareIdentifierParser._IhiIssueNumber))
            return false;
          break;
        case NationalHealthcareIdentifierType.Provider:
          if (!NationalHealthcareIdentifierString.Substring(5, 1).Equals((NationalHealthcareIdentifierParser._HpiiIssueNumber)))
            return false;
          break;
        case NationalHealthcareIdentifierType.Orginisation:
          if (!NationalHealthcareIdentifierString.Substring(5, 1).Equals(NationalHealthcareIdentifierParser._HpioIssueNumber))
            return false;
          break;
        default:
          throw new ArgumentOutOfRangeException(nameof(IdentifierType), IdentifierType, null);
      }
      
      Id.NumberIssuerCode = NationalHealthcareIdentifierString.Substring(5, 1);

      Id.IndustryCode = NationalHealthcareIdentifierString.Substring(0, 2);
      if (Id.IndustryCode != _ValidIndustryCode)
      {
        return false;
      }
      
      Id.CountryCode = NationalHealthcareIdentifierString.Substring(2, 3);
      if (Id.CountryCode != _ValidCountryCode)
      {
        return false;
      }

      Id.UniqueReference = NationalHealthcareIdentifierString.Substring(6, 9);

      Id.CheckDigit = NationalHealthcareIdentifierString.Substring(15, 1);
      if (Id.CheckDigit != CheckDigitAlgorithm.Luhn.GetCheckDigit(Id.Value.Substring(0, Id.Value.Length - 1)))
      {
        return false;
      }

      Id.ValueDisplay = $"{Id.Value.Substring(0, 4)} {Id.Value.Substring(4 , 4)} {Id.Value.Substring(8, 4)} {Id.Value.Substring(12, 4)}";
      
      NationalHealthcareIdentifierBase = Id;
      return true;
    }
  }
}
