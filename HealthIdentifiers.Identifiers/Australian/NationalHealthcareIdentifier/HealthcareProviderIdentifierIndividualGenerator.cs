﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealthIdentifiers.Identifiers.Australian.NationalHealthcareIdentifier
{
  public class HealthcareProviderIdentifierIndividualGenerator : IHealthcareProviderIdentifierIndividualGenerator
  {
    public string Generate()
    {
      return NationalHealthcareIdentifierGenerator.GenerateRandomHealthcareIdentifier(NationalHealthcareIdentifierParser.NationalHealthcareIdentifierType.Provider);
    }
  }
}
