using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Data.Mammals;
using SampleHierarchies.Enums;
namespace SampleHierarchies.Data.Mammals;

public class Dolphin : MammalBase, IDolphin
{
    #region Interface Members
    /// <summary>
    /// Implementation IDolphin interface members 
    /// UseEcholocation
    /// Echolocation
    /// SocialBehavior
    /// IsPlayfulBehavior
    /// IsPlayfulBehavior
    /// PlayfulBehavior
    /// LargeBrain
    /// IsSwimmingAtHighSpeed
    /// SwimmingAtHighSpeed  
    /// </summary>
    public bool UseEcholocation { get ; set ; }
    public string Echolocation { get; set; }
    public string SocialBehavior { get; set; }
    public bool IsPlayfulBehavior { get; set; }
    public string PlayfulBehavior { get; set; }
    public int LargeBrain { get; set; }
    public bool IsSwimmingAtHighSpeed { get; set; }
    public string SwimmingAtHightSpeed { get; set; }

    #endregion // Interface Members

    #region Public Methods

    /// <summary>
    /// Method that displaying information 
    /// </summary>
    public override void Display()
    {
        Console.WriteLine($"Hi, My name is {Name} and I'm {Age} years old. Echolocation: {Echolocation}, Social Behavior: {SocialBehavior}," +
                          $"Playful Behavior {PlayfulBehavior}, Large brain: My brain is {LargeBrain} cubic centimeters, Swimming at high speed: {SwimmingAtHightSpeed}");
    }

    /// <summary>
    /// Method for copying species from doplhins
    /// </summary>
    /// <param name="animal"></param>
    public override void Copy(IAnimal animal)
    {
        if (animal is IDolphin ad)
        {
            base.Copy(animal);
            UseEcholocation = ad.UseEcholocation;
            Echolocation = ad.Echolocation;
            SocialBehavior = ad.SocialBehavior;
            IsPlayfulBehavior = ad.IsPlayfulBehavior;
            PlayfulBehavior = ad.PlayfulBehavior;
            LargeBrain = ad.LargeBrain;
            IsSwimmingAtHighSpeed = ad.IsSwimmingAtHighSpeed;
            SwimmingAtHightSpeed = ad.SwimmingAtHightSpeed;
        }
    }

    #endregion // Public Methods

    #region Ctor

    /// <summary>
    /// Ctor
    /// </summary>
    /// <param name="name"></param>
    /// <param name="age"></param>
    /// <param name="useEcholocation"></param>
    /// <param name="echolocation"></param>
    /// <param name="socialBehavior"></param>
    /// <param name="isPlayfulBehavior"></param>
    /// <param name="playfulBehavior"></param>
    /// <param name="largeBrain"></param>
    /// <param name="isSwimmingAtHighSpeed"></param>
    /// <param name="swimmingAtHighSpeed"></param>
     public Dolphin(string name, int age, bool useEcholocation, string echolocation, string socialBehavior, bool isPlayfulBehavior, string playfulBehavior, int largeBrain,
                    bool isSwimmingAtHighSpeed, string swimmingAtHighSpeed) : base(name, age, MammalSpecies.Dolphin)
     {
        UseEcholocation = useEcholocation;
        Echolocation = echolocation;
        SocialBehavior = socialBehavior;
        IsPlayfulBehavior = isPlayfulBehavior;
        PlayfulBehavior = playfulBehavior;
        LargeBrain = largeBrain;
        IsSwimmingAtHighSpeed = isSwimmingAtHighSpeed;
        SwimmingAtHightSpeed = swimmingAtHighSpeed;
     }
    
    #endregion // Ctor
}