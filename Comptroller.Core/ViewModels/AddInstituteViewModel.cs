using System.Threading.Tasks;
using System.Windows.Input;
using Comptroller.Core.Messages;
using Comptroller.Core.Models;
using Comptroller.Core.Repositories;
using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.Messenger;

namespace Comptroller.Core.ViewModels
{
	class AddInstituteViewModel : MvxViewModel
	{
		public AddInstituteViewModel(IInstituteRepository instituteRepository, IMvxMessenger messenger)
		{
			_instituteRepository = instituteRepository;
			_token = messenger.Subscribe<RepositoryActionFailed<IInstituteRepository>>(OnActionFailed);
			_token = messenger.Subscribe<RepositoryChangedMessage<IInstituteRepository>>(OnRepoChanged);
		}

		public string InstituteName
		{
			get { return _instituteName; }
			set { SetProperty(ref _instituteName, value); }
		}

		public string ErrorMessage
		{
			get { return _errorMessage; }
			set { SetProperty(ref _errorMessage, value); }
		}

		public string SuccessMessage
		{
			get { return _successMessage; }
			set { SetProperty(ref _successMessage, value); }
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

		private void OnActionFailed(RepositoryActionFailed<IInstituteRepository> message)
		{
			ErrorMessage = message.GetMessage();
			var t = Task.Delay(MessageDelay);
			Task.Factory.ContinueWhenAll(new[] { t }, (tasks) => ErrorMessage = "");
		}

		private void OnRepoChanged(RepositoryChangedMessage<IInstituteRepository> message)
		{
			if (message.Method != Method.Add) return;
			SuccessMessage = "Институт был успешно добавлен";
			var t =  Task.Delay(MessageDelay);
			Task.Factory.ContinueWhenAll(new []{t}, (tasks) => SuccessMessage = "");
		}

		private string _instituteName;
		private string _errorMessage;
		private string _successMessage;

		private readonly IInstituteRepository _instituteRepository;
		private ICommand _addCommand;
		private MvxSubscriptionToken _token;


		private const int MessageDelay = 2500;
	}
}