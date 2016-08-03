using System.Windows.Input;
using Comptroller.Core.Models;
using MvvmCross.Core.ViewModels;

namespace Comptroller.Core.ViewModels
{
	public class InstituteDetailsViewModel : MvxViewModel
	{
		public Institute Institute
		{
			get { return _institute; }
			set { SetProperty(ref _institute, value); }
		}

		public ICommand DeleteInstituteCommand
		{
			get
			{
				_deleteInstituteCommand = _deleteInstituteCommand ?? new MvxCommand(DeleteInstitute);
				return _deleteInstituteCommand;
			}
		}

		public ICommand ChangeInstituteNameCommand
		{
			get
			{
				_changeInstituteNameCommand = _changeInstituteNameCommand ?? new MvxCommand(ChangeInstituteName);
				return _changeInstituteNameCommand;
			}
		}

		public ICommand GoBackCommand
		{
			get
			{
				_goBackCommand = _goBackCommand ?? new MvxCommand(GoBack);
				return _goBackCommand;
			}
		}

		private void DeleteInstitute()
		{
			//todo:Alert?
		}

		private void ChangeInstituteName()
		{
			throw new System.NotImplementedException();
		}

		private void GoBack()
		{
			throw new System.NotImplementedException();
		}

		private Institute _institute;
		private MvxCommand _deleteInstituteCommand;
		private MvxCommand _changeInstituteNameCommand;
		private MvxCommand _goBackCommand;
	}
}