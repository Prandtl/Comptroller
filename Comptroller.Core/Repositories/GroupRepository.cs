using System.Collections.Generic;
using Comptroller.Core.DataManagers;
using Comptroller.Core.Models;

namespace Comptroller.Core.Repositories
{
	public class GroupRepository : IGroupRepository
	{
		public GroupRepository(IDataManager<Group> dataManager)
		{
			_dm = dataManager;
		}
		public List<Group> GetAll()
		{
			return _dm.GetAll();
		}

		public void Add(Group newInstitute)
		{
			_dm.Add(newInstitute);
		}

		public void Update(Group institute)
		{
			throw new System.NotImplementedException();
		}

		public void Delete(Group institute)
		{
			throw new System.NotImplementedException();
		}

		private IDataManager<Group> _dm;
	}
}