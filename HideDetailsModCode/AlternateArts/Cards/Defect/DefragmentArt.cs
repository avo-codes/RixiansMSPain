using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Cards;

namespace HideDetailsMod.HideDetailsModCode.AlternateArts.Cards.Defect;

public class DefragmentArt : AlternateCardArt<Defragment>
{
    static CardImg UpgradedFocusStrike { get; } = new("defect/defragment_upgraded_focused_strike");
    
    public override CardImg? Get(Defragment card)
    {
        if (!Util.HasCard<FocusedStrike>(card.Owner)) return null;
        
        IEnumerable<CardModel> cards = Util.CardsOf(card.Owner);

        foreach(CardModel c in cards)
        {
            if (c is FocusedStrike) return c.IsUpgraded ? UpgradedFocusStrike : null;
        }
        return null;
    }


}
