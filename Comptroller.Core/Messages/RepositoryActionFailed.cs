using Comptroller.Core.Repositories;
using MvvmCross.Plugins.Messenger;

namespace Comptroller.Core.Messages
{
	public class RepositoryActionFailed<TRepository>:MvxMessage where TRepository:IRepository
	{

		public RepositoryActionFailed(object sender, TRepository repository, string message) : base(sender)
		{
			Repository = repository;
			_message = message;
		}

		public string GetMessage()
		{
			return _message;
		}

		public TRepository Repository { get; private set; }


		private readonly string _message;

	}
}