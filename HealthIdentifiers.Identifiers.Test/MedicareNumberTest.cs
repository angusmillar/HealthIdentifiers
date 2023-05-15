using HealthIdentifiers.Identifiers.Australian.MedicareNumber;

namespace HealthIdentifiers.Identifiers.Test;

public class MedicareNumberTest
{
    [Fact]
    public void Test_ValidMedicareNumberWithIrn()
    {
        const string medicareNumber = "6140523093";
        const string irn = "1";

        IMedicareNumberParser parser = new MedicareNumberParser();
        Assert.True(parser.TryParse(medicareNumber + irn, out var medNum));
        Assert.Equal(medicareNumber, medNum.Value);
        Assert.Equal(irn, medNum.IRN);
        Assert.Equal("9", medNum.Checksum);
        Assert.Equal("3", medNum.IssueNumber);
    }

    [Fact]
    public void Test_ValidMedicareNumberZeroIssueNumber()
    {
        const string medicareNumber = "2273766560";
        const string irn = "3";

        IMedicareNumberParser parser = new MedicareNumberParser();
        Assert.False(parser.TryParse(medicareNumber + irn, out _));
    }

    [Fact]
    public void Test_ValidMedicareNumberNoIrn()
    {
        const string medicareNumber = "6140523093";
        IMedicareNumberParser parser = new MedicareNumberParser();
        Assert.True(parser.TryParse(medicareNumber, out var medNum));
        Assert.Equal(medicareNumber, medNum.Value);
        Assert.Equal(string.Empty, medNum.IRN);
        Assert.Equal("9", medNum.Checksum);
        Assert.Equal("3", medNum.IssueNumber);
    }

    [Fact]
    public void Test_NonValidMedicareNumber()
    {
        const string medicareNumber = "614dsf4393";
        IMedicareNumberParser parser = new MedicareNumberParser();
        Assert.False(parser.TryParse(medicareNumber, out _));
    }

    [Fact]
    public void Test_MedicareNumberGenerationWithNoIRNStaticMethod()
    {
        IMedicareMedicareNumberGenerator medicareMedicareNumberGenerator = new MedicareMedicareNumberGenerator();

        for (var i = 0; i < 100000; i++)
        {
            string medicareNumberNoIrn = medicareMedicareNumberGenerator.Generate(false);
            IMedicareNumberParser parser = new MedicareNumberParser();
            Assert.True(parser.TryParse(medicareNumberNoIrn, out _));
        }
    }

    [Fact]
    public void Test_MedicareNumberGenerationWithIRNStaticMethod()
    {
        MedicareMedicareNumberGenerator medicareMedicareNumberGenerator = new MedicareMedicareNumberGenerator();
        for (var i = 0; i < 100000; i++)
        {
            string medicareNumberNoIrn = medicareMedicareNumberGenerator.Generate(true);
            IMedicareNumberParser parser = new MedicareNumberParser();
            Assert.True(parser.TryParse(medicareNumberNoIrn, out _));
        }
    }
}