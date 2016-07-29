using System.Collections.Generic;
using System.Linq;
using Comptroller.Core.Models;
using MvvmCross.Plugins.Sqlite;
using SQLite.Net;

namespace Comptroller.Core.DataManagers
{
	public class InstituteDataManager : IDataManager<Institute>
	{

		public InstituteDataManager(IMvxSqliteConnectionFactory factory)
		{
			_connection = factory.GetConnection("comptroller.sql");
			_connection.CreateTable<Institute>();
		}

		public List<Institute> GetAll()
		{
			var result = _connection.Table<Institute>()
				.OrderBy(institute => institute.Id)
				.ToList();
			return result;
		}

		public void Add(Institute item)
		{
			_connection.Insert(item);
		}

		public void Update(Institute item)
		{
			_connection.Update(item);
		}

		public void Delete(Institute item)
		{
			_connection.Delete(item);
		}

		private readonly SQLiteConnection _connection;
	}
}