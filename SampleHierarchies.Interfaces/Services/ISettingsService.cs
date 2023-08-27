using SampleHierarchies.Interfaces.Data;

namespace SampleHierarchies.Interfaces.Services;

public interface ISettingsService
{
    #region Interface Members

    /// <summary>
    /// Read settings.
    /// </summary>
    /// <param name="jsonPath">Json path</param>
    /// <returns></returns>
    ISettings? Read(string jsonPath);

    /// <summary>dla
    /// Write settings.
    /// </summary>
    /// <param name="settings">Settings to written</param>
    /// <param name="jsonPath">Json path</param>
    void Write(ISettings settings, string jsonPath);

    /// <summary>
    /// Property to save the the value of text color
    /// </summary>
    public string? ColorOfScreen { get; set; }

    /// <summary>
    /// Method to read the value of color for each screen
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="screenName"></param>
    /// <param name="defaultColor"></param>
    /// <returns></returns>
    T ReadNameOfColor<T>(string screenName, T defaultColor);

    #endregion // Interface Members
    
}