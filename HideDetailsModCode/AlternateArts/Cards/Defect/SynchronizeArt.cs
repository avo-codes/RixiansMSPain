using System.Data;
using MegaCrit.Sts2.Core.Logging;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Cards;
namespace HideDetailsMod.HideDetailsModCode.AlternateArts.Cards;

public class SynchronizeArt : AlternateCardArt<Synchronize>
{
    static CardImg No_orb { get; } = new("defect/synchronize_no_orb");
    //static CardImg One_orb { get; } = new("defect/synchronize");
    static CardImg Two_orbs { get; } = new("defect/synchronize_two_orb");
    static CardImg Three_orbs { get; } = new("defect/synchronize_three_orb");
    static CardImg Four_orbs { get; } = new("defect/synchronize_four_orb");
    static CardImg More_orbs { get; } = new("defect/synchronize_five_orb");

    public override CardImg? Get(Synchronize card)
    {
        var state  = card.Owner.PlayerCombatState;
        if (state == null) return null;

        var unique_orbs = new HashSet<ModelId>();

        //Collect all orbs into a Set of unique types
        foreach (var orb in state.OrbQueue.Orbs)
        {
            unique_orbs.Add(orb.Id).ToString();
        }

        return unique_orbs.Count switch
        {
            0 => No_orb,
            1 => null,          // Made one orb the default
            2 => Two_orbs,
            3 => Three_orbs,
            4 => Four_orbs,
            5 or 6 or 7 or 8 or 9 or 10 => More_orbs,
            _ => null,
        };
    }
}