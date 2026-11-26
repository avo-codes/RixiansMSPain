using Godot;

namespace HideDetailsMod.HideDetailsModCode.Scenes.CharacterSelect;

public partial class DefectBg : Control
{
    [Export]
	private Vector2 radius = new(5.0f, 15.0f);

    [Export]
	private float speed = 0.25f;

    [Export]
	private float maxTiltDegrees = 10.0f; // Significantly reduced for a very gentle sway

    readonly List<float> Offsets = [0, 0.6283f, 1.2566f, 1.8849f, 2.5132f];

#nullable disable
    private TextureRect frost;
    private TextureRect lightning;
    private TextureRect plasma;
    private TextureRect glass;
    private TextureRect dark;
#nullable restore

    private Vector2 frostCenterPoint;
    private Vector2 lightningCenterPoint;
    private Vector2 plasmaCenterPoint;
    private Vector2 glassCenterPoint;
    private Vector2 darkCenterPoint;
    private float angle = 0.0f;

    public override void _Ready()
    {
        frost = GetNode<TextureRect>("%Frost");
        lightning = GetNode<TextureRect>("%Lightning");
        plasma = GetNode<TextureRect>("%Plasma");
        glass = GetNode<TextureRect>("%Glass");
        dark = GetNode<TextureRect>("%Darkness");

        if (frost != null)
		{
			frostCenterPoint = frost.Position;
			frost.PivotOffset = frost.Size / 2.0f;
		}

        if (lightning != null)
		{
			lightningCenterPoint = lightning.Position;
			lightning.PivotOffset = lightning.Size / 2.0f;
		}

        if (plasma != null)
		{
			plasmaCenterPoint = plasma.Position;
			plasma.PivotOffset = plasma.Size / 2.0f;
		}

        if (glass != null)
		{
			glassCenterPoint = glass.Position;
			glass.PivotOffset = glass.Size / 2.0f;
		}

        if (dark != null)
		{
			darkCenterPoint = dark.Position;
			dark.PivotOffset = dark.Size / 2.0f;
		}
    }

    public override void _Process(double delta)
    {
        if (frost == null) return;
        if (lightning == null) return;
        if (plasma == null) return;
        if (glass == null) return;
        if (dark == null) return;

        MoveOrb(frost, frostCenterPoint, delta,Offsets[0]);
        MoveOrb(lightning, lightningCenterPoint, delta, Offsets[1]);
        MoveOrb(plasma, plasmaCenterPoint, delta, Offsets[2]);
        MoveOrb(glass, glassCenterPoint, delta, Offsets[3]);
        MoveOrb(dark, darkCenterPoint, delta, Offsets[4]);
    }

    private void MoveOrb(TextureRect orb, Vector2 center, double delta, float offset)
    {
        // 1. Oval Position
        angle += speed * (float)delta + offset;
        
        float x = center.X + (Mathf.Cos(angle) * radius.X);
        float y = center.Y + (Mathf.Sin(angle) * radius.Y);

        orb.Position = new Vector2(x, y);

        // 2. Subtle tilt calculation (smoothed way down)
        float tiltFactor = Mathf.Cos(angle);
        float maxTiltRadians = Mathf.DegToRad(maxTiltDegrees);

        // 3. Apply rotation
        orb.Rotation = tiltFactor * maxTiltRadians;
    }
}