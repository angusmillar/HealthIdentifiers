namespace HealthIdentifiers.Identifiers.Australian.DepartmentVeteransAffairs
{
  public interface IDVANumberParser
  {
    bool TryParse(string DVANumberString, out IDVANumber DVANumber);
  }
}