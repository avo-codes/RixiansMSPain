using HarmonyLib;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Cards;

namespace HideDetailsMod.HideDetailsModCode.AlternateArts;


[HarmonyPatch(typeof(DingyDagger), nameof(DingyDagger.Title), MethodType.Getter)]
public class DingyDaggerTitle
{
    [HarmonyPostfix]
    internal static void Intercept(ref CardModel? __instance, ref String __result)
    {
        if (__instance == null) return;
        if (!MyModConfig.HideTitle) return;
        __result = "";
    }
}
