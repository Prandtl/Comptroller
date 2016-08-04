using Comptroller.Core.Messages;
using Comptroller.Core.Models;
using Comptroller.Core.Repositories;
using Comptroller.Core.ViewModels;
using Moq;
using MvvmCross.Core.Views;
using MvvmCross.Platform.Core;
using MvvmCross.Plugins.Messenger;
using MvvmCross.Test.Core;
using NUnit.Framework;

namespace Comptroller.Tests
{
	[TestFixture]
	public class InstituteAddViewModelTests : MvxIoCSupportingTest
	{

		[SetUp]
		public void SetupMethod()
		{
			Setup();

			_instituteRepositoryMoq = new Mock<IInstituteRepository>();
			_messengerMoq = new Mock<IMvxMessenger>();
			_viewModel = new AddInstituteViewModel(_instituteRepositoryMoq.Object, _messengerMoq.Object);
		}

		[Test]
		public void ShouldPassIfItAddsNewInstitute()
		{

			//arrange
			_viewModel.InstituteName = "ИМКН";
			base.ClearAll();

			var mockDispatcher = new MockDispatcher();
			Ioc.RegisterSingleton<IMvxViewDispatcher>(mockDispatcher);
			Ioc.RegisterSingleton<IMvxMainThreadDispatcher>(mockDispatcher);
			//act
			_viewModel.AddCommand.Execute(null);
			//assert
			_instituteRepositoryMoq.Verify(
				moq => moq.Add(It.Is<Institute>(institute => institute.Name == "ИМКН")), Times.Once);

		}

		[Test]
		public void ShouldFailIfInstituteWithoutNameIsCreated()
		{
			//arrange
			_viewModel.InstituteName = "";
			//act
			_viewModel.AddCommand.Execute(null);
			//assert
			_instituteRepositoryMoq.Verify(
				moq => moq.Add(It.Is<Institute>(institute => string.IsNullOrWhiteSpace(institute.Name))), Times.Never);
		}

		[Test]
		public void ShouldFailIfInstituteWithWhiteSpaceNameIsCreated()
		{
			//arrange
			_viewModel.InstituteName = "                  ";
			//act
			_viewModel.AddCommand.Execute(null);
			//assert
			_instituteRepositoryMoq.Verify(
				moq => moq.Add(It.Is<Institute>(institute => string.IsNullOrWhiteSpace(institute.Name))), Times.Never);
		}


		[Test]
		public void ShouldFailIfInstituteWithMultilineNameIsCreated()
		{

			//arrange
			_viewModel.InstituteName = "la \n lalala            ";
			//act
			_viewModel.AddCommand.Execute(null);
			//assert
			_instituteRepositoryMoq.Verify(
				moq => moq.Add(It.Is<Institute>(institute => institute.Name.Contains("\n"))), Times.Never);
		}

		[Test]
		public void ShouldPassIfAfterAttemtToCreateWithoutNameMessageIsSent()
		{
			//arrange
			_viewModel.InstituteName = null;
			//act
			_viewModel.AddCommand.Execute(null);
			//assert
			_messengerMoq.Verify(moq=>moq.Publish(It.IsAny<RepositoryActionFailed<Institute>>()));
		}

		[Test]
		public void ShouldPassIfAfterAttemtToCreateWithMultilineNameMessageIsSent()
		{
			//arrange
			_viewModel.InstituteName = "lala\nblabla";
			//act
			_viewModel.AddCommand.Execute(null);
			//assert
			_messengerMoq.Verify(moq => moq.Publish(It.IsAny<RepositoryActionFailed<Institute>>()));
		}



		private Mock<IInstituteRepository> _instituteRepositoryMoq;
		private AddInstituteViewModel _viewModel;
		private Mock<IMvxMessenger> _messengerMoq;
	}
}
