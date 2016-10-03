using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace RPG.Utilities
{
    /// <summary>
    /// The Settings Controller Class
    /// </summary>
    public class Settings
    {
        private string path;
        /// <summary>
        /// Initializes the settings controller
        /// </summary>
        public Settings()
        {
            path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),"RPG");
            properties = new SettingsProperties();
            Reload();
        }
        private SettingsProperties properties { get; set; }
        /// <summary>
        /// True if this is the time the settings are initialized.
        /// </summary>
        public bool fLaunch { get; set; }
        /// <summary>
        /// Gets the value with the key from the settings dictionary
        /// </summary>
        /// <param name="key"></param>
        /// <returns>Value from the settings</returns>
        public bool getBool(string key)
        {
            return properties.booleans[key];
        }
        /// <summary>
        /// Gets the value with the key from the settings dictionary
        /// </summary>
        /// <param name="key"></param>
        /// <returns>Value from the settings</returns>
        public string getString(string key)
        {
            return properties.strings[key];
        }
        /// <summary>
        /// Gets the value with the key from the settings dictionary
        /// </summary>
        /// <param name="key"></param>
        /// <returns>Value from the settings</returns>
        public int getInt(string key)
        {
            return properties.integers[key];
        }
        /// <summary>
        /// Saves the key and value in the settings after executing Settings.Commit();
        /// </summary>
        /// <param name="key">The key as which it will be stored</param>
        /// <param name="value">The value</param>
        public void putBool(string key, bool value)
        {
            properties.booleans[key] = value;
        }
        /// <summary>
        /// Saves the key and value in the settings after executing Settings.Commit();
        /// </summary>
        /// <param name="key">The key as which it will be stored</param>
        /// <param name="value">The value</param>
        public void putString(string key, string value)
        {
            properties.strings[key] = value;
        }
        /// <summary>
        /// Saves the key and value in the settings after executing Settings.Commit();
        /// </summary>
        /// <param name="key">The key as which it will be stored</param>
        /// <param name="value">The value</param>
        public void putInt(string key, int value)
        {
            properties.integers[key] = value;
        }
        /// <summary>
        /// Commit setting changes
        /// </summary>
        public void Commit()
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            BinaryFormatter formatter = new BinaryFormatter();
            using (Stream stream = File.Open(Path.Combine(path, "settings.settings"), FileMode.OpenOrCreate))
            {
                formatter.Serialize(stream,properties);
            }
        }
        /// <summary>
        /// (re)loads the settings.
        /// </summary>
        public void Reload()
        {
            if (!Directory.Exists(path) && File.Exists(Path.Combine(path, "settings.settings")))
            {
                fLaunch = true;
                Directory.CreateDirectory(path);
                properties = new SettingsProperties();
                Commit();
            }
            else
            {
                try
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    using (Stream stream = File.Open(Path.Combine(path, "settings.settings"), FileMode.Open))
                    {
                        properties = (SettingsProperties)formatter.Deserialize(stream);
                    }
                }
                catch { fLaunch = true; }
            }
        }
        /// <summary>
        /// Command to reset all the users settings.
        /// </summary>
        public void Reset()
        {
            Directory.Delete(path,true);
            Reload();
        }
        /// <summary>
        /// The serializable class which is stored in the settings.settings file.
        /// </summary>
        [Serializable]
        private class SettingsProperties
        {
            public Dictionary<string, string> strings = new Dictionary<string, string>();
            public Dictionary<string, bool> booleans = new Dictionary<string, bool>();
            public Dictionary<string, int> integers = new Dictionary<string, int>();
        }
    }
}
