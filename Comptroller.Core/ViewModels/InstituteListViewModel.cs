using System.Collections.Generic;
using System.Windows.Input;
using Acr.UserDialogs;
using Comptroller.Core.Messages;
using Comptroller.Core.Models;
using Comptroller.Core.Repositories;
using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.Messenger;

namespace Comptroller.Core.ViewModels
{
	public class InstituteListViewModel
		: MvxViewModel
	{
		public InstituteListViewModel(IMvxMessenger messenger, IInstituteRepository repository, IUserDialogs dialogs)
		{
			_dialogs = dialogs;
			_instituteRepository = repository;
			_token = messenger.Subscribe<RepositoryChangedMessage<Institute>>(OnChangedRepository);
			Refresh();
		}


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
		public ICommand ShowInstituteDetailsCommand
		{
			get
			{
				return new MvxCommand<Institute>(item => ShowDetails(item));
			}
		}

		private void ShowDetails(Institute item)
		{
			var nav = new InstituteDetailsViewModel.Nav() { Id = item.Id };
			ShowViewModel<InstituteDetailsViewModel>(nav);
		}

		private void AddNewInstitute()
		{
			ShowViewModel<AddInstituteViewModel>();
		}

		private void OnChangedRepository(RepositoryChangedMessage<Institute> obj)
		{
			Refresh();
		}
		private void Refresh()
		{
			Institutes = _instituteRepository.GetAll();
		}

		private List<Institute> _institutes;
		private MvxCommand _addInstituteCommand;

		private IInstituteRepository _instituteRepository;
		private MvxSubscriptionToken _token;
		private IUserDialogs _dialogs;
	}

}