using System;

namespace HealthIdentifiers.Identifiers.Australian.MedicareNumber
{
  public interface IMedicareNumber
  {
    string Checksum { get; }
    DateTime? ExpiryDate { get; set; }
    string Identifer { get; }
    string IRN { get; }
    string IssueNumber { get; }
    string Value { get; }
    string ValueDisplay { get; }
  }
}