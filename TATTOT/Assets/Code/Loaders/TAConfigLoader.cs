using UnityEngine;

/// <summary>
/// Load any configuration files available.
/// </summary>
public class TAConfigurationLoader
{
    #region Configuration loading

    /// <summary>
    /// Load the main <see cref="TAConfiguration"/> object.
    /// </summary>
    /// <returns><see cref="TAConfiguration"/> file object loaded from Resources folder.</returns>
    public static TAConfiguration LoadConfigurationFile()
    {
        TextAsset configurationFile = Resources.Load<TextAsset>("Configuration/TAConfig-Global");
        TAConfiguration config = JsonUtility.FromJson<TAConfiguration>(configurationFile.text);

        return config;
    }

    #endregion
}