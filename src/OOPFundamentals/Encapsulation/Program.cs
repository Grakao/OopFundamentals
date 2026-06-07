namespace Encapsulation;

class Program
{
    static void Main(string[] args)
    {
        int input;

        while (true)
        {
            Console.WriteLine("[1] - Convert From Fahrenheit");
            Console.WriteLine("[2] - Convert From Kelvin");
            Console.WriteLine("-----------------------------");
            Console.WriteLine("Type the desired conversion:");

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
            int fahrenheit = Convert.ToInt32(Console.ReadLine());

            temperature.ConvertFromFahrenheit(fahrenheit); // Conversion details are encapsulated

            Console.WriteLine($"The value in Celsius is {temperature.Celsius:F1} ºC");
        }

        if (input == 2)
        {
            try
            {
                Console.WriteLine("Type in the Kelvin value to convert:");
                int kelvin = Convert.ToInt32(Console.ReadLine());

                temperature.ConvertFromKelvin(kelvin); // Conversion details are encapsulated

                Console.WriteLine($"The value in Celsius is {temperature.Celsius:F1} ºC");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}