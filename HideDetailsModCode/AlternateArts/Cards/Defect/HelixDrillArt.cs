using MegaCrit.Sts2.Core.Models.Cards;
namespace HideDetailsMod.HideDetailsModCode.AlternateArts.Cards;

public class HelixDrillArt : AlternateCardArt<HelixDrill>
{
    static CardImg IfTea { get; } = new("defect/helix_drill_tea");

    public override CardImg? Get(HelixDrill card)
    {
        if (card.Owner.HasCard<MachineLearning>()) return IfTea;
        return null;
    }
}