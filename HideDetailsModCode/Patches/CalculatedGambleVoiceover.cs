using HarmonyLib;
using MegaCrit.Sts2.Core.Combat;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Models.Cards;

namespace HideDetailsMod.HideDetailsModCode.Patches;

[HarmonyPatch(typeof(CalculatedGamble), "OnPlay")]
class CalculatedGambleVoiceover
{
    // HideDetailsMod/audio/{filename}
    // .wav or .ogg only
    static string[] Assets => [
        "GambleAllIn.wav"
    ];
    static public void Prefix(CardPlay cardPlay)
    {
        if (MyModConfig.UseSimpleMode) return;
        if (!MyModConfig.EnableCardSound) return;
        if (Assets.Length == 0) return;
        if (!MyModConfig.EnableRepeatSound && CombatManager.Instance.History.CardPlaysFinished.Any(entry => entry.Actor == cardPlay.Player.Creature && entry.CardPlay.Card is CalculatedGamble)) return;
        MainFile.Audio.PlaySfx(Assets.First(), volume: 2);
    }
}