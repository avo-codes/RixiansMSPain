using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Cards;
namespace HideDetailsMod.HideDetailsModCode.AlternateArts.Cards;

public class SynchronizeArt : AlternateCardArt<Synchronize>
{
    static CardImg One_orb { get; } = new("defect/synchronize_one_orb");
    static CardImg Two_orbs { get; } = new("defect/synchronize_two_orb");
    static CardImg Three_orbs { get; } = new("defect/synchronize_three_orb");
    static CardImg Four_orbs { get; } = new("defect/synchronize_four_orb");
    static CardImg More_orbs { get; } = new("defect/synchronize_five_orb");

    public override CardImg? Get(Synchronize card)
    {
        var state  = card.Owner.PlayerCombatState;
        if (state == null) return null;

        return state.OrbQueue.Orbs.Count switch
        {
            1 => One_orb,
            2 => Two_orbs,
            3 => Three_orbs,
            4 => Four_orbs,
            5 or 6 or 7 or 8 or 9 or 10 => More_orbs,
            _ => null,
        };
    }
}