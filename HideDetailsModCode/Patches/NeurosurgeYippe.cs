using HarmonyLib;
using MegaCrit.Sts2.Core.Combat;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Extensions;
using MegaCrit.Sts2.Core.Models.Cards;
using MegaCrit.Sts2.Core.Random;

namespace HideDetailsMod.HideDetailsModCode.Patches;

[HarmonyPatch(typeof(Neurosurge), "OnPlay")]
class NeurosurgeYippe
{
    // HideDetailsMod/audio/{filename}
    // .wav or .ogg only
    static string[] Assets => [
        "Yippee.wav"
    ];
    static public void Prefix(CardPlay cardPlay)
    {
        if (MyModConfig.UseSimpleMode) return;
        if (!MyModConfig.EnableCardSound) return;
        if (Assets.Length == 0) return;
        if (!MyModConfig.EnableRepeatSound && CombatManager.Instance.History.CardPlaysFinished.Any(entry => entry.Actor == cardPlay.Player.Creature && entry.CardPlay.Card is Neurosurge)) return;
        var chosen = Assets.Length == 1 ? Assets.First() : Assets.TakeRandom(1, Rng.Chaotic).First();
        // TODO: mess with pitchVariation
        MainFile.Audio.PlaySfx(chosen /*,pitchVariation: .3f*/);
    }
}