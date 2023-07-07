using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Services;
using SampleHierarchies.Data;
using Newtonsoft.Json.Linq;
using SampleHierarchies.Services;
using System.ComponentModel;
using System.Runtime.Intrinsics.X86;

namespace SampleHierarchies.Gui;

/// <summary>
/// Application main screen.
/// </summary>
public sealed class MainScreen : Screen
{
    #region Properties And Ctor

    /// <summary>
    /// Data service,
    /// Settings service.
    /// </summary>
    private readonly IDataService _dataService;
    private readonly ISettingsService _settingsService;
    
    /// <summary>
    /// Animals screen.
    /// </summary>
    private readonly AnimalsScreen _animalsScreen;

    /// <summary>
    /// Ctor
    /// </summary>
    /// <param name="dataService"></param>
    /// <param name="animalsScreen"></param>
    /// <param name="settingsService"></param>
    public MainScreen(
        IDataService dataService,
        AnimalsScreen animalsScreen,
        ISettingsService settingsService)
    {
        _dataService = dataService;
        _animalsScreen = animalsScreen;
        _settingsService = settingsService;
    }

    #endregion Properties And Ctor

    #region Public Methods

    public override void Show()
    {
        while (true)
        {
            InitialisingColor();

            Console.WriteLine();
            Console.WriteLine("Your available choices are:");
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. Animals");
            Console.WriteLine("2. Create a new settings");
            Console.Write("Please enter your choice: ");

            string? choiceAsString = Console.ReadLine();

            // Validate choice
            try
            {
                if (choiceAsString is null)
                {
                    throw new ArgumentNullException(nameof(choiceAsString));
                }

                MainScreenChoices choice = (MainScreenChoices)Int32.Parse(choiceAsString);
                switch (choice)
                {
                    case MainScreenChoices.Animals:
                        _animalsScreen.Show();
                        break;

                    case MainScreenChoices.Settings:
                        if (SettingsService.FilePath is not null) { ModifyJsonColorFile(SettingsService.FilePath); }
                        else { Console.WriteLine("Your JSON file path is incorrect"); }
                        break;

                    case MainScreenChoices.Exit:
                        Console.WriteLine("Goodbye.");
                        return;
                }
            }
            catch
            {
                Console.WriteLine("Invalid choice. Try again.");
            }
        }
    }

    #endregion // Public Methods

    #region Private Methods

    /// <summary>
    /// Method which initialise color of "MainScreen" screen
    /// </summary>
    private void InitialisingColor()
    {
        _settingsService.ColorOfScreen = _settingsService.ReadNameOfColor("MainScreen", "White");
        Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), _settingsService.ColorOfScreen);
    }

    /// <summary>
    /// Method which modifiy JSON file with color proprties
    /// </summary>
    /// <param name="filePath"></param>
    private static void ModifyJsonColorFile(string filePath)
    {
        try
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                dynamic? jsonObject = JObject.Parse(json);

                Console.WriteLine("List of screens that you can modify");
                Console.WriteLine("1. MainScreen");
                Console.WriteLine("2. AnimalsScreen");
                Console.WriteLine("3. MammalsScreen");
                Console.WriteLine("4. DogsScreen");
                Console.WriteLine("5. WolfsScreen");
                Console.WriteLine("6. DolphinsScreen");
                Console.WriteLine("6. BengalTigerScreen");
                Console.Write("Please, write the name of screen you want to modify: ");

                string? screenName = Console.ReadLine();

                if (jsonObject[screenName] != null)
                { 
                    Console.WriteLine($"Current color of {screenName} is {jsonObject[screenName]}");
                    Console.WriteLine("Here are all the colour options available for change: ");
                    Console.WriteLine("1. Red");
                    Console.WriteLine("2. Blue");
                    Console.WriteLine("3. Green");
                    Console.WriteLine("4. Cyan");
                    Console.WriteLine("5. Magenta");
                    Console.Write("Enter the new color number: ");
                    string? newValue = Console.ReadLine();

                    if (newValue == "Red" | newValue == "Blue" | newValue == "Green" | newValue == "Cyan" | newValue == "Magenta") {
                        if (newValue is not null) { jsonObject[screenName] = JToken.FromObject(newValue); }
                        else { Console.WriteLine("Your property is incorrect. "); }


                        File.WriteAllText(filePath, jsonObject.ToString());
                        Console.WriteLine($"The color of {newValue} modified.");
                    } 
                    else 
                    {
                        Console.WriteLine("Color which you write is incorrect");
                    }
                }
                else
                {
                    Console.WriteLine($"The name of screen '{screenName}' not found in the JSON file.");
                }
            }
        }
        catch
        {
            Console.WriteLine($"An error occurred while modifying the JSON file.");
        }
    }

    #endregion // Private Methods
}