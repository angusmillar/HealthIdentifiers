using HealthIdentifiers.Identifiers.Australian.MedicareNumber;
using HealthIdentifiers.Identifiers.Australian.MedicareProviderNumber;

namespace HealthIdentifier.Identifiers.Test;

public class MedicareProviderNumberTest
{
    [Fact]
    public void Test_ValidMedicareProviderNumber()
    {
        const string number = "2940675Y";
        IMedicareProviderNumberParser parser = new MedicareProviderNumberParser();
        Assert.True(parser.TryParse(number, out var medicareProviderNumber));
        Assert.Equal(number, medicareProviderNumber.Value);
        Assert.Equal("294067", medicareProviderNumber.Stem);
        Assert.Equal("5", medicareProviderNumber.LocationCharacter);
        Assert.Equal("Y", medicareProviderNumber.CheckCharacter);        
    }

    [Fact]
    public void Test_InValidMedicareProviderNumber()
    {
        const string number = "2940975Y";
        IMedicareProviderNumberParser parser = new MedicareProviderNumberParser();
        Assert.False(parser.TryParse(number, out _));
    }

    [Fact]
    public void Test_MedicareProviderNumberGeneration()
    {
        IMedicareProviderNumberGenerator medicareProviderNumberGenerator = new MedicareProviderNumberGenerator();
        IMedicareProviderNumberParser parser = new MedicareProviderNumberParser();
      
        for (int i = 0; i < 100000; i++)
        {
            Assert.True(parser.TryParse(medicareProviderNumberGenerator.Generate(), out _));
        }
    }
}