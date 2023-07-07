using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Data.Mammals;
using SampleHierarchies.Enums;

namespace SampleHierarchies.Data.Mammals;

public class Wolf : MammalBase, IWolf
{
    #region Interface members

    /// <summary>
    /// Implementation IWolf interface members 
    /// </summary>

    /// <summary>
    /// Properties which describe does an wolf hunt in a group
    /// </summary>
    public bool IsPackHunting { get; set; }
    public string PackHunting { get; set; }

    /// <summary>
    /// Properties which describe how wolves are communication
    /// </summary>
    public bool IsCommunicating { get; set; }
    public string Communication { get; set; }
    
    /// <summary>
    /// Property that describes what wolf eat
    /// </summary>
    public string Diet { get; set; }

    /// <summary>
    /// Properties which describes how wolf use it's paws 
    /// </summary>
    public bool IsStrongPaws { get; set; }
    public string StrongPaws { get; set; }

    /// <summary>
    /// Property that how wolf uses it's sence of smell 
    /// </summary>
    public string SenceOfSmell { get; set; }

    #endregion // Interface members

    #region Public Methods

    /// <summary>
    /// Method that displaying information about Wolf 
    /// </summary>
    public override void Display()
    {
        Console.WriteLine($"Hi, My name is {Name}, I'm {Age} years old.");
        Console.WriteLine($"Pack hunter: {PackHunting}, Howling communication: {Communication}, Carnivorous diet:{Diet}, " +
                          $"Strong paws: {StrongPaws}, Good sense of smell: {SenceOfSmell}");
    }

    /// <summary>
    /// Method for copying species from wolves
    /// </summary>
    /// <param name="animal"></param>
    public override void Copy(IAnimal animal)
    {
        if (animal is IWolf ad)
        {
            base.Copy(animal);
            IsPackHunting = ad.IsPackHunting;
            PackHunting = ad.PackHunting;
            IsCommunicating = ad.IsCommunicating;
            Communication = ad.Communication;
            Diet = ad.Diet;
            StrongPaws = ad.StrongPaws;
            SenceOfSmell = ad.SenceOfSmell;
        }
    }

    #endregion

    #region Ctor and Properties

    /// <summary>
    /// Ctor
    /// </summary>
    /// <param name="name"></param>
    /// <param name="age"></param>
    /// <param name="isPackHunting"></param>
    /// <param name="packHunting"></param>
    /// <param name="isCommunicating"></param>
    /// <param name="communication"></param>
    /// <param name="diet"></param>
    /// <param name="isStrongPaws"></param>
    /// <param name="strongPaws"></param>
    /// <param name="senceOfSmell"></param>
    public Wolf(string name, int age, bool isPackHunting, string packHunting, bool isCommunicating, string communication,
                string diet, bool isStrongPaws, string strongPaws, string senceOfSmell) : base(name, age, MammalSpecies.Wolf)
    {
        IsPackHunting = isPackHunting;
        PackHunting = packHunting;
        IsCommunicating = isCommunicating;
        Communication = communication;
        Diet = diet;
        IsStrongPaws = isStrongPaws;
        StrongPaws = strongPaws;
        SenceOfSmell = senceOfSmell;
    }

    #endregion // Ctor and Properties
}