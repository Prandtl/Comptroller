using System;

namespace Comptroller.Droid.InteractionRequests
{
	public interface IInteractionRequest
	{
		event EventHandler<InteractionRequestedEventArgs> Raised;
	}
}