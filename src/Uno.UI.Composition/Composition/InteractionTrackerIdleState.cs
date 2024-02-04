#nullable enable

using System.Numerics;

namespace Microsoft.UI.Composition.Interactions;

internal sealed class InteractionTrackerIdleState : InteractionTrackerState
{
	public InteractionTrackerIdleState(InteractionTracker interactionTracker) : base(interactionTracker)
	{
	}

	protected override void EnterState(IInteractionTrackerOwner owner)
	{
		owner.IdleStateEntered(_interactionTracker, null);
	}

	internal override void ReceiveUserManipulation()
	{
		_interactionTracker.ChangeState(new InteractionTrackerInteractingState(_interactionTracker));
	}

	internal override void CompleteUserManipulation()
	{
	}

	internal override int TryUpdatePositionWithAdditionalVelocity(Vector3 velocityInPixelsPerSecond, bool isInertiaFromImpulse)
	{
		// State changes to inertia and inertia modifiers are evaluated with requested velocity as initial velocity
		// TODO: Understand more the "inertia modifiers" part.
		_interactionTracker.ChangeState(new InteractionTrackerInertiaState(_interactionTracker));

		// TODO: Return RequestId
		return 0;
	}
}
