using MegaCrit.Sts2.Core.Models.Cards;
namespace HideDetailsMod.HideDetailsModCode.AlternateArts.Cards;

public class HelixDrillArt : AlternateCardArt<HelixDrill>
{
    static CardImg IfMachineLearning { get; } = new("defect/helix_drill_ml");

    public override CardImg? Get(HelixDrill card)
    {
        if (card.Owner.HasCard<MachineLearning>()) return IfMachineLearning;
        return null;
    }
}