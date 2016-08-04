using System.Windows.Input;
using Acr.UserDialogs;
using Comptroller.Core.Models;
using Comptroller.Core.Repositories;
using MvvmCross.Core.ViewModels;

namespace Comptroller.Core.ViewModels
{
	public class InstituteDetailsViewModel : MvxViewModel
	{
		public InstituteDetailsViewModel(IInstituteRepository repository,IUserDialogs dialogs)
		{
			_dialogs = dialogs;
			_repository = repository;
		}

		public void Init(Nav nav)
		{
			Institute = _repository.GetById(nav.Id);
		}

		public class Nav
		{
			public int Id { get; set; }
		}

		public Institute Institute
		{
			get { return _institute; }
			set { SetProperty(ref _institute, value); }
		}

		public ICommand DeleteInstituteCommand
		{
			get
			{
				_deleteInstituteCommand = _deleteInstituteCommand ?? new MvxCommand(PromptDeleteInstitute);
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

		private void PromptDeleteInstitute()
		{
			var conf = new ConfirmConfig
			{
				Message = "This will delete institute, all groups in it and students in it.\n Are you sure?",
				OkText = "Definetly, YES",
				CancelText = "Cancel",
				OnConfirm = OnConfirmDeleteInstitute
			};


			_dialogs.Confirm(conf);
		}

		private void OnConfirmDeleteInstitute(bool choice)
		{
			if (!choice) return;
			_repository.Delete(Institute);
			Close(this);
		}

		private void ChangeInstituteName()
		{
			throw new System.NotImplementedException();
		}

		private void GoBack()
		{
			Close(this);
		}

		private Institute _institute;
		private MvxCommand _deleteInstituteCommand;
		private MvxCommand _changeInstituteNameCommand;
		private MvxCommand _goBackCommand;
		private IUserDialogs _dialogs;
		private IInstituteRepository _repository;
	}
}