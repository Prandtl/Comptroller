using System.Collections.Generic;
using Comptroller.Core.Models;

namespace Comptroller.Core.Repositories
{
	public interface IGroupRepository : IRepository
	{
		List<Group> GetAll();
		void Add(Group newInstitute);
		void Update(Group institute);
		void Delete(Group institute);
	}
}