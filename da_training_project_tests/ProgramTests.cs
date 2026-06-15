using System.Globalization;
using System.Reflection;

namespace EncapsulationTests;

public class ProgramTests
{
    private static (string output, int exitCode) RunApp(string input)
    {
        var originalIn = Console.In;
        var originalOut = Console.Out;

        try
        {
            var reader = new StringReader(input);
            var writer = new StringWriter();
            Console.SetIn(reader);
            Console.SetOut(writer);

            var programType = typeof(Encapsulation.Temperature).Assembly
                .GetType("Encapsulation.Program");
            Assert.NotNull(programType);

            var mainMethod = programType!.GetMethod("Main",
                BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
            Assert.NotNull(mainMethod);

            mainMethod!.Invoke(null, new object[] { Array.Empty<string>() });

            return (writer.ToString(), 0);
        }
        finally
        {
            Console.SetIn(originalIn);
            Console.SetOut(originalOut);
        }
    }

    [Fact]
    public void Menu_DisplaysExitOption()
    {
        var (output, _) = RunApp("3\n");
        Assert.Contains("Exit", output, StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public void Menu_ExitOption_TerminatesGracefully()
    {
        var (output, _) = RunApp("3\n");
        Assert.Contains("conversion", output, StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public void FahrenheitConversion_ThenExit_ShowsResult()
    {
        var (output, _) = RunApp("1\n212\n3\n");
        Assert.Contains("100.0", output);
    }

    [Fact]
    public void KelvinConversion_ThenExit_ShowsResult()
    {
        var (output, _) = RunApp("2\n373\n3\n");
        Assert.Contains("99.9", output);
    }

    [Fact]
    public void MultipleConversions_ThenExit_ReturnsToMenu()
    {
        var (output, _) = RunApp("1\n32\n2\n373\n3\n");
        Assert.Contains("0.0", output);
        Assert.Contains("99.9", output);
    }

    [Fact]
    public void ExitAfterConversions_DisplaysConversionCount()
    {
        var (output, _) = RunApp("1\n212\n2\n373\n3\n");
        Assert.Contains("2", output);
    }

    [Fact]
    public void ExitWithNoConversions_DisplaysZeroCount()
    {
        var (output, _) = RunApp("3\n");
        Assert.Contains("0", output);
    }

    [Fact]
    public void InvalidMenuSelection_PromptsAgain()
    {
        var (output, _) = RunApp("9\n3\n");
        Assert.Contains("Invalid", output, StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public void InvalidMenuSelection_NonNumeric_PromptsAgain()
    {
        var (output, _) = RunApp("abc\n3\n");
        Assert.Contains("Invalid", output, StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public void InvalidTemperatureInput_Fahrenheit_PromptsAgain()
    {
        var (output, _) = RunApp("1\nabc\n100\n3\n");
        Assert.Contains("37.8", output);
    }

    [Fact]
    public void InvalidTemperatureInput_Kelvin_PromptsAgain()
    {
        var (output, _) = RunApp("2\nabc\n300\n3\n");
        Assert.Contains("26.9", output);
    }

    [Fact]
    public void NegativeKelvin_RejectsAndPrompts()
    {
        var (output, _) = RunApp("2\n-5\n300\n3\n");
        Assert.Contains("non-negative", output, StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public void ConversionResult_DisplayedWithOneDecimalPlace()
    {
        var (output, _) = RunApp("1\n100\n3\n");
        Assert.Contains("37.8", output);
    }

    [Fact]
    public void ProgramCs_DoesNotContainConversionFormulas()
    {
        var assembly = typeof(Encapsulation.Temperature).Assembly;
        var programType = assembly.GetType("Encapsulation.Program");
        Assert.NotNull(programType);

        var sourceDir = FindSourceDirectory();
        if (sourceDir == null)
        {
            return;
        }

        var programFile = Path.Combine(sourceDir, "Program.cs");
        if (!File.Exists(programFile))
        {
            return;
        }

        var content = File.ReadAllText(programFile);
        Assert.DoesNotContain("* 5.0 / 9.0", content);
        Assert.DoesNotContain("* 9.0 / 5.0", content);
        Assert.DoesNotContain("- 273.15", content);
        Assert.DoesNotContain("+ 273.15", content);
        Assert.DoesNotContain("(5.0/9.0)", content);
        Assert.DoesNotContain("(9.0/5.0)", content);
    }

    [Fact]
    public void Temperature_ConversionFormulas_AreEncapsulated()
    {
        var tempType = typeof(Encapsulation.Temperature);
        var methods = tempType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
        var conversionMethods = methods.Where(m =>
            m.Name.Contains("Convert", StringComparison.OrdinalIgnoreCase)).ToList();
        Assert.True(conversionMethods.Count >= 2,
            "Temperature class should have at least 2 conversion methods");
    }

    [Fact]
    public void SingleConversion_ThenExit_DisplaysCountOfOne()
    {
        var (output, _) = RunApp("1\n100\n3\n");
        Assert.Contains("1", output);
    }

    [Fact]
    public void Menu_ShowsFahrenheitOption()
    {
        var (output, _) = RunApp("3\n");
        Assert.Contains("Fahrenheit", output);
    }

    [Fact]
    public void Menu_ShowsKelvinOption()
    {
        var (output, _) = RunApp("3\n");
        Assert.Contains("Kelvin", output);
    }

    [Fact]
    public void ThreeConversions_ThenExit_ShowsCountOfThree()
    {
        var (output, _) = RunApp("1\n212\n1\n32\n2\n273\n3\n");
        Assert.Contains("3", output);
    }

    [Fact]
    public void NegativeKelvin_DoesNotCountAsSuccessfulConversion()
    {
        var (output, _) = RunApp("2\n-10\n2\n300\n3\n");
        Assert.Contains("1", output);
    }

    [Fact]
    public void ReadValidTemperature_SharedMethod_ExistsByReflection()
    {
        var programType = typeof(Encapsulation.Temperature).Assembly
            .GetType("Encapsulation.Program");
        Assert.NotNull(programType);

        var methods = programType!.GetMethods(
            BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public |
            BindingFlags.Instance);

        var readMethods = methods.Where(m =>
            m.ReturnType == typeof(double) &&
            m.GetParameters().Length <= 2 &&
            !m.Name.Equals("Main", StringComparison.OrdinalIgnoreCase)
        ).ToList();

        Assert.True(readMethods.Count >= 1,
            "Program should have a reusable method for reading valid numeric temperature input");
    }

    private static string? FindSourceDirectory()
    {
        var dir = AppContext.BaseDirectory;
        for (int i = 0; i < 10; i++)
        {
            var candidate = Path.Combine(dir, "src", "OOPFundamentals", "Encapsulation");
            if (Directory.Exists(candidate))
                return candidate;
            var parent = Directory.GetParent(dir);
            if (parent == null) break;
            dir = parent.FullName;
        }
        return null;
    }
}
