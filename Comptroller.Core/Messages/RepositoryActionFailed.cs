using Comptroller.Core.Repositories;
using MvvmCross.Plugins.Messenger;

namespace Comptroller.Core.Messages
{
	public class RepositoryActionFailed<T>:MvxMessage
	{

		public RepositoryActionFailed(object sender, IRepository<T> repository, string message) : base(sender)
		{
			Repository = repository;
			_message = message;
		}

		public string GetMessage()
		{
			return _message;
		}

		public IRepository<T> Repository { get; private set; }


		private readonly string _message;

	}
}