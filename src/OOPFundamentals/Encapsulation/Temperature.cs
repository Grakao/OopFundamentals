using System.Globalization;

namespace Encapsulation;

public class Temperature
{
    #region Properties
    public double Celsius { get; private set; } // Celsius can only have its value assigned via the class it belongs to via private set.
    #endregion

    #region Methods
    // Only the methods below are allowed to change the value of Celsius. They also encapsulate the conversions formulae.
    public void ConvertFromFahrenheit(double fahrenheit)
    {
        Celsius = (fahrenheit - 32) * 5.0 / 9.0;
    }

    public void ConvertFromKelvin(double kelvin)
    {
        if (kelvin < 0)
            throw new Exception("Kelvin must be a non-negative value. Try again.");

        Celsius = kelvin - 273.15;
    }
    #endregion
}