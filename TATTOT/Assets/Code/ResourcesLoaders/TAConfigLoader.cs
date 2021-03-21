using Code.Logic;
using UnityEngine;

namespace Code.ResourcesLoaders
{
    /// <summary>
    /// Load any configuration files available.
    /// </summary>
    public static class TAConfigurationLoader
    {
        private static TAConfiguration _configuration;

        #region Configuration loading

        /// <summary>
        /// Get the current <see cref="TAConfiguration"/> available. If it hasn't
        /// been loaded, <see cref="LoadConfigurationFile"/> will load the current
        /// static instance.
        /// </summary>
        /// <returns></returns>
        public static TAConfiguration GetConfiguration()
        {
            return _configuration ??= LoadConfigurationFile();
        }

        /// <summary>
        /// Force the current <see cref="TAConfiguration"/> file to be reloaded from
        /// the disk. 
        /// </summary>
        public static void ReloadConfigurationFile()
        {
            _configuration = LoadConfigurationFile();
        }

        /// <summary>
        /// Load the main <see cref="TAConfiguration"/> object.
        /// </summary>
        /// <returns><see cref="TAConfiguration"/> file object loaded from Resources
        /// folder.</returns>
        private static TAConfiguration LoadConfigurationFile()
        {
            var configurationFile = Resources.Load<TextAsset>("Configuration/TAConfig-Global");
            var config = JsonUtility.FromJson<TAConfiguration>(configurationFile.text);

            return config;
        }

        #endregion
    }
}