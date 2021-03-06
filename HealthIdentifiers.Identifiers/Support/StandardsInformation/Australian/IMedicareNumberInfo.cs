﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HealthIdentifiers.Identifiers.Support.StandardsInformation.Australian
{
  public interface IMedicareNumberInfo
  {
    string FhirSystemUri { get; }
    string HL7V2AssigningAuthority { get; }
    string HL7V2IdentifierTypeCode { get; }
  }
}
