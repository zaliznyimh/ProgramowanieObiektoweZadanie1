using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Data.Mammals;
using SampleHierarchies.Enums;
namespace SampleHierarchies.Data.Mammals;

public class BengalTiger : MammalBase, IBengalTiger
{
    #region Interface members

    /// <summary>
    /// Implementation IBengalTiger interface members
    /// IsApexPredator
    /// ApexPredator
    /// LargeSize
    /// CamouflageFur
    /// IsPowerfulLegs
    /// PowerfulLegs
    /// IsSolitaryBehavior
    /// SolitaryBehavior
    /// </summary>
    
    public bool IsApexPredator { get; set ; }
    public string ApexPredator { get; set; }
    public float LargeSize { get; set; }
    public string CamouflageFur { get; set; }
    public bool IsPowerfulLegs { get; set; }
    public string PowerfulLegs { get; set; }
    public bool IsSolitaryBehavior { get; set; }
    public string SolitaryBehavior { get; set; }

    #endregion // Interface membres

    #region Public Methods

    public override void Display()
    {
        Console.WriteLine($"Hi, My name is {Name} and I'm {Age} years old." +
                          $"ApexPredator: {ApexPredator}, LargeSize: {LargeSize}, Camouflage fur: {CamouflageFur}, Powerful legs: {PowerfulLegs}," +
                          $"Solitary behavior: {SolitaryBehavior}");
    }

    public override void Copy(IAnimal animal)
    {
        if (animal is IBengalTiger ad)
        {
            base.Copy(animal);
            IsApexPredator = ad.IsApexPredator;
            ApexPredator = ad.ApexPredator;
            LargeSize = ad.LargeSize;
            CamouflageFur = ad.CamouflageFur;
            IsPowerfulLegs = ad.IsPowerfulLegs;
            PowerfulLegs = ad.PowerfulLegs;
            IsSolitaryBehavior = ad.IsSolitaryBehavior;
            SolitaryBehavior = ad.SolitaryBehavior;
        }
    }
    
    #endregion // Public Methods

    #region Ctor
    
    /// <summary>
    /// Ctor
    /// </summary>
    /// <param name="name"></param>
    /// <param name="age"></param>
    /// <param name="isApexPredator"></param>
    /// <param name="apexPredator"></param>
    /// <param name="largeSize"></param>
    /// <param name="commouflageFur"></param>
    /// <param name="isPowerfulLegs"></param>
    /// <param name="powerfulLegs"></param>
    /// <param name="isSolitaryBehavior"></param>
    /// <param name="solitaryBehavior"></param>
    public BengalTiger(string name, int age, bool isApexPredator, string apexPredator, float largeSize, string commouflageFur, bool isPowerfulLegs,
                       string powerfulLegs, bool isSolitaryBehavior, string solitaryBehavior) : base(name, age, MammalSpecies.BengalTiger) 
    {
        IsApexPredator = isApexPredator;
        ApexPredator = apexPredator;
        LargeSize = largeSize;
        CamouflageFur = commouflageFur;
        IsPowerfulLegs = isPowerfulLegs;
        PowerfulLegs = powerfulLegs;
        IsPowerfulLegs = isPowerfulLegs;
        IsSolitaryBehavior = isSolitaryBehavior;
        SolitaryBehavior = solitaryBehavior;
    }

    #endregion // Ctor
}
