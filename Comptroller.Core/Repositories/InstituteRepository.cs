using System;
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
					throw new Exception("Institute name is not unique");
			}
			_dataManager.Add(newInstitute);
			_messenger.Publish(new RepositoryChangedMessage<IInstituteRepository>(this,this,"add"));
		}

		public void Update(Institute institute)
		{
			//todo same as add no double names
			_dataManager.Update(institute);
			_messenger.Publish(new RepositoryChangedMessage<IInstituteRepository>(this, this, "update"));
		}

		public void Delete(Institute institute)
		{
			_dataManager.Delete(institute);
			_messenger.Publish(new RepositoryChangedMessage<IInstituteRepository>(this, this, "delete"));
		}

		private readonly IDataManager<Institute> _dataManager;
		private readonly IMvxMessenger _messenger;
	}
}