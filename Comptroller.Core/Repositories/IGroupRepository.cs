using System.Collections.Generic;
using Comptroller.Core.Models;

namespace Comptroller.Core.Repositories
{
	public interface IGroupRepository : IRepository
	{
		List<Group> GetAll();
		void Add(Group newGroup);
		void Update(Group group);
		void Delete(Group group);
	}
}