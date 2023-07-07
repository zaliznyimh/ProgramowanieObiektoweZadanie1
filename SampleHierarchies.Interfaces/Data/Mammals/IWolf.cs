using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleHierarchies.Interfaces.Data.Mammals;

public interface IWolf : IMammal
{
    #region Interface Members

    /// <summary>
    /// Initialisng IWolf interface members
    /// </summary>

    /// <summary>
    /// Properties that describe does an wolf hunt in a group
    /// </summary>
    public bool IsPackHunting { get; set; }
    public string PackHunting { get; set; }
    /// <summary>
    /// Property that describes how wolf are communicating
    /// </summary>
    public bool IsCommunicating { get; set; }
    public string Communication { get; set; }

    /// <summary>
    /// Property that describes what wolf eat
    /// </summary>
    public string Diet { get; set; }

    /// <summary>
    /// Property that describes how wolf use it's paws
    /// </summary>
    public bool IsStrongPaws { get; set; }
    public string StrongPaws { get; set; }

    /// <summary>
    /// Property that how wolf uses it's sence of smell 
    /// </summary>
    public string SenceOfSmell { get; set; }

    #endregion // Interface Members
}
