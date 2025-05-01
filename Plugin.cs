using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;

namespace BaseIncomePlugin;

[BepInPlugin("com.machaceleste.baseincomeplugin", MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin
{
    internal static new ManualLogSource Logger;

    public static ConfigEntry<int> baseMoney;

    private void Awake()
    {
        baseMoney = Config.Bind("Main", "Base Job Money", 145, new ConfigDescription("Sets the base money per job for the lowest rep missions, default: 145", new AcceptableValueRange<int>(100, 1000)));

        Logger = base.Logger;
        Logger.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");
        var harmony = new Harmony("com.machaceleste.baseincomeplugin");
        harmony.PatchAll();
    }
}