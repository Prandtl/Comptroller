using Comptroller.Core.Models;
using Comptroller.Core.Repositories;
using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.Messenger;

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

		private string _instituteName;
		private Institute _institute;

		private IInstituteRepository _instituteRepository;
	}
}