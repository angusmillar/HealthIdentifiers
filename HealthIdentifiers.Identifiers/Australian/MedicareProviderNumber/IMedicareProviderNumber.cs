namespace HealthIdentifiers.Identifiers.Australian.MedicareProviderNumber
{
  public interface IMedicareProviderNumber
  {
    string CheckCharacter { get; }
    string LocationCharacter { get; }
    string Stem { get; }
    string Value { get; }
    string ValueDisplay { get; }
    bool IsValid();
  }
}