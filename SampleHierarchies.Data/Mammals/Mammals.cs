using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Data.Mammals;

namespace SampleHierarchies.Data.Mammals;

/// <summary>
/// Mammals collection.
/// </summary>
public class Mammals : IMammals
{
    #region IMammals Implementation

    /// <inheritdoc/>
    public List<IDog> Dogs { get; set; }
    public List<IWolf> Wolves { get; set; } 
    public List<IDolphin> Dolphins { get; set; }
    public List<IBengalTiger> BengalTigers { get; set; }

    #endregion // IMammals Implementation

    #region Ctors

    /// <summary>
    /// Default ctor.
    /// </summary>
    public Mammals()
    {
        Dogs = new List<IDog>();
        Wolves = new List<IWolf>();
        Dolphins = new List<IDolphin>();
        BengalTigers = new List<IBengalTiger>();
    }

    #endregion // Ctors
}
