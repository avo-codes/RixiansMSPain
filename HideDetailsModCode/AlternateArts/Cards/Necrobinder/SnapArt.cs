using MegaCrit.Sts2.Core.Combat;
using MegaCrit.Sts2.Core.Combat.History.Entries;
using MegaCrit.Sts2.Core.Models.Cards;
using MegaCrit.Sts2.Core.Models.Monsters;

namespace HideDetailsMod.HideDetailsModCode.AlternateArts.Cards;

public class SnapArt : AlternateCardArt<Snap>
{
    static CardImg OstyDied { get; } = new("necrobinder/snap_if_osty_died");

    public override CardImg? Get(Snap card)
    {
        return (!card.Owner.IsOstyAlive && card.Owner.Osty != null) ? OstyDied : null;
    }
}