namespace Abstraction;

public class CoffeeMachine
{
    public void MakeEspresso()
    {
        GrindBeans();
        HeatWater();
        BrewCoffee();

        Console.WriteLine("Espresso is ready.");
    }

    public void MakeLatte()
    {
        GrindBeans();
        HeatWater();
        BrewCoffee();
        SteamMilk();

        Console.WriteLine("Latte is ready.");
    }

    private void GrindBeans()
    {
        Console.WriteLine("Grinding beans...");
    }

    private void HeatWater()
    {
        Console.WriteLine("Heating water...");
    }

    private void BrewCoffee()
    {
        Console.WriteLine("Brewing coffee...");
    }

    private void SteamMilk()
    {
        Console.WriteLine("Steaming milk...");
    }
}