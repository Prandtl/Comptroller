using System;

namespace Comptroller.Droid.InteractionRequests
{
	public class InteractionRequestedEventArgs : EventArgs
	{
		public Action Callback { get; private set; }
		public object Context { get; private set; }
		public InteractionRequestedEventArgs(object context, Action callback)
		{
			Context = context;
			Callback = callback;
		}
	}
}