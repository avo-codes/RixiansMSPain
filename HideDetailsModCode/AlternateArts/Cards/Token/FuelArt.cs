using BaseLib.Extensions;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Cards;
using MegaCrit.Sts2.Core.Models.Powers;
namespace HideDetailsMod.HideDetailsModCode.AlternateArts.Cards;

public class FuelArt : AlternateCardArt<Fuel>
{
    // UltraKill!
    static CardImg Blood { get; } = new("token/fuel_blood");

    // The prerequisite is having any of Ironclads blood-related cards
    // (Bloodletting, Bloodwall, Rupture, Hemokinesis) in your deck /
    //  have Refract in your deck
    public override CardImg? Get(Fuel card)
    {
        if (card.Owner.HasPower<RupturePower>()) return Blood;
        if (Util.HasCard<Refract>(card.Owner)) return Blood;
        if (Util.HasCard<Bloodletting>(card.Owner)) return Blood;
        if (Util.HasCard<BloodWall>(card.Owner)) return Blood;
        if (Util.HasCard<Rupture>(card.Owner)) return Blood;
        if (Util.HasCard<Hemokinesis>(card.Owner)) return Blood;

        return null;
    }
}

