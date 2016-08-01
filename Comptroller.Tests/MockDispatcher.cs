using System;
using System.Collections.Generic;
using MvvmCross.Core.ViewModels;
using MvvmCross.Core.Views;
using MvvmCross.Platform.Core;

namespace Comptroller.Tests
{
	public class MockDispatcher
		: MvxMainThreadDispatcher
			, IMvxViewDispatcher
	{
		public readonly List<MvxViewModelRequest> Requests = new List<MvxViewModelRequest>();

		public bool RequestMainThreadAction(Action action)
		{
			action();
			return true;
		}

		public bool ShowViewModel(MvxViewModelRequest request)
		{
			Requests.Add(request);
			return true;
		}

		public bool ChangePresentation(MvxPresentationHint hint)
		{
			throw new NotImplementedException();
		}
	}
}