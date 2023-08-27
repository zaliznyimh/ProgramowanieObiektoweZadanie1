using Newtonsoft.Json;
using SampleHierarchies.Data;
using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Services;
using System.Diagnostics;
using System.Text.Json.Nodes;

namespace SampleHierarchies.Services;

/// <summary>
/// Settings service.
/// </summary>
public class SettingsService : ISettingsService
{
    #region Properties and Ctor 

    /// <summary>
    /// Ctor
    /// </summary>
    public SettingsService()
    {
        FilePath = "ColorSetting.json";
    }

    /// <summary>
    ///  Static property which contain name of JSON file
    /// </summary>
    public static string? FilePath { get; set; }

    /// <summary>
    /// Property to save the the value of text color  
    /// </summary>
    public string? ColorOfScreen { get; set; }

    #endregion // Properties and Ctor 

    #region ISettings Implementation

    /// <inheritdoc/>
    public ISettings? Read(string jsonPath)
    {
        ISettings? result = null;

        try
        {
            string jsonContent = File.ReadAllText(jsonPath);
            var jsonSettings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Objects
            };
            result = JsonConvert.DeserializeObject<Settings>(jsonContent, jsonSettings);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
        }

        return result;
    }

    /// <inheritdoc/>
    public void Write(ISettings settings, string jsonPath)
    {
        try
        {
            var jsonSettings = new JsonSerializerSettings();
            string jsonContent = JsonConvert.SerializeObject(settings);
            string jsonContentFormatted = jsonContent.FormatJson();
            File.WriteAllText(jsonPath, jsonContentFormatted);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
        }
    }

    /// <summary>
    /// Method to read the value of color for each screen
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="screenName"></param>
    /// <param name="defaultColor"></param>
    /// <returns></returns>
    public T ReadNameOfColor <T>(string screenName, T defaultColor)
    {
        try
        {
            if (File.Exists(FilePath))
            {
                string json = File.ReadAllText(FilePath);
                dynamic? jsonValue = JsonConvert.DeserializeObject(json);
                if (jsonValue is not null && jsonValue?[screenName] is not null)
                {
                    return jsonValue[screenName].ToObject<T>();
                }
            }
        }
        catch
        {
            Console.WriteLine($"There was an error during an attempt to read from {FilePath} file.");
        }

        return defaultColor;
    }

    #endregion // ISettings Implementation
}