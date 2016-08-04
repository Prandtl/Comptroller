using System.Reflection;
using Comptroller.Core.Repositories;
using MvvmCross.Plugins.Messenger;

namespace Comptroller.Core.Messages
{
	public class RepositoryChangedMessage<T> : MvxMessage
	{
		public RepositoryChangedMessage(object sender, IRepository<T> changedRepository, Method method, T changedItem) : base(sender)
		{
			Method = method;
			Repository = changedRepository;
			ChangedItem = changedItem;
		}

		public Method Method { get; private set; }
		public IRepository<T> Repository { get; private set; }
		public T ChangedItem { get; private set; }
	}

	public enum Method
	{
		Delete,
		Add,
		Update,

	}
}