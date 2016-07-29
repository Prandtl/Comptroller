using System.Collections.Generic;

namespace Comptroller.Core.Services.DataStore
{
	public interface IRepository<T>
	{
		List<T> GetAll();
		void Add(T item);
		void Update(T item);
		void Delete(T item);
	}
}