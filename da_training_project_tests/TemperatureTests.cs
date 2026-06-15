using Encapsulation;

namespace EncapsulationTests;

public class TemperatureTests
{
    [Fact]
    public void ConvertFromFahrenheit_BoilingPoint_Returns100()
    {
        var temp = new Temperature();
        temp.ConvertFromFahrenheit(212);
        Assert.Equal(100.0, temp.Celsius, 1);
    }

    [Fact]
    public void ConvertFromFahrenheit_FreezingPoint_Returns0()
    {
        var temp = new Temperature();
        temp.ConvertFromFahrenheit(32);
        Assert.Equal(0.0, temp.Celsius, 1);
    }

    [Fact]
    public void ConvertFromFahrenheit_NegativeValue_ReturnsCorrectCelsius()
    {
        var temp = new Temperature();
        temp.ConvertFromFahrenheit(-40);
        Assert.Equal(-40.0, temp.Celsius, 1);
    }

    [Fact]
    public void ConvertFromKelvin_AbsoluteZero_Returns_Minus273Point15()
    {
        var temp = new Temperature();
        temp.ConvertFromKelvin(0);
        Assert.Equal(-273.15, temp.Celsius, 2);
    }

    [Fact]
    public void ConvertFromKelvin_BoilingPoint_Returns100()
    {
        var temp = new Temperature();
        temp.ConvertFromKelvin(373.15);
        Assert.Equal(100.0, temp.Celsius, 1);
    }

    [Fact]
    public void ConvertFromKelvin_NegativeValue_ThrowsException()
    {
        var temp = new Temperature();
        var ex = Assert.Throws<Exception>(() => temp.ConvertFromKelvin(-1));
        Assert.Contains("non-negative", ex.Message);
    }

    [Fact]
    public void ConvertFromKelvin_NegativeLargeValue_ThrowsException()
    {
        var temp = new Temperature();
        Assert.Throws<Exception>(() => temp.ConvertFromKelvin(-100));
    }

    [Fact]
    public void Celsius_PrivateSet_CannotBeSetDirectly()
    {
        var prop = typeof(Temperature).GetProperty("Celsius");
        Assert.NotNull(prop);
        Assert.NotNull(prop!.GetMethod);
        Assert.True(prop.GetMethod!.IsPublic);
        var setMethod = prop.SetMethod;
        Assert.NotNull(setMethod);
        Assert.True(setMethod!.IsPrivate);
    }
}
