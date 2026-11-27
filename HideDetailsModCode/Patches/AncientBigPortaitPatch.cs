using Godot;
using HarmonyLib;
using MegaCrit.Sts2.Core.Nodes.Cards;
namespace HideDetailsMod.HideDetailsModCode.Patches;

[HarmonyPatch(typeof(NCard), nameof(NCard.SetPortraitTexture))]
public class AncientBigPortraitPatch
{
    internal static void Prefix(ref Texture2D texture, ref NCard __instance)
    {
    if (MyModConfig.UseSimpleMode) return;
    if (!MyModConfig.MakeEverythingAncient) return;

    texture = __instance.Model.Portrait;
    }
}
