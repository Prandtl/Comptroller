using System.Collections.Generic;
using Comptroller.Core.DataManagers;
using Comptroller.Core.Messages;
using Comptroller.Core.Models;
using Comptroller.Core.Repositories;
using Moq;
using MvvmCross.Plugins.Messenger;
using MvvmCross.Test.Core;
using NUnit.Framework;

namespace Comptroller.Tests
{
	[TestFixture]
	public class InstituteRepositoryTests : MvxIoCSupportingTest
	{
		[SetUp]
		public void SetupMethod()
		{
			base.Setup();
			_instituteDmMock = new Mock<IDataManager<Institute>>();
			_messengerMock = new Mock<IMvxMessenger>();
			_instituteRepository = new InstituteRepository(_instituteDmMock.Object, _messengerMock.Object);
		}

		[Test]
		public void ShouldPassIfRepositoryAddsToDataManager()
		{
			var institute = new Institute { Name = "ИМКН" };
			_instituteRepository.Add(institute);
			_instituteDmMock.Verify(dm => dm.Add(It.Is<Institute>(inst => inst == institute)));
		}

		[Test]
		public void ShouldPassIfRepositoryReturnsEverythingFromDataManager()
		{
			var institute1 = new Institute { Id = 1, Name = "ИМКН" };
			var institute2 = new Institute { Id = 1, Name = "ИСПН" };
			var institute3 = new Institute { Id = 1, Name = "ИЕН" };
			var institutes = new List<Institute>() { institute1, institute2, institute3 };
			_instituteDmMock.Setup(x => x.GetAll()).Returns(institutes);
			var result = _instituteRepository.GetAll();
			Assert.Contains(institute1, result);
			Assert.Contains(institute2, result);
			Assert.Contains(institute3, result);
		}

		[Test]
		public void ShouldPassIfRepositoryDeletesElementFromDataManager()
		{
			var institute = new Institute { Id = 1, Name = "ИСПН" };
			_instituteRepository.Delete(institute);
			_instituteDmMock.Verify(dm => dm.Delete(It.Is<Institute>(inst => inst == institute)));
		}

		[Test]
		public void ShouldPassIfRepositoryUpdatesItemInDataManager()
		{
			const int id = 1;
			var institute = new Institute { Id = 1, Name = "ИСПН" };
			institute.Name = "ИМКН";
			_instituteRepository.Update(institute);
			_instituteDmMock.Verify(dm => dm.Update(It.Is<Institute>(inst => inst.Id == id)));
		}

		[Test]
		public void ShouldPassIfDataManagerDoesentAddItem()
		{
			var institute1 = new Institute { Id = 0, Name = "ИСПН" };
			var institute2 = new Institute { Id = 0, Name = "ИСПН" };
			var institutes = new List<Institute> { institute1 };
			_instituteDmMock.Setup(dm => dm.GetAll()).Returns(institutes);
			_instituteRepository.Add(institute2);
			_instituteDmMock.Verify(dm => dm.Add(It.IsAny<Institute>()), Times.Never);
		}

		[Test]
		public void ShouldPassIfDataManagerDoesntUpdateItem()
		{
			var institute1 = new Institute { Id = 0, Name = "ИСПН" };
			var institute2 = new Institute { Id = 0, Name = "ИСПН" };
			var institutes = new List<Institute> { institute1 };
			_instituteDmMock.Setup(dm => dm.GetAll()).Returns(institutes);
			_instituteRepository.Update(institute2);
			_instituteDmMock.Verify(dm => dm.Update(It.IsAny<Institute>()), Times.Never);
		}

		[Test]
		public void ShouldPassIfMessageIsSentOnDataChange()
		{
			_instituteRepository.Add(new Institute());
			_instituteRepository.Update(new Institute());
			_instituteRepository.Delete(new Institute());
			_messengerMock.Verify(mess => mess.Publish(It.IsAny<RepositoryChangedMessage<IInstituteRepository>>()), Times.Exactly(3));
		}

		private IInstituteRepository _instituteRepository;
		private Mock<IDataManager<Institute>> _instituteDmMock;
		private Mock<IMvxMessenger> _messengerMock;
	}
}
