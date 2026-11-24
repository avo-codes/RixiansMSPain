using HarmonyLib;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Extensions;
using MegaCrit.Sts2.Core.Models.Cards;
using MegaCrit.Sts2.Core.Random;
using MegaCrit.Sts2.Core.Combat;

namespace HideDetailsMod.HideDetailsModCode.Patches;

[HarmonyPatch(typeof(Chaos), "OnPlay")]
class ChaosVoiceover
{
    // HideDetailsMod/audio/{filename}
    // .wav or .ogg only
    static string[] Assets => [
        "ChaosChaos.wav",
        "ChaosMetamorphosis.wav"
    ];
    static public void Prefix(CardPlay cardPlay)
    {
        if (MyModConfig.UseSimpleMode) return;
        if (!MyModConfig.EnableCardSFX) return;
        if (Assets.Length == 0) return;
        var MetamorphosisPlayedThisCombat = CombatManager.Instance.History
                 .CardPlaysFinished.Any(entry => entry.Actor == cardPlay.Player.Creature && entry.CardPlay.Card is Metamorphosis);
        var chosen = MetamorphosisPlayedThisCombat == true ? Assets.ElementAt(1) : Assets.First();
        // TODO: mess with pitchVariation
        MainFile.Audio.PlaySfx(chosen, volume:2 /*,pitchVariation: .3f*/);
    }
}