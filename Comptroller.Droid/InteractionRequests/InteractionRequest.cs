using System;

namespace Comptroller.Droid.InteractionRequests
{
	public class InteractionRequest<T> : IInteractionRequest
	{
		public event EventHandler<InteractionRequestedEventArgs> Raised;

		public void Raise(T context, Action<T> callback)
		{
			var handler = Raised;
			handler?.Invoke(
				this,
				new InteractionRequestedEventArgs(
					context,
					() => callback(context)));
		}
	}
}