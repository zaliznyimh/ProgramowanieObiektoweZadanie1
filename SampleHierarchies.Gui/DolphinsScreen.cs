using SampleHierarchies.Data.Mammals;
using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Services;
using SampleHierarchies.Services;

namespace SampleHierarchies.Gui;

public class DolphinsScreen : Screen
{
    #region Properties And Ctor

    /// <summary>
    /// Data service.
    /// Settings service
    /// </summary>
    private readonly IDataService _dataService;
    private readonly ISettingsService _settingsService;

    /// <summary>
    /// Ctor.
    /// </summary>
    /// <param name="dataService"></param>
    /// <param name="settingsService"></param>
    public DolphinsScreen(IDataService dataService,
                          ISettingsService settingsService)
    {
        _dataService = dataService;
        _settingsService = settingsService;
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
            Console.WriteLine("1. List all dolphins");
            Console.WriteLine("2. Create a new dolphin");
            Console.WriteLine("3. Delete existing dolphin");
            Console.WriteLine("4. Modify existing dolphin");
            Console.Write("Please chooise something: ");

            string? choiceAsString = Console.ReadLine();

            try
            {
                if (choiceAsString is null)
                {
                    throw new ArgumentNullException(nameof(choiceAsString));
                }

                DolphinsScreenChoices choice = (DolphinsScreenChoices)Int32.Parse(choiceAsString);
                switch (choice)
                {
                    case DolphinsScreenChoices.List:
                        DolphinList();
                        break;

                    case DolphinsScreenChoices.Create:
                        CreateDolphin();
                        break;

                    case DolphinsScreenChoices.Delete:
                        DeleteDolphin();
                        break;

                    case DolphinsScreenChoices.Modify:
                        ModifyDolphin();
                        break;

                    case DolphinsScreenChoices.Exit:
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
    /// Method which initialise color of "DolphinsScreen"
    /// </summary>
    private void InitialisingColor()
    {
        _settingsService.ColorOfScreen = _settingsService.ReadNameOfColor("DolphinsScreen", "White");
        Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), _settingsService.ColorOfScreen);
    }

    /// <summary>
    /// Method for showing list of all dolphins
    /// </summary>
    private void DolphinList()
    {
        Console.WriteLine();
        if (_dataService?.Animals?.Mammals?.Dolphins is not null &&
            _dataService.Animals.Mammals.Dolphins.Count > 0)
        {
            Console.WriteLine("Here's a list of dolphins:");
            int i = 1;
            foreach (Dolphin dolphin in _dataService.Animals.Mammals.Dolphins.Cast<Dolphin>())
            {
                Console.Write($"Dolphin's number is {i}, ");
                dolphin.Display();
                i++;
            }
        }
        else
        {
            Console.WriteLine("There are no dolphins on the list.");
        }
    }

    /// <summary>
    /// Method which can create dolphins
    /// </summary>
    private void CreateDolphin()
    {
        try
        {
            Dolphin dolphin = AddEditDolphin();
            _dataService?.Animals?.Mammals?.Dolphins?.Add(dolphin);
            Console.WriteLine($"Dolphin with the name: {dolphin.Name} was added to a list of dolphins");
        }
        catch
        {
            Console.WriteLine("Incorrect input.");
        }
    }

    /// <summary>
    /// Method for deleting dolphin from the list
    /// </summary>
    private void DeleteDolphin()
    {
        try
        {
            Console.Write("What's the name of the dolphin you want to delete? ");
            string? name = Console.ReadLine();
            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            Dolphin? dolphin = (Dolphin?)(_dataService?.Animals?.Mammals?.Dolphins
                               ?.FirstOrDefault(d => d is not null && string.Equals(d.Name, name)));
            if (dolphin is not null)
            {
                _dataService?.Animals?.Mammals?.Dolphins?.Remove(dolphin);
                Console.WriteLine($"Dolphin with name: {dolphin.Name} was deleted from a list of dolphins");
            }
            else
            {
                Console.WriteLine("Dolphin was not found.");
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
    private void ModifyDolphin()
    {
        try
        {
            Console.Write("What is the name of the dolphin you want to edit? ");
            string? name = Console.ReadLine();
            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            Dolphin? dolphin = (Dolphin?)(_dataService?.Animals?.Mammals?.Dolphins
                               ?.FirstOrDefault(d => d is not null && string.Equals(d.Name, name)));
            if (dolphin is not null)
            {
                Dolphin dolphinModified = AddEditDolphin();
                dolphin.Copy(dolphinModified);
                Console.Write("Dolphin after edit:");
                dolphin.Display();
            }
            else
            {
                Console.WriteLine("Dolphin not found.");
            }
        }
        catch
        {
            Console.WriteLine("Incorrect input. Try again.");
        }
    }

    /// <summary>
    /// Method which helps with creating and(or) editing dolphins
    /// </summary>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0090:Используйте \"new(...)\".", Justification = "<Ожидание>")]
    private static Dolphin AddEditDolphin()
    {
        Console.Write("What name of the dolphin? ");
        string? name = Console.ReadLine();
        Console.Write("What's dolphins age? ");
        string? ageAsString = Console.ReadLine();

        /// <summary>
        /// Asking about dolphin's property of echolocation
        /// </summary>
        Console.Write("Does the dolphin use echolocation?(Write Yes or No): ");
        string? choiseEcholocation = Console.ReadLine();
        string? echolocationDefinition;
        bool useEcholocation;

        if(choiseEcholocation == "Yes")
        { 
            Console.Write("Write how dolphin use echolocation: ");
            echolocationDefinition = Console.ReadLine();
            useEcholocation = true;
        }
        else
        {
            useEcholocation = false;
            echolocationDefinition = "Dolphin doesn't use echolocation. ";
        }

        Console.WriteLine("Desribe dolphin's sociable behavior: ");
        string? sociableBehaviorDefinition = Console.ReadLine();


        /// <summary>
        /// Asking user about playful dolphin's behavior 
        /// </summary>
        Console.Write("Does the dolphin like playing with another dolphins(Yes or No): ");
        string? choicePlayfulBehavior = Console.ReadLine();
        string? playfulBehaviorDefinition;
        bool isPlayfulBehavior;
        
        if(choicePlayfulBehavior == "Yes") {
            Console.Write("Write about dolphin's playful behavior: ");
            playfulBehaviorDefinition = Console.ReadLine();
            isPlayfulBehavior = true;
        }
        else { 
            isPlayfulBehavior = false;
            playfulBehaviorDefinition = "Dolphin doesn't like playing with dolphins. ";
        }

        Console.Write("Write the size of dolphin's brain(In cubic centimeters): ");
        string? largeBrainAsString = Console.ReadLine();

        /// <summary>
        /// Asking user about dolphin's swimming opportunities
        /// </summary>
        Console.Write("Can dolphin swim at high speed?(Write Yes or No): ");
        string? choiseSwimHighSpeed = Console.ReadLine();
        string? swimmingAtHighSpeedDefinition;
        bool isSwimmingAtHighSpeed;

        if(choiseSwimHighSpeed == "Yes")
        {
            Console.Write("Write how dolphin swim at high speed: ");
            swimmingAtHighSpeedDefinition = Console.ReadLine();
            isSwimmingAtHighSpeed = true;
        }
        else
        {
            swimmingAtHighSpeedDefinition = "Dolphin doesn't like swim at high speed.";
            isSwimmingAtHighSpeed = false;
        }

        if (name is null) { throw new ArgumentNullException(nameof(name)); }
        if (swimmingAtHighSpeedDefinition is null) { throw new ArgumentNullException(nameof(isSwimmingAtHighSpeed)); }
        if (echolocationDefinition is null) { throw new ArgumentNullException(nameof(echolocationDefinition)); }
        if (sociableBehaviorDefinition is null) { throw new ArgumentNullException(nameof(sociableBehaviorDefinition)); }
        if (playfulBehaviorDefinition is null) { throw new ArgumentNullException(nameof(playfulBehaviorDefinition)); }


        int largeBrain = Convert.ToInt32(largeBrainAsString); 
        int age = Convert.ToInt32(ageAsString);
        
        Dolphin dolphin = new Dolphin(name, age, useEcholocation, echolocationDefinition, sociableBehaviorDefinition, isPlayfulBehavior, 
                                      playfulBehaviorDefinition, largeBrain, isSwimmingAtHighSpeed, swimmingAtHighSpeedDefinition);

        return dolphin;
    }

    #endregion // Private Methods
}