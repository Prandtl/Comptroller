using Comptroller.Core.Repositories;
using MvvmCross.Plugins.Messenger;

namespace Comptroller.Core.Services
{
	class PersistencyService : IPersistencyService
	{
		public PersistencyService(IMvxMessenger messenger, IInstituteRepository instituteRepository, IGroupRepository groupRepository)
		{
			_messenger = messenger;
			_instituteRepository = instituteRepository;
			_groupRepository = groupRepository;
		}

		private IMvxMessenger _messenger;
		private IInstituteRepository _instituteRepository;
		private IGroupRepository _groupRepository;
	}
}