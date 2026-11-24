using Godot;
using HarmonyLib;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.HoverTips;
using MegaCrit.Sts2.Core.Logging;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Cards;
using MegaCrit.Sts2.Core.Nodes.Cards;
using MegaCrit.Sts2.Core.Nodes.HoverTips;
using MegaCrit.Sts2.Core.Nodes.Screens;
namespace HideDetailsMod.HideDetailsModCode.Patches;

[HarmonyPatch(typeof(NCard), nameof(NCard.SetPortraitTexture))]
public class AncientBigPortraitPatch
{
    internal static void Prefix(ref Texture2D texture, ref NCard __instance)
    {
        texture = __instance.Model.Portrait;
    }
}
