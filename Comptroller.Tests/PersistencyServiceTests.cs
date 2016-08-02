using System;
using System.Collections.Generic;
using System.Linq;
using Comptroller.Core.DataManagers;
using Comptroller.Core.Messages;
using Comptroller.Core.Models;
using Comptroller.Core.Repositories;
using Comptroller.Core.Services;
using Moq;
using MvvmCross.Plugins.Messenger;
using MvvmCross.Test.Core;
using NUnit.Framework;

namespace Comptroller.Tests
{
	[TestFixture]
	public class PersistencyServiceTests : MvxIoCSupportingTest
	{
		private Mock<IDataManager<Group>> _dataManagerGroupMock;
		private Mock<IDataManager<Institute>> _dataManagerInstituteMock;
		private GroupRepository _groupRepository;
		private InstituteRepository _instituteRepository;
		private List<Institute> _institutes;
		private List<Group> _groups;
		private Mock<IMvxMessenger> _messengerMoq;

		[SetUp]
		public void SetupMethod()
		{
			ClearAll();

			_dataManagerGroupMock = new Mock<IDataManager<Group>>();
			_dataManagerInstituteMock = new Mock<IDataManager<Institute>>();
			_messengerMoq = new Mock<IMvxMessenger>();
			_groupRepository = new GroupRepository(_dataManagerGroupMock.Object);
			_instituteRepository = new InstituteRepository(_dataManagerInstituteMock.Object,_messengerMoq.Object);

			var institute1 = new Institute { Id = 0, Name = "ИМКН" };
			var institute2 = new Institute { Id = 1, Name = "ИСПН" };
			var institute3 = new Institute { Id = 2, Name = "ИЕН" };
			_institutes = new List<Institute>() { institute1, institute2, institute3 };

			var group11 = new Group("ПИ-301", institute1);
			var group12 = new Group("ФИ-301", institute1);
			var group21 = new Group("ЗК-301", institute2);
			var group22 = new Group("ЛТ-301", institute2);
			var group23 = new Group("ФБ-301", institute2);
			var group31 = new Group("НЗ-301", institute3);
			_groups = new List<Group> { group11, group12, group21, group22, group23, group31 };

		}

		[Test]
		public void ShouldPassIfGroupsAreDeletedOnInstituteDeletedMessage()
		{
			_dataManagerGroupMock.Setup(mq => mq.GetAll()).Returns(_groups);
			var persistencyService = new PersistencyService(_messengerMoq.Object, _groupRepository);

			persistencyService.OnDeletedInstitute(new RepositoryChangedMessage<Institute>(_instituteRepository,_instituteRepository,"delete",_institutes[1]));
			_dataManagerGroupMock.Verify(mq => mq.Delete(It.Is<Group>(gr => gr.InstituteId == 1)), Times.Exactly(3));

		}
	}
}