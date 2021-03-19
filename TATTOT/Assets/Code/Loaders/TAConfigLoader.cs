using UnityEngine;

/// <summary>
/// Load any configuration files available.
/// </summary>
public class TAConfigurationLoader
{
    private static TAConfiguration CONFIGURATION = null;

    #region Configuration loading

    /// <summary>
    /// Get the current <see cref="TAConfiguration"/> available. If it hasn't
    /// been loaded, <see cref="LoadConfigurationFile"/> will load the current
    /// static instance.
    /// </summary>
    /// <returns></returns>
    public static TAConfiguration GetConfiguration()
    {
        if (CONFIGURATION == null)
        {
            CONFIGURATION = TAConfigurationLoader.LoadConfigurationFile();
        }

        return CONFIGURATION;
    }

    /// <summary>
    /// Force the current <see cref="TAConfiguration"/> file to be reloaded from
    /// the disk. 
    /// </summary>
    public static void ReloadConfigurationFile()
    {
        CONFIGURATION = LoadConfigurationFile();
    }

    /// <summary>
    /// Load the main <see cref="TAConfiguration"/> object.
    /// </summary>
    /// <returns><see cref="TAConfiguration"/> file object loaded from Resources
    /// folder.</returns>
    private static TAConfiguration LoadConfigurationFile()
    {
        TextAsset configurationFile = Resources.Load<TextAsset>("Configuration/TAConfig-Global");
        TAConfiguration config = JsonUtility.FromJson<TAConfiguration>(configurationFile.text);

        return config;
    }

    #endregion
}