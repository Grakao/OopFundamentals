using System.Globalization;

namespace Encapsulation;

class Program
{
    static void Main(string[] args)
    {
        int input;

        while (true)
        {
            Console.WriteLine("==================================");
            Console.WriteLine("      Temperature Converter       ");
            Console.WriteLine("==================================");
            Console.WriteLine("  [1] Convert Fahrenheit to Celsius");
            Console.WriteLine("  [2] Convert Kelvin to Celsius");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Choose a conversion option:");

            if (int.TryParse(Console.ReadLine(), out input) && input is 1 or 2)
            {
                break;
            }

            Console.WriteLine("Invalid option.");
        }

        var temperature = new Temperature();

        if (input == 1)
        {
            Console.WriteLine("Type in the Fahrenheit value to convert:");
            double fahrenheit = Convert.ToDouble(Console.ReadLine());

            temperature.ConvertFromFahrenheit(fahrenheit); // Conversion details are encapsulated

            Console.WriteLine(
                $"The value in Celsius is {temperature.Celsius.ToString("F1", CultureInfo.InvariantCulture)} ºC");
        }

        if (input == 2)
        {
            try
            {
                Console.WriteLine("Type in the Kelvin value to convert:");
                double kelvin = Convert.ToDouble(Console.ReadLine());

                temperature.ConvertFromKelvin(kelvin); // Conversion details are encapsulated

                Console.WriteLine(
                    $"The value in Celsius is {temperature.Celsius.ToString("F1", CultureInfo.InvariantCulture)} ºC");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
