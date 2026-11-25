using System;
using MegaCrit.Sts2.Core.Models.Cards;

namespace HideDetailsMod.HideDetailsModCode.AlternateArts;

public class DingyDaggerArt : AlternateCardArt<DingyDagger>
{
    static CardImg Dingy { get; } = new("event/dingy_dagger");
    static CardImg Fine { get; } = new("event/fine_dagger");
    static CardImg Pristine { get; } = new("event/pristine_dagger");

    public override CardImg? Get(DingyDagger card)
    {
        return card.CurrentUpgradeLevel switch
        {
            <=2 => Dingy,
            3 => Fine,
            4 => Fine,
            5 => Fine,
            _ => Pristine
        };
    }
}