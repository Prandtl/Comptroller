using SQLite.Net.Attributes;

namespace Comptroller.Core.Models
{
	public class Institute
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }
		[NotNull]
		public string Name { get; set; }
	}
}