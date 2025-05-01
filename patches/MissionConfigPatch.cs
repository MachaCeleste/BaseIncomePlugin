using BaseIncomePlugin;
using HarmonyLib;

[HarmonyPatch]
public class MissionConfigPatch
{
    [HarmonyPatch(typeof(MissionConfig.DirectMission), "GetBaseMoneyJob")]
    class GetBaseMoneyJobPatch
    {
        static bool Prefix(ref int __result)
        {
            __result = Plugin.baseMoney.Value;
            return false;
        }
    }
}