using SampleHierarchies.Interfaces.Data.Mammals;

namespace SampleHierarchies.Interfaces.Data;

/// <summary>
/// Mammals collection.
/// </summary>
public interface IMammals
{
    #region Interface Members

    /// <summary>
    /// Dogs collection.
    /// </summary>
    List<IDog> Dogs { get; set; }
    
    /// <summary>
    /// Wolfs collection
    /// </summary>
    List<IWolf> Wolves { get; set; }

    /// <summary>
    /// Dolphins collection
    /// </summary>
    List<IDolphin> Dolphins { get; set; }    

    /// <summary>
    /// Bengal tigers colection
    /// </summary>
    List<IBengalTiger> BengalTigers { get; set; }

    #endregion // Interface Members
}
