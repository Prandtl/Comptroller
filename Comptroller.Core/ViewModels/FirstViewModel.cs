using System.Collections.Generic;
using System.Windows.Input;
using Comptroller.Core.Models;
using MvvmCross.Core.ViewModels;

namespace Comptroller.Core.ViewModels
{
	public class FirstViewModel
		: MvxViewModel
	{
		public List<Institute> Institutes
		{
			get { return _institutes; }
			set { SetProperty(ref _institutes, value); }
		}
		
		public ICommand AddInstituteCommand
		{
			get
			{
				_addInstituteCommand = _addInstituteCommand ?? new MvxCommand(AddNewInstitute);
				return _addInstituteCommand;
			}
		}

		private void AddNewInstitute()
		{
			ShowViewModel<AddInstituteViewModel>();
		}


		private List<Institute> _institutes;
		private MvxCommand _addInstituteCommand;
	}

}