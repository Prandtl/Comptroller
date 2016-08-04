using System;
using System.Globalization;
using Comptroller.Core.Models;
using Comptroller.Core.Repositories;
using MvvmCross.Platform.Converters;

namespace Comptroller.Core.Converters
{
	public class InstituteToGroupCountValueConverter : MvxValueConverter<Institute, string>
	{
		public InstituteToGroupCountValueConverter(IGroupRepository repository)
		{
			_repository = repository;//todo: it works without constructor
		}

		protected override string Convert(Institute institute, Type targetType, object parameter, CultureInfo culture)
		{
			//var groups = _repository.GetAllFrom(institute);
			//return groups.Count;
			return institute.Name.ToLower() + "aaaaaaaaaaa";
		}

		private IGroupRepository _repository;
	}
}