using System.Linq;
using Comptroller.Core.Messages;
using Comptroller.Core.Models;
using Comptroller.Core.Repositories;
using MvvmCross.Plugins.Messenger;

namespace Comptroller.Core.Services
{
	public class PersistencyService : IPersistencyService
	{
		public PersistencyService(IMvxMessenger messenger, IGroupRepository groupRepository)
		{
			_messenger = messenger;
			_groupRepository = groupRepository;
			_token = _messenger.Subscribe<RepositoryChangedMessage<Institute>>(OnDeletedInstitute);
		}

		public void OnDeletedInstitute(RepositoryChangedMessage<Institute> message)
		{
			if (message.Method != "delete") //todo:превести методы датамэнеджера в енум
				return;
			var id = message.ChangedItem.Id;
			var toDelete = _groupRepository.GetAll().Where(g => g.InstituteId == id);//todo:метод который возвращает все группы из данного института
			foreach (var group in toDelete)
			{
				_groupRepository.Delete(group);
			}
		}

		private readonly IMvxMessenger _messenger;
		private IGroupRepository _groupRepository;
		private MvxSubscriptionToken _token;
	}
}