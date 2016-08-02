using System.Collections.Generic;
using System.Linq;
using Comptroller.Core.DataManagers;
using Comptroller.Core.Messages;
using Comptroller.Core.Models;
using MvvmCross.Plugins.Messenger;

namespace Comptroller.Core.Repositories
{
	public class InstituteRepository : IInstituteRepository
	{
		public InstituteRepository(IDataManager<Institute> dataManager, IMvxMessenger messenger)
		{
			_dataManager = dataManager;
			_messenger = messenger;
		}

		public List<Institute> GetAll()
		{
			return _dataManager.GetAll();
		}

		public void Add(Institute newInstitute)
		{
			var all = GetAll();
			if (all != null)
			{
				if (all.Select(x => x.Name).Contains(newInstitute.Name))
				{
					_messenger.Publish(new RepositoryActionFailed<Institute>(this, this, $"Institute with name '{newInstitute.Name}' already exists."));
					return;
				}
			}
			_dataManager.Add(newInstitute);
			_messenger.Publish(new RepositoryChangedMessage<Institute>(this, this, "add", newInstitute));
		}

		public void Update(Institute institute)
		{
			var all = GetAll();
			if (all != null)
			{
				if (all.Select(x => x.Name).Contains(institute.Name))
				{
					_messenger.Publish(new RepositoryActionFailed<Institute>(this, this, $"Institute with name '{institute.Name}' already exists."));
					return;
				}
			}
			_dataManager.Update(institute);
			_messenger.Publish(new RepositoryChangedMessage<Institute>(this, this, "update", institute));
		}

		public void Delete(Institute institute)
		{
			_dataManager.Delete(institute);
			_messenger.Publish(new RepositoryChangedMessage<Institute>(this, this, "delete", institute));
		}

		private readonly IDataManager<Institute> _dataManager;
		private readonly IMvxMessenger _messenger;
	}
}