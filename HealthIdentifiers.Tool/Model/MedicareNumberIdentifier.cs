using HealthIdentifiers.Tool.Enums;
using Australian = HealthIdentifiers.Identifiers.Australian.MedicareNumber;
namespace HealthIdentifiers.Tool.Model;

public class MedicareNumberIdentifier : Identifier
{
    private Australian.IMedicareNumber _MedicareNumber;
    private readonly Australian.IMedicareMedicareNumberGenerator _MedicareMedicareNumberGenerator;
    public MedicareNumberIdentifier() 
        : base(IdentifierType.MedicareNumber, "Medicare Number")
    {
        _MedicareMedicareNumberGenerator = new Australian.MedicareMedicareNumberGenerator();
        _MedicareNumber = new Australian.MedicareNumber();
        SetMedicareNumberComponents();
    }

    public override bool IsValid()
    {
        Australian.IMedicareNumberParser parser = new Australian.MedicareNumberParser();
        if (parser.TryParse(Value, out Australian.IMedicareNumber medicareNumber))
        {
            _MedicareNumber = medicareNumber;
            SetMedicareNumberComponents();
            return true;
        }
        _MedicareNumber = new Australian.MedicareNumber();
        SetMedicareNumberComponents();
        return false;
    }

    public override string GenerateRandomIdentifier()
    {
        return _MedicareMedicareNumberGenerator.Generate(true);
    }

    private void SetMedicareNumberComponents()
    {
        ComponentList.Clear();
        ComponentList.Add(new IdentifierComponent(name: nameof(_MedicareNumber.Identifer), _MedicareNumber.Identifer));
        ComponentList.Add(new IdentifierComponent(name: nameof(_MedicareNumber.IssueNumber), _MedicareNumber.IssueNumber));
        ComponentList.Add(new IdentifierComponent(name: nameof(_MedicareNumber.Checksum), _MedicareNumber.Checksum));
        ComponentList.Add(new IdentifierComponent(name: nameof(_MedicareNumber.IRN), _MedicareNumber.IRN));
    }
}