using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using RPG.RGame.Player.Inventory;
using RPG.RGame.Items.Food;
using RPG.RGame.Items.Weapons;
using RPG.RGame.Items.Tools;

namespace RPG.Utilities
{
    /// <summary>
    /// The Settings Controller Class
    /// </summary>
    public class Settings
    {
        private string path;
        public delegate void CommitEventHandler(object sender, EventArgs e);
        public event CommitEventHandler Committed;
        protected virtual void OnChanged(EventArgs e)
        {
            if (Committed != null)
                Committed(this, e);
        }
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
            OnChanged(EventArgs.Empty);
            Reload();
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
            public List<Food> FoodItems = new List<Food>();
            public List<Weapons> WeaponsItems = new List<Weapons>();
            public List<Tool> ToolItems = new List<Tool>();
        }
        internal Inventory LoadInventory()
        {
            Inventory inventory = new Inventory();
            inventory.FoodItems = properties.FoodItems;
            inventory.WeaponsItems = properties.WeaponsItems;
            inventory.ToolItems = properties.ToolItems;
            return inventory;
        }
        internal void SaveInventory(Inventory inventory)
        {
            properties.FoodItems = inventory.FoodItems;
            properties.WeaponsItems = inventory.WeaponsItems;
            properties.ToolItems = inventory.ToolItems;
            Commit();
        }
    }
}
