using HealthIdentifiers.Identifiers.Australian.DepartmentVeteransAffairs;

namespace HealthIdentifier.Identifiers.Test;

public class DvaNumberTest
{
    [Fact]
    public void Test_Valid_DVA_Number_1()
    {
      string number = "N ABC1234C";
     
      IDVANumberParser parser = new DVANumberParser();
      Assert.True(parser.TryParse(number, out var dva));
      Assert.Equal("NABC1234C", dva.Value);
      Assert.Equal("N", dva.StateCode);
      Assert.Equal("ABC", dva.WarCode);
      Assert.Equal("1234", dva.Number);
      Assert.Equal("C", dva.SegmentLink);
      Assert.Equal("ABC1234", dva.FileNumber);
    }

    [Fact]
    public void Test_Valid_DVA_Number_2()
    {
      string number = "V A123456";
    
      IDVANumberParser parser = new DVANumberParser();
      Assert.True(parser.TryParse(number, out var dva));
      Assert.Equal("VA123456", dva.Value);
      Assert.Equal("V", dva.StateCode);
      Assert.Equal("A", dva.WarCode);
      Assert.Equal("123456", dva.Number);
      Assert.Equal("", dva.SegmentLink);
      Assert.Equal("A123456", dva.FileNumber);
    }
    
    [Fact]
    public void Test_Valid_DVA_Number_3()
    {
      string number = "Q ZX12345Z";
    
      IDVANumberParser parser = new DVANumberParser();
      Assert.True(parser.TryParse(number, out var dva));
      Assert.Equal("QZX12345Z", dva.Value);
      Assert.Equal("Q", dva.StateCode);
      Assert.Equal("ZX", dva.WarCode);
      Assert.Equal("12345", dva.Number);
      Assert.Equal("Z", dva.SegmentLink);
      Assert.Equal("ZX12345", dva.FileNumber);
    }
    
    [Fact]
    public void Test_Negative_DVA_Number_BadStateCode()
    {
      string number = "Z ZX12345Z";
    
      IDVANumberParser parser = new DVANumberParser();
      
      Assert.False(parser.TryParse(number, out var dva));      
    }
    
    [Fact]
    public void Test_Negative_DVA_Number_ToManyNumber()
    {
      string number = "N ZX123456Z";
    
      IDVANumberParser parser = new DVANumberParser();
      Assert.False(parser.TryParse(number, out var dva));
    }
    
    [Fact]
    public void Test_Negative_DVA_SegmentLinkNotAnAlpha()
    {
      string number = "N ZX123458";
    
      IDVANumberParser parser = new DVANumberParser();
      Assert.False(parser.TryParse(number, out var dva));
    }
    
    [Fact]
    public void Test_Negative_DVA_AlphaAfterWarCode()
    {
      string number = "N Z123S56A";
    
      IDVANumberParser parser = new DVANumberParser();
      Assert.False(parser.TryParse(number, out var dva));
    }
}