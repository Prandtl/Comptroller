﻿using System.Collections.Generic;
using Comptroller.Core.Models;

namespace Comptroller.Core.Repositories
{
	public interface IGroupRepository : IRepository<Group>
	{
		List<Group> GetAll();
		List<Group> GetAllFrom(Institute institute); 
		void Add(Group newGroup);
		void Update(Group group);
		void Delete(Group group);
	}
}