using SampleHierarchies.Data.Mammals;
using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Services;
using SampleHierarchies.Services;

namespace SampleHierarchies.Gui;

/// <summary>
/// Wolves screen
/// </summary>
public class WolfsScreen : Screen
{
    #region Properties And Ctor

    /// <summary>
    /// Data service,
    /// SettingsService
    /// </summary>
    private readonly IDataService _dataService;
    private readonly ISettingsService _settingsService;
   
    /// <summary>
    /// Ctor.
    /// </summary>
    /// <param name="dataService">Data service reference</param>
    public WolfsScreen(IDataService dataService, ISettingsService settingsService)
    {
        _dataService = dataService;
        _settingsService = settingsService;
    }

    #endregion // Properties And Ctor

    #region Public Methods

    /// <summary>
    /// Method for showing wolf's main screen
    /// </summary>
    public override void Show()
    {
        while (true)
        {
            InitialisingColor();

            Console.WriteLine();
            Console.WriteLine("Your available choices are:");
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. List all wolfs");
            Console.WriteLine("2. Create a new wolf");
            Console.WriteLine("3. Delete existing wolf");
            Console.WriteLine("4. Modify existing wolf");
            Console.Write("Please chooise something: ");

            string? choiceAsString = Console.ReadLine();

            try
            {
                if (choiceAsString is null)
                {
                    throw new ArgumentNullException(nameof(choiceAsString));
                }

                WolfScreenChoise choice = (WolfScreenChoise)Int32.Parse(choiceAsString);
                switch (choice)
                {
                    case WolfScreenChoise.List:
                        WolfList();
                        break;

                    case WolfScreenChoise.Create:
                        CreateWolf();
                        break;

                    case WolfScreenChoise.Delete:
                        DeleteWolf();
                        break;

                    case WolfScreenChoise.Modify:
                        ModifyWolf();
                        break;

                    case WolfScreenChoise.Exit:
                        Console.WriteLine("Going back to parent menu.");
                        return;
                }
            }
            catch
            {
                Console.WriteLine("Incorrect choice. Try again.");

            }
        }
    }

    #endregion // Public Methods

    #region Private Methods

    /// <summary>
    /// Method which initialise color of "WolfsScreen"
    /// </summary>
    private void InitialisingColor()
    {
        _settingsService.ColorOfScreen = _settingsService.ReadNameOfColor("WolfsScreen", "White");
        Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), _settingsService.ColorOfScreen);
    }

    /// <summary>
    /// Method for showing list of all wolves
    /// </summary>
    private void WolfList()
    {
        Console.WriteLine();
        if (_dataService?.Animals?.Mammals?.Wolves is not null &&
            _dataService.Animals.Mammals.Wolves.Count > 0)
        {
            Console.WriteLine("Here's a list of wolves:");
            int i = 1;
            foreach (Wolf wolf in _dataService.Animals.Mammals.Wolves.Cast<Wolf>())
            {
                Console.Write($"Wolf's number is {i}, ");
                wolf.Display();
                i++;
            }
        }
        else
        {
            Console.WriteLine("Not a single wolf on the list yet.");
        }
    }

    /// <summary>
    /// Method which create wolves
    /// </summary>
    private void CreateWolf()
    {
        try
        {
            Wolf wolf = AddEditWolf();
            _dataService?.Animals?.Mammals?.Wolves?.Add(wolf);
            Console.WriteLine("Wolf with the name: {0} was added to a list of wolves", wolf.Name);
        }
        catch
        {
            Console.WriteLine("Invalid input.");
        }
    }

    /// <summary>
    /// Method for deleting wolf from the list
    /// </summary>
    private void DeleteWolf()
    {
        try
        {
            Console.Write("What is the name of the wolf you want to delete?");
            string? name = Console.ReadLine();
            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            Wolf? wolf = (Wolf?)(_dataService?.Animals?.Mammals?.Wolves
                ?.FirstOrDefault(w => w is not null && string.Equals(w.Name, name)));
            if (wolf is not null)
            {
                _dataService?.Animals?.Mammals?.Wolves?.Remove(wolf);
                Console.WriteLine("Wolf with name: {0} was deleted from a list of wolves", wolf.Name);
            }
            else
            {
                Console.WriteLine("Wolf is not found.");
            }
        }
        catch
        {
            Console.WriteLine("Invalid input.");
        }
    }

    /// <summary>
    /// Method for editing exiting wolf 
    /// </summary>
    private void ModifyWolf()
    {
        try
        {
            Console.Write("What is the name of the wolf you want to edit?: ");
            string? name = Console.ReadLine();
            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            Wolf? wolf = (Wolf?)(_dataService?.Animals?.Mammals?.Wolves
                        ?.FirstOrDefault(w => w is not null && string.Equals(w.Name, name)));
            if (wolf is not null)
            {
                Wolf wolfModified = AddEditWolf();
                wolf.Copy(wolfModified);
                Console.Write("Wolf after edit: ");
                wolf.Display();
            }
            else
            {
                Console.WriteLine("Wolf not found.");
            }
        }
        catch
        {
            Console.WriteLine("Incorrect input. Try again.");
        }
    }

    /// <summary>
    /// Method which helps create and(or) edit wolves 
    /// </summary>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    private static Wolf AddEditWolf()
    {
        Console.Write("What name of the wolf?: ");
        string? name = Console.ReadLine();
        Console.Write("What is the wolf's age?: ");
        string? ageAsString = Console.ReadLine();

        ///<summary>
        /// Asking user for hunting features
        ///</summary>
        Console.Write("Does it hunts in group?(Write Yes or No): ");
        string? choisePackHunting = Console.ReadLine();
        string? packHuntingDefinition = " - ";
        bool isPackHunter = false;
        switch (choisePackHunting)
        {
            case "Yes":
                isPackHunter = true;
                Console.Write("Write how wolf hunting if group: ");
                packHuntingDefinition = Console.ReadLine();
                break;
            case "No":
                packHuntingDefinition = "Wolf doesn't hunt in group.";
                break;
            default:
                Console.WriteLine("Incorrect input.");
                break;
        }

        /// <summary>
        /// Asking user about wolf's communication
        /// </summary>
        Console.Write("Does it communicate by howl(Please write Yes or No): ");
        string? choiseCommunicate = Console.ReadLine();
        string? communicationDefinition = " - ";
        bool isCommunicating = false;
        switch (choiseCommunicate)
        {
            case "Yes":
                isCommunicating = true;
                Console.Write("Write how wolf communicate with howl: ");
                communicationDefinition = Console.ReadLine();
                break;
            case "No":
                communicationDefinition = "Wolf doesn't communicate by using howl. It communicate's with gestures and smells";
                break;
            default:
                Console.WriteLine("Invalid input. ");
                break;
        }

        Console.Write("What does it eat? ");
        string? diet = Console.ReadLine();

        /// <summary>
        /// Asking user about paws
        /// </summary>
        Console.Write("Does the wolf have stong paws?(Please write Yes or No): ");
        string? choisePaws = Console.ReadLine();
        string? pawsDefinition = "-";
        bool isPaws = false;
        switch (choisePaws)
        {
            case "Yes":
                isPaws = true;
                pawsDefinition = "Strong paws help the wolf to get better food and fight for territory";
                break;
            case "No":
                pawsDefinition = "Wolf doesn't have strong paws";
                break;
            default:
                Console.WriteLine("Invalid input.");
                break;
        }

        Console.Write("How it helps good sence of smell?: ");
        string? senceOfSmell = Console.ReadLine();

        if (name is null) { throw new ArgumentNullException(nameof(name)); }
        if (ageAsString is null) { throw new ArgumentNullException(nameof(ageAsString)); }
        if (diet is null) { throw new ArgumentNullException(nameof(diet)); }
        if (senceOfSmell is null) { throw new ArgumentNullException(nameof(senceOfSmell)); }
        if (packHuntingDefinition is null) { throw new ArgumentNullException(nameof(packHuntingDefinition)); }
        if (communicationDefinition is null) { throw new ArgumentNullException(nameof(communicationDefinition)); }

        int age = Int32.Parse(ageAsString);

        Wolf wolf = new Wolf(name, age, isPackHunter, packHuntingDefinition, isCommunicating, communicationDefinition,
                             diet, isPaws, pawsDefinition, senceOfSmell);

        return wolf;
    }

    #endregion // Private Methods
}