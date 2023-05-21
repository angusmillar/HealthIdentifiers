namespace HealthIdentifiers.Identifiers.Australian.DepartmentVeteransAffairs
{
  public interface IDVANumber
  {
    string FileNumber { get; } 
    string Number { get; }
    string SegmentLink { get; }
    string StateCode { get; }
    string Value { get; }
    public string ValueDisplay { get; }
    string WarCode { get; }
    string CardColor { get; set; }
  }
}