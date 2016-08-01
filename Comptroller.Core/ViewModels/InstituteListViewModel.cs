using System.Collections.Generic;
using System.Windows.Input;
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
		public InstituteListViewModel(IMvxMessenger messenger, IInstituteRepository repository)
		{
			_instituteRepository = repository;
			_token = messenger.Subscribe<RepositoryChangedMessage<IInstituteRepository>>(OnChangedRepository);
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

		private void AddNewInstitute()
		{
			ShowViewModel<AddInstituteViewModel>();
		}

		private void OnChangedRepository(RepositoryChangedMessage<IInstituteRepository> obj)
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
	}

}