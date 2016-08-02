using System.Collections.Generic;
using System.Linq;
using Comptroller.Core.Models;
using MvvmCross.Plugins.Sqlite;
using SQLite.Net;

namespace Comptroller.Core.DataManagers
{
	public class GroupDataManager:IDataManager<Group>
	{
		public GroupDataManager(IMvxSqliteConnectionFactory factory)
		{
			_connection = factory.GetConnection("comptroller.sql");
			_connection.CreateTable<Group>();
		}
		public List<Group> GetAll()
		{
			var groups = _connection.Table<Group>().OrderBy(x=>x.Id).ToList();
			return groups;
		}

		public void Add(Group item)
		{
			_connection.Insert(item);
		}

		public void Update(Group item)
		{
			_connection.Update(item);
		}

		public void Delete(Group item)
		{
			_connection.Delete(item);
		}

		private SQLiteConnection _connection;
	}
}