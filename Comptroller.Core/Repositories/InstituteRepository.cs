using System;
using System.Collections.Generic;
using System.Linq;
using Comptroller.Core.DataManagers;
using Comptroller.Core.Models;

namespace Comptroller.Core.Repositories
{
	public class InstituteRepository : IInstituteRepository
	{
		public InstituteRepository(IDataManager<Institute> dataManager)
		{
			_dataManager = dataManager;
		}

		public List<Institute> GetAll()
		{
			return _dataManager.GetAll();
		}

		public void Add(Institute newInstitute)
		{
			if(GetAll().Select(x=>x.Name).Contains(newInstitute.Name))
				throw new Exception("Institute name is not unique");
			_dataManager.Add(newInstitute);
		}

		public void Update(Institute institute)
		{
			_dataManager.Update(institute);
		}

		public void Delete(Institute institute)
		{
			_dataManager.Delete(institute);
		}

		private IDataManager<Institute> _dataManager;
	}
}