using System.Globalization;

namespace Encapsulation;

class Program
{
    static void Main(string[] args)
    {
        int conversionCount = 0;
        bool running = true;

        while (running)
        {
            int input;

            while (true)
            {
                Console.WriteLine("==================================");
                Console.WriteLine("      Temperature Converter       ");
                Console.WriteLine("==================================");
                Console.WriteLine("  [1] Convert Fahrenheit to Celsius");
                Console.WriteLine("  [2] Convert Kelvin to Celsius");
                Console.WriteLine("  [3] Exit");
                Console.WriteLine("----------------------------------");
                Console.WriteLine("Choose a conversion option:");

                if (int.TryParse(Console.ReadLine(), out input) && input is 1 or 2 or 3)
                {
                    break;
                }

                Console.WriteLine("Invalid option.");
            }

            if (input == 3)
            {
                running = false;
                continue;
            }

            var temperature = new Temperature();

            if (input == 1)
            {
                Console.WriteLine("Type in the Fahrenheit value to convert:");
                double fahrenheit = ReadValidTemperature();

                temperature.ConvertFromFahrenheit(fahrenheit);

                Console.WriteLine(
                    $"The value in Celsius is {temperature.Celsius.ToString("F1", CultureInfo.InvariantCulture)} ºC");
                
                conversionCount++;
            }

            if (input == 2)
            {
                try
                {
                    Console.WriteLine("Type in the Kelvin value to convert:");
                    double kelvin = ReadValidTemperature();

                    temperature.ConvertFromKelvin(kelvin);

                    Console.WriteLine(
                        $"The value in Celsius is {temperature.Celsius.ToString("F1", CultureInfo.InvariantCulture)} ºC");
                    
                    conversionCount++;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        Console.WriteLine($"Total successful conversions: {conversionCount}");
    }

    static double ReadValidTemperature()
    {
        while (true)
        {
            if (double.TryParse(Console.ReadLine(), out double value))
            {
                return value;
            }

            Console.WriteLine("Invalid input. Please enter a valid numeric value:");
        }
    }
}
