using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealthIdentifiers.Identifiers.CheckDigitAlgorithm
{
  public class Luhn
  {
    public static string GetCheckDigit(string NationalIdentifer)
    {
      if (!Support.StringSupport.IsDigitsOnly(NationalIdentifer))
      {
        throw new FormatException("Luhn Algorithm can only be performed on numerical digits.");
      }

      int counter = 1;
      int value = 0;

      while(counter <= NationalIdentifer.Length)
      {
        string substring = NationalIdentifer.Substring(counter - 1, 1);
        int digit = int.Parse(substring);

        if (counter % 2 == 0)
        {
          //even
          value = value + digit;
        }
        else
        {
          //odd
          value = value + ((digit * 2) / 10 + (digit * 2) % 10);
        }
        counter++;
      }

      value = (10 - (value % 10)) % 10;

      if (value < 0)
      {
        value = value * -1;
      }

      return value.ToString();
    }    
  }
}
