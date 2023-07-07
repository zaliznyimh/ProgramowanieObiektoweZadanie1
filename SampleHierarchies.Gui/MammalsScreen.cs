using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Services;
using SampleHierarchies.Services;

namespace SampleHierarchies.Gui;

/// <summary>
/// Mammals main screen.
/// </summary>
public sealed class MammalsScreen : Screen
{
    #region Properties And Ctor

    private ISettingsService? _settingsService;

    /// <summary>
    /// Animals screen.
    /// </summary>
    private readonly DogsScreen _dogsScreen;
    private readonly WolfsScreen _wolfsScreen;  
    private readonly DolphinsScreen _dolphinsScreen;
    private readonly BengalTigerScreen _bengalTigerScreen;

    /// <summary>
    /// Ctor.
    /// </summary>
    /// <param name="dataService">Data service reference</param>
    /// <param name="dogsScreen">Dogs screen</param>
    /// <param name="wolfsScreen">Gray wolfs screen</param>>
    public MammalsScreen(DogsScreen dogsScreen, WolfsScreen wolfsScreen, DolphinsScreen dolphinsScreen, BengalTigerScreen bengalTigerScreen)
    {
        _dogsScreen = dogsScreen;
        _wolfsScreen = wolfsScreen;
        _dolphinsScreen = dolphinsScreen;
        _bengalTigerScreen = bengalTigerScreen;
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
            Console.WriteLine("1. Dogs");
            Console.WriteLine("2. Wolves(Wolfs)");
            Console.WriteLine("3. Dolphins");
            Console.WriteLine("4. Bengal Tiger");
            Console.Write("Please enter your choice: ");

            string? choiceAsString = Console.ReadLine();

            /// <summary>
            /// Selection of animal screens
            /// </summary>
            try
            {
                if (choiceAsString is null)
                {
                    throw new ArgumentNullException(nameof(choiceAsString));
                }

                MammalsScreenChoices choice = (MammalsScreenChoices)Int32.Parse(choiceAsString);
                switch (choice)
                {
                    case MammalsScreenChoices.Dogs:
                        _dogsScreen.Show();
                        break;

                    case MammalsScreenChoices.Wolf:
                        _wolfsScreen.Show(); 
                        break;
                    
                    case MammalsScreenChoices.Dolphin:
                        _dolphinsScreen.Show();
                        break;

                    case MammalsScreenChoices.BengalTiger:
                        _bengalTigerScreen.Show();
                        break;

                    case MammalsScreenChoices.Exit:
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

    #region Private methods

    private void InitialisingColor()
    {
        _settingsService = new SettingsService();
        _settingsService.ColorOfScreen = _settingsService.ReadNameOfColor("MammalsScreen", "White");
        Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), _settingsService.ColorOfScreen);
    }

    #endregion // Private methods
}
