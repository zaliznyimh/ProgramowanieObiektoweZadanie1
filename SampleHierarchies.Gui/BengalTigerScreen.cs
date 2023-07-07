using SampleHierarchies.Data.Mammals;
using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Services;
using SampleHierarchies.Services;
using System.Linq.Expressions;

namespace SampleHierarchies.Gui;
public class BengalTigerScreen : Screen
{
    #region Properties And Ctor

    /// <summary>
    /// Data service.
    /// </summary>
    private readonly IDataService _dataService;
    private ISettingsService? _settingsService;

    /// <summary>
    /// Ctor.
    /// </summary>
    /// <param name="dataService">Data service reference</param>
    public BengalTigerScreen(IDataService dataService)
    {
        _dataService = dataService;
    }

    #endregion // Properties And Ctor

    #region Public Methods

    public override void Show()
    {
        while (true)
        {
            InitialisingColor();

            Console.WriteLine();
            Console.WriteLine("Your available choices are:");
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. List all bengal tigers");
            Console.WriteLine("2. Create a new bengal tiger");
            Console.WriteLine("3. Delete existing tiger");
            Console.WriteLine("4. Modify existing tiger");
            Console.Write("Please chooise something: ");

            string? choiceAsString = Console.ReadLine();

            /// <summary>
            /// Function for displaying the bengal tiger screen
            /// </summary>
            try
            {
                if (choiceAsString is null)
                {
                    throw new ArgumentNullException(nameof(choiceAsString));
                }

                BengalTigerScreenChoice choice = (BengalTigerScreenChoice)Int32.Parse(choiceAsString);
                switch (choice)
                {
                    case BengalTigerScreenChoice.List:
                        BengalTigerList();
                        break;

                    case BengalTigerScreenChoice.Create:
                        CreateBengalTiger();
                        break;

                    case BengalTigerScreenChoice.Delete:
                        DeleteBengalTiger();
                        break;

                    case BengalTigerScreenChoice.Modify:
                        ModifyBengalTiger();
                        break;

                    case BengalTigerScreenChoice.Exit:
                        Console.WriteLine("Going back to parent menu.");
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
    /// Method which initialise color property for "BengalTigerScreen"
    /// </summary>
    private void InitialisingColor()
    {
        _settingsService = new SettingsService();
        _settingsService.ColorOfScreen = _settingsService.ReadNameOfColor("BengalTigerScreen", "White");
        Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), _settingsService.ColorOfScreen);
    }

    /// <summary>
    /// Method for showing list of all bengal tigers
    /// </summary>
    private void BengalTigerList()
    {
        Console.WriteLine();
        if (_dataService?.Animals?.Mammals?.BengalTigers is not null &&
            _dataService.Animals.Mammals.BengalTigers.Count > 0)
        {
            Console.WriteLine("Here's a list of bengal tigers:");
            int i = 1;
            foreach (BengalTiger tiger in _dataService.Animals.Mammals.BengalTigers.Cast<BengalTiger>())
            {
                Console.Write($"Dolphin's number is {i}, ");
                tiger.Display();
                i++;
            }
        }
        else
        {
            Console.WriteLine("There are no bengal tigers on the list.");
        }
    }

    /// <summary>
    /// Method which can create bengal tiger
    /// </summary>
    private void CreateBengalTiger()
    {
        try
        {
            BengalTiger tiger = AddEditBengalTiger();
            _dataService?.Animals?.Mammals?.BengalTigers?.Add(tiger);
            Console.WriteLine("Bengal tiger with the name: {0} was added to a list of tigers", tiger.Name);
        }
        catch
        {
            Console.WriteLine("Incorrect input.");
        }
    }

    /// <summary>
    /// Method for deleting bengal tiger from the list
    /// </summary>
    private void DeleteBengalTiger()
    {
        try
        {
            Console.Write("What's the name of the bengal tiger you want to delete? ");
            string? name = Console.ReadLine();
            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            BengalTiger? tiger = (BengalTiger?)(_dataService?.Animals?.Mammals?.BengalTigers
                                  ?.FirstOrDefault(bt => bt is not null && string.Equals(bt.Name, name)));
            if (tiger is not null)
            {
                _dataService?.Animals?.Mammals?.BengalTigers?.Remove(tiger);
                Console.WriteLine($"Bengal tiger with the name: {tiger.Name} was added to a list of dolphins");
            }
            else
            {
                Console.WriteLine("Bengal tiger was not found.");
            }
        }
        catch
        {
            Console.WriteLine("Invalid input.");
        }
    }

    /// <summary>
    /// Method for editing some dolphin's properties
    /// </summary>
    private void ModifyBengalTiger()
    {
        try
        {
            Console.Write("What is the name of the dolphin you want to edit? ");
            string? name = Console.ReadLine();
            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            BengalTiger? tiger = (BengalTiger?)(_dataService?.Animals?.Mammals?.BengalTigers
                               ?.FirstOrDefault(bt => bt is not null && string.Equals(bt.Name, name)));
            if (tiger is not null)
            {
                BengalTiger tigerModified = AddEditBengalTiger();
                tiger.Copy(tigerModified);
                Console.Write("Bengal tiger after edit: ");
                tiger.Display();
            }
            else
            {
                Console.WriteLine("Bengal tiger not found.");
            }
        }
        catch
        {
            Console.WriteLine("Incorrect input. Try again.");
        }
    }

    private static BengalTiger AddEditBengalTiger()
    {
        Console.Write("Write the name of  Bengal Tiger: ");
        string? name = Console.ReadLine();

        Console.Write("Write tiger's age: ");
        string? ageAsString = Console.ReadLine();

        Console.Write("Is your bengal tiger predator?(Write Yes or No): ");
        string? choiseApexPredator = Console.ReadLine();
        bool isApexPredator = false;
        string? apexPredatorDefinition = "";

        switch (choiseApexPredator)
        {
            case "Yes":
                Console.Write("Write how do hunting abilities manifest themselves: ");
                isApexPredator = true;
                apexPredatorDefinition = Console.ReadLine();
                break;
            case "No":
                apexPredatorDefinition = "Bengal tiger doesn't show it's apex predator features";
                break;
            default:
                Console.WriteLine("Invalid input");
                break;
        }

        Console.Write("Write the size of animal in metres: ");
        string? largeSizeAsString = Console.ReadLine();

        Console.Write("Desribe the comouflage fur: ");
        string? commouflageFur = Console.ReadLine();

        Console.Write("Does tiger has powerful legs?(Write Yes or No): ");
        string? choisePowerfulLegs = Console.ReadLine();
        bool isPowerfulLegs = false;
        string? powerfulLegsDefinition = " - ";

        switch (choisePowerfulLegs)
        {
            case "Yes":
                Console.Write("Write how powerful legs help tiger in life: ");
                isPowerfulLegs = true;
                powerfulLegsDefinition = Console.ReadLine();
                break;
            case "No":
                powerfulLegsDefinition = "Bengal tiger has weak legs";
                break;
            default:
                Console.WriteLine("Invalid input");
                break;
        }

        Console.Write("Does the bengal tiger lives alone?(Write Yes or No): ");
        string? choiseSolitaryBehavior = Console.ReadLine();
        bool isSolitaryBehavior = false;
        string? solitaryBehaviorDefinition = " - ";

        switch (choiseSolitaryBehavior)
        {
            case "Yes":
                Console.WriteLine("Desribe his solitary behavior: ");
                isSolitaryBehavior = true;
                solitaryBehaviorDefinition = Console.ReadLine();
                break;
            case "No":
                solitaryBehaviorDefinition = "Bengal tiger has weak legs ";
                break;
            default:
                Console.WriteLine("Invalid input");
                break;
        }

        if (name is null) { throw new ArgumentNullException(nameof(name)); }
        if (ageAsString is null) { throw new ArgumentNullException(nameof(ageAsString)); }
        if (apexPredatorDefinition is null) { throw new ArgumentNullException(nameof(apexPredatorDefinition)); }
        if (largeSizeAsString is null) { throw new ArgumentNullException(nameof(largeSizeAsString)); }
        if (commouflageFur is null) { throw new ArgumentNullException(nameof(commouflageFur)); }
        if (powerfulLegsDefinition is null) { throw new ArgumentNullException(nameof(powerfulLegsDefinition)); }
        if (solitaryBehaviorDefinition is null) { throw new ArgumentNullException(nameof(solitaryBehaviorDefinition)); }

        int age = Convert.ToInt32(ageAsString);
        float largeSize = float.Parse(largeSizeAsString);

        BengalTiger tiger = new BengalTiger(name, age, isApexPredator, apexPredatorDefinition, largeSize, commouflageFur, isPowerfulLegs,
                                            powerfulLegsDefinition, isSolitaryBehavior, solitaryBehaviorDefinition);

        return tiger;
    }

    #endregion // Private Methods

}