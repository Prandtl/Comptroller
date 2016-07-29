using System.Collections.Generic;

namespace Comptroller.Core.DataManagers
{
	public interface IDataManager<T>
	{
		List<T> GetAll();
		void Add(T item);
		void Update(T item);
		void Delete(T item);
	}
}