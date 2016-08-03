using System.Windows.Input;
using MvvmCross.Core.ViewModels;

namespace Comptroller.Core.ViewModels
{
	public class InstituteDetailsViewModel : MvxViewModel
	{
		public string Name
		{
			get { return _name; }
			set { SetProperty(ref _name, value); }
		}

		public int GroupCount
		{
			get { return _groupCount; }
			set { SetProperty(ref _groupCount, value); }
		}

		public int StudentCount
		{
			get { return _studentCount; }
			set { SetProperty(ref _studentCount, value); }
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
			throw new System.NotImplementedException();
		}

		private void ChangeInstituteName()
		{
			throw new System.NotImplementedException();
		}

		private void GoBack()
		{
			throw new System.NotImplementedException();
		}

		private string _name;
		private int _groupCount;
		private int _studentCount;
		private MvxCommand _deleteInstituteCommand;
		private MvxCommand _changeInstituteNameCommand;
		private MvxCommand _goBackCommand;
	}
}