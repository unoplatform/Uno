#nullable enable

using System.Numerics;

namespace Microsoft.UI.Composition.Interactions;

public partial class InteractionTracker : CompositionObject
{
	private InteractionTrackerState _state;

	private InteractionTracker(Compositor compositor, IInteractionTrackerOwner? owner = null) : base(compositor)
	{
		_state = new InteractionTrackerIdleState(this);
		Owner = owner;
		InteractionSources = new CompositionInteractionSourceCollection(compositor);
	}

	public IInteractionTrackerOwner? Owner { get; }

	public float MinScale { get; set; } = 1.0f;

	public float MaxScale { get; set; } = 1.0f;

	public float Scale { get; } = 1.0f;

	public Vector3 MinPosition { get; set; }

	public Vector3 MaxPosition { get; set; }

	public Vector3 Position { get; }

	public CompositionInteractionSourceCollection InteractionSources { get; }

	//internal Vector3 EffectivePositionInertiaDecayRate => PositionInertiaDecayRate ?? new Vector3(0.95f);

	public static InteractionTracker Create(Compositor compositor) => new InteractionTracker(compositor);

	public static InteractionTracker CreateWithOwner(Compositor compositor, IInteractionTrackerOwner owner) => new InteractionTracker(compositor, owner);

	internal void ChangeState(InteractionTrackerState newState) => _state = newState;

	public int TryUpdatePositionWithAdditionalVelocity(Vector3 velocityInPixelsPerSecond)
		=> TryUpdatePositionWithAdditionalVelocity(velocityInPixelsPerSecond, isInertiaFromImpulse: false);

	internal int TryUpdatePositionWithAdditionalVelocity(Vector3 velocityInPixelsPerSecond, bool isInertiaFromImpulse)
	{
		return _state.TryUpdatePositionWithAdditionalVelocity(velocityInPixelsPerSecond, isInertiaFromImpulse);
	}
}
