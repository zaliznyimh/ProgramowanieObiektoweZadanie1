using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleHierarchies.Interfaces.Data.Mammals;

public interface IDolphin : IMammal
{
    #region Interface members

    /// <summary>
    /// Initialisng IDolphin's interface members
    /// </summary>

    /// <summary>
    /// Properties which describe the dolpihn's echolocation  
    /// </summary>
    public bool UseEcholocation { get; set; }
    public string Echolocation { get; set; }
    
    /// <summary>
    /// Property which desribes dolphin's social behavior
    /// </summary>
    public string SocialBehavior { get; set; }
    
    /// <summary>
    /// Properties which playful behavior
    /// </summary>
    public bool IsPlayfulBehavior { get; set; }
    public string PlayfulBehavior { get; set; }

    /// <summary>
    /// Property which desribes size of dolphin's brain in cubic centimeters
    /// </summary>
    public int LargeBrain { get; set; }

    /// <summary>
    /// Properties that desribe with which speed can swim dolphin
    /// </summary>
    public bool IsSwimmingAtHighSpeed { get; set; }
    public string SwimmingAtHightSpeed { get;}

    #endregion // Interface members
}
