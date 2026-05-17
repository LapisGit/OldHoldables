using System.IO;
using UnityEngine;
using BepInEx;
using BepInEx.Configuration;

namespace OldHoldables
{
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {
        internal static ConfigEntry<bool> disableDropping;

        private void Awake()
        {
            disableDropping = Config.Bind(
                "General",
                "disableDropping",
                false,
                "Turn off manual dropping altogether. Not recommended, but may be needed for Index controllers"
            );

            string configPath = Path.Combine(Paths.ConfigPath, "OldHoldables.cfg");

            GameObject root = new GameObject(PluginInfo.Name);
            DontDestroyOnLoad(root);
            root.AddComponent<OHManager>();
        }
    }
}