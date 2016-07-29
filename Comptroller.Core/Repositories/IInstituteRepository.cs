using System.Collections.Generic;
using Comptroller.Core.Models;

namespace Comptroller.Core.Repositories
{
	public interface IInstituteRepository
	{
		List<Institute> GetAll();
		void Add(Institute newInstitute);
		void Update(Institute institute);
		void Delete(Institute institute);
	}
}