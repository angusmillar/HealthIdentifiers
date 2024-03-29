﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealthIdentifiers.Identifiers.Australian.MedicareProviderNumber
{
  public class MedicareProviderNumber : IMedicareProviderNumber
  {
    public string CheckCharacter { get; internal set; }

    public string LocationCharacter { get; internal set; }

    public string Stem { get; internal set; }

    public string Value { get; internal set; }
    
    public string ValueDisplay { get; internal set;  }

    public bool IsValid()
    {
      throw new NotImplementedException();
    }
  }
}
