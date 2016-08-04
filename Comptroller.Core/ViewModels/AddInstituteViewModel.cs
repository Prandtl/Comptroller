using System.Threading.Tasks;
using System.Windows.Input;
using Comptroller.Core.Messages;
using Comptroller.Core.Models;
using Comptroller.Core.Repositories;
using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.Messenger;

namespace Comptroller.Core.ViewModels
{
	public class AddInstituteViewModel : MvxViewModel
	{
		public AddInstituteViewModel(IInstituteRepository instituteRepository, IMvxMessenger messenger)
		{
			_instituteRepository = instituteRepository;
			_messenger = messenger;
			_token = messenger.Subscribe<RepositoryActionFailed<Institute>>(OnActionFailed);
			_token = messenger.Subscribe<RepositoryChangedMessage<Institute>>(OnRepoChanged);
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
			if (string.IsNullOrWhiteSpace(InstituteName))
			{
				ErrorMessage = "Имя не может быть пустым";//todo: strings from file;
				CleanErrorText();
				return;
			}
			if (InstituteName.Contains("\n"))
			{
				ErrorMessage = "Имя должно быть написано в одну строку";
				CleanErrorText();
				return;
			}
			var newInstitute = new Institute() { Name = InstituteName };
			_instituteRepository.Add(newInstitute);
		}


		private void OnActionFailed(RepositoryActionFailed<Institute> message)
		{
			ErrorMessage = message.GetMessage();
			CleanErrorText();
		}

		private void OnRepoChanged(RepositoryChangedMessage<Institute> message)
		{
			if (message.Method != Method.Add) return;
			SuccessMessage = "Институт был успешно добавлен";
			CleanSuccessText();
		}


		private void CleanErrorText()
		{
			var t = Task.Delay(MessageDelay);
			Task.Factory.ContinueWhenAll(new[] { t }, (tasks) => ErrorMessage = "");
		}
		//todo: success and error are same but different color, think about it
		private void CleanSuccessText()
		{
			var t = Task.Delay(MessageDelay);
			Task.Factory.ContinueWhenAll(new[] {t}, (tasks) => SuccessMessage = "");
		}

		private string _instituteName;
		private string _errorMessage;
		private string _successMessage;

		private readonly IInstituteRepository _instituteRepository;
		private ICommand _addCommand;
		private MvxSubscriptionToken _token;
		private IMvxMessenger _messenger;


		private const int MessageDelay = 2500;
	}
}