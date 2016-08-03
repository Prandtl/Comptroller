using System.Collections.Generic;
using System.Linq;
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

		public List<Group> GetAllFrom(Institute institute)
		{
			var result = GetAll()
				.Where(g => g.InstituteId == institute.Id)
				.ToList();
			return result;
		}

		public void Add(Group newGroup)
		{
			if (GroupHasADuplicate(newGroup))
				return;
			_dm.Add(newGroup);
		}

		public void Update(Group group)
		{
			if(GroupHasADuplicate(group))
				return;
			_dm.Update(group);
		}

		public void Delete(Group group)
		{
			_dm.Delete(group);
		}

		private bool GroupHasADuplicate(Group group)
		{
			return GetAll().Where(g => g.InstituteId == group.InstituteId).Any(g => g.Name.Equals(group.Name));
		}

		private readonly IDataManager<Group> _dm;
	}
}