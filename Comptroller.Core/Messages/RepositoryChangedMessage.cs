using System.Reflection;
using Comptroller.Core.Repositories;
using MvvmCross.Plugins.Messenger;

namespace Comptroller.Core.Messages
{
	public class RepositoryChangedMessage<TRepository> : MvxMessage where TRepository : IRepository
	{
		public RepositoryChangedMessage(object sender, TRepository changedRepository, string method) : base(sender)
		{
			Method = method;
			Repository = changedRepository;
		}

		public string Method { get; private set; }
		public TRepository Repository { get; private set; }
	}
}