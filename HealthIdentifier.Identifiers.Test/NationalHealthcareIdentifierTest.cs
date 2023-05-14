using HealthIdentifiers.Identifiers.Australian.NationalHealthcareIdentifier;
using HealthIdentifiers.Identifiers.Support.StandardsInformation.Australian;

namespace HealthIdentifier.Identifiers.Test;

public class NationalHealthcareIdentifierTest
{
    [Fact]
    public void Test_IHI_IsValid_True()
    {
        const string value = "8003608333428779";
        IIndividualHealthcareIdentifierParser parser = new IndividualHealthcareIdentifierParser();
        Assert.True(parser.TryParse(value, out var ihi));
        Assert.Equal("80", ihi.IndustryCode);
        Assert.Equal("036", ihi.CountryCode);
        Assert.Equal("0", ihi.NumberIssuerCode);
        Assert.Equal("833342877", ihi.UniqueReference);
        Assert.Equal("9", ihi.CheckDigit);
        Assert.Equal(value, ihi.Value);
    }

    [Fact]
    public void Test_HPI_I_IsValid_True()
    {
        const string value = "8003610001218573";
        IHealthcareProviderIdentifierIndividualParser parser = new HealthcareProviderIdentifierIndividualParser();
        Assert.True(parser.TryParse(value, out var hpii));
        Assert.Equal("80", hpii.IndustryCode);
        Assert.Equal("036", hpii.CountryCode);
        Assert.Equal("1", hpii.NumberIssuerCode);
        Assert.Equal("000121857", hpii.UniqueReference);
        Assert.Equal("3", hpii.CheckDigit);
        Assert.Equal(value, hpii.Value);
    }


    [Fact]
    public void Test_HPI_I_IsValid_CheckDigit_Fasle()
    {
        const string value = "8003610001218577";
        IHealthcareProviderIdentifierIndividualParser parser = new HealthcareProviderIdentifierIndividualParser();
        Assert.False(parser.TryParse(value, out _));
    }

    [Fact]
    public void Test_IHI_IsValid_False()
    {
        //037 should be 036 
        const string value = "8003708333428779";
        IIndividualHealthcareIdentifierParser parser = new IndividualHealthcareIdentifierParser();
        Assert.False(parser.TryParse(value, out _));
    }


    [Fact]
    public void Test_IHI_HealthcareIdentifierType_IsHPI_O_True()
    {
        const string value = "8003626499446203";
        IHealthcareProviderIdentifierOrganisationParser parser = new HealthcareProviderIdentifierOrganisationParser();
        Assert.True(parser.TryParse(value, out var hpio));
        Assert.Equal("80", hpio.IndustryCode);
        Assert.Equal("036", hpio.CountryCode);
        Assert.Equal("2", hpio.NumberIssuerCode);
        Assert.Equal("649944620", hpio.UniqueReference);
        Assert.Equal("3", hpio.CheckDigit);
        Assert.Equal(value, hpio.Value);
    }


    [Fact]
    public void Test_GenerateRandomIHI()
    {
        IIndividualHealthcareIdentifierGenerator generator = new IndividualHealthcareIdentifierGenerator();
        string newRandom = generator.Generate();
        IIndividualHealthcareIdentifierParser parser = new IndividualHealthcareIdentifierParser();
        Assert.True(parser.TryParse(newRandom, out _));
    }

    [Fact]
    public void Test_GenerateRandomHPI_I()
    {
        IHealthcareProviderIdentifierIndividualGenerator generator = new HealthcareProviderIdentifierIndividualGenerator();
        string newRandom = generator.Generate();
        IHealthcareProviderIdentifierIndividualParser parser = new HealthcareProviderIdentifierIndividualParser();
        Assert.True(parser.TryParse(newRandom, out _));
    }

    [Fact]
    public void Test_GenerateRandomHPI_O()
    {
        IHealthcareProviderIdentifierOrganisationGenerator generator = new HealthcareProviderIdentifierOrganisationGenerator();
        string newRandom = generator.Generate();
        IHealthcareProviderIdentifierOrganisationParser parser = new HealthcareProviderIdentifierOrganisationParser();
        Assert.True(parser.TryParse(newRandom, out _));
    }

    [Fact]
    public void Test_ValueWithRootOID_ReturnsCorrect()
    {
        NationalHealthcareIdentifierInfo info = new NationalHealthcareIdentifierInfo();
        const string rootOid = "1.2.36.1.2001.1003.0";
        Assert.Equal(rootOid, info.RootHealthcareIdentifierOid);
    }
}