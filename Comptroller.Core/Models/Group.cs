using System;
using System.Diagnostics.Contracts;
using SQLite.Net.Attributes;

namespace Comptroller.Core.Models
{
	public class Group
	{
		public Group(string name, Institute institute)
		{
			Id = 0;
			Name = name;
			InstituteId = institute.Id;
		}

		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }
		[NotNull, Indexed(Name = "InstituteGroup", Order = 1, Unique = true)]
		public string Name { get; set; }
		[NotNull, Indexed(Name = "InstituteGroup", Order = 2, Unique = true)]
		public int InstituteId { get; set; }

		public override string ToString()
		{
			return Name;
		}
	}
}