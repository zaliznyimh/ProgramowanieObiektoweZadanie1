using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleHierarchies.Interfaces.Data.Mammals;

public interface IBengalTiger : IAnimal
{
    #region Interface members

    /// <summary>
    /// IBengalTiger interface members 
    /// </summary>

    /// <summary>
    /// Characteristics of the Bengal tiger as a predator  
    /// </summary>
    public bool IsApexPredator { get; set; }
    public string ApexPredator { get; set; }

    /// <summary>
    /// Property containing the Bengal tiger size value 
    /// </summary>
    public float LargeSize { get; set; }

    /// <summary>
    /// Characteristic which describes bengal tiger camouflage
    /// </summary>
    public string CamouflageFur { get; set; }

    /// <summary>
    /// Characteristics of the Bengal tiger which desribe bengal tiger legs and how it use it 
    /// </summary>
    public bool IsPowerfulLegs { get; set; }
    public string PowerfulLegs { get; set; }

    /// <summary>
    /// Property containing the Bengal tiger behavior as a single individual of the species
    /// </summary>
    public bool IsSolitaryBehavior { get; set; }
    public string SolitaryBehavior { get; set; }

    #endregion // Intreface membres
}
