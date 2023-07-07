using Newtonsoft.Json;
using SampleHierarchies.Data;
using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Services;
using System.Diagnostics;
using System.Xml;

namespace SampleHierarchies.Services;

/// <summary>
/// Implementation of data service.
/// </summary>
public class DataService : IDataService
{
    #region Ctor

    /// <summary>
    /// Ctor.
    /// </summary>
    public DataService()
    {
        Animals = new Animals();
    }

    /// <inheritdoc/>
    public IAnimals? Animals { get; set; }

    #endregion // Ctor

    #region IDataService Implementation

    /// <inheritdoc/>
    public bool Read(string jsonPath)
    {
        bool result = true;

        try
        {
            string jsonContent = File.ReadAllText(jsonPath);
            var jsonSettings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Objects
            };
            Animals = JsonConvert.DeserializeObject<Animals>(jsonContent, jsonSettings);
            if (Animals is null)
            {
                result = false;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            result = false;
        }

        return result;
    }

    /// <inheritdoc/>
    public bool Write(string jsonPath)
    {
        bool result = true;

        try
        {
            var jsonSettings = new JsonSerializerSettings();
            string jsonContent = JsonConvert.SerializeObject(Animals);
            string jsonContentFormatted = jsonContent.FormatJson();
            File.WriteAllText(jsonPath, jsonContentFormatted);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            result = false;
        }

        return result;
    }

    #endregion // IDataService Implementation

}
