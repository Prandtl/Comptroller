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

		public void Add(Group newGroup)
		{
			_dm.Add(newGroup);
		}

		public void Update(Group group)
		{
			_dm.Update(group);
		}

		public void Delete(Group group)
		{
			_dm.Delete(group);
		}

		private IDataManager<Group> _dm;
	}
}