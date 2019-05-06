﻿namespace HealthIdentifiers.Identifiers.Australian.NationalHealthcareIdentifier
{
  public interface IHealthcareProviderIdentifierOrganisationParser
  {
    bool TryParse(string HealthcareProviderIdentifierOrganisationString, out IHealthcareProviderIdentifierOrganisation HealthcareProviderIdentifierOrganisation);
  }
}