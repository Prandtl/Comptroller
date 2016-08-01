using System.Windows.Input;
using Comptroller.Core.Models;
using Comptroller.Core.Repositories;
using MvvmCross.Core.ViewModels;

namespace Comptroller.Core.ViewModels
{
	class AddInstituteViewModel : MvxViewModel
	{
		public AddInstituteViewModel(IInstituteRepository instituteRepository)
		{
			_instituteRepository = instituteRepository;
		}

		public string InstituteName
		{
			get { return _instituteName; }
			set { SetProperty(ref _instituteName, value); }
		}

		public Institute Institute
		{
			get { return _institute; }
			set { SetProperty(ref _institute, value); }
		}

		public ICommand AddCommand
		{
			get
			{
				_addCommand = _addCommand ?? new MvxCommand(AddInstitute);
				return _addCommand;
			}
		}

		public ICommand GoBackCommand
		{
			get
			{
				return new MvxCommand(() => Close(this));
			}
		}

		private void AddInstitute()
		{
			var newInstitute = new Institute() { Name = InstituteName };
			_instituteRepository.Add(newInstitute);
		}

		private string _instituteName;
		private Institute _institute;

		private readonly IInstituteRepository _instituteRepository;
		private ICommand _addCommand;
	}
}