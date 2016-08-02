using System.Collections.Generic;
using Comptroller.Core.DataManagers;
using Comptroller.Core.Models;
using Comptroller.Core.Repositories;
using Moq;
using MvvmCross.Test.Core;
using NUnit.Framework;

namespace Comptroller.Tests
{
	[TestFixture]
	public class GroupRepositoryTests : MvxIoCSupportingTest
	{
		[SetUp]
		public void SetupMethod()
		{
			Setup();

			_dataManagerMock = new Mock<IDataManager<Group>>();

			_groupRepository = new GroupRepository(_dataManagerMock.Object);

			var institute1 = new Institute { Id = 0, Name = "ИМКН" };
			var institute2 = new Institute { Id = 1, Name = "ИСПН" };
			var institute3 = new Institute { Id = 2, Name = "ИЕН" };
			_institutes = new List<Institute>() { institute1, institute2, institute3 };

			var group11 = new Group { Id = 0, InstituteId = 0, Name = "ПИ-301" };
			var group12 = new Group { Id = 1, InstituteId = 0, Name = "ФИ-301" };
			var group21 = new Group { Id = 2, InstituteId = 1, Name = "ЗК-301" };
			var group22 = new Group { Id = 3, InstituteId = 1, Name = "ЛТ-301" };
			var group23 = new Group { Id = 4, InstituteId = 1, Name = "ФБ-301" };
			var group31 = new Group { Id = 5, InstituteId = 2, Name = "НЗ-301" };
			_groups = new List<Group> { group11, group12, group21, group22, group23, group31 };
		}

		[Test]
		public void ShouldFailIfRepositoryCantGetElements()
		{
			//arrange
			_dataManagerMock.Setup(dm => dm.GetAll()).Returns(_groups);
			//act
			var result = _groupRepository.GetAll();
			//assert
			foreach (var group in _groups)
			{
				Assert.Contains(group, result);
			}
		}

		[Test]
		public void ShouldPassIfRepositoryAddsElementToDataManager()
		{
			//arrange
			//act
			_groupRepository.Add(_groups[0]);
			//assert
			_dataManagerMock.Verify(dm => dm.Add(It.Is<Group>(g => g == _groups[0])));
		}

		[Test]
		public void ShouldPassIfRepositoryDeletesItemFromDataManager()
		{
			//arrange
			//act
			_groupRepository.Delete(_groups[0]);
			//assert
			_dataManagerMock.Verify(dm=>dm.Delete(It.IsAny<Group>()));
		}

		[Test]
		public void ShouldPassIfRepositoryUpdatesItemInDataManager()
		{
			//arrange
			//act
			_groupRepository.Update(_groups[0]);
			//assert
			_dataManagerMock.Verify(dm=>dm.Update(It.IsAny<Group>()));
		}

		[Test]
		public void ShouldPassIfGroupWasNotAddedInDataManager()
		{
			_dataManagerMock.Setup(dm => dm.GetAll()).Returns(_groups);
			//arrange
			var group = new Group() {Id = 6, InstituteId = 0, Name = "ПИ-301"};
			//act
			_groupRepository.Add(group);
			//assert
			_dataManagerMock.Verify(dm=>dm.Add(It.Is<Group>(gr=>gr==group)),Times.Never);
		}

		[Test]
		public void ShouldPassIfGroupWasNotUpdatedInDataManager()
		{
			_dataManagerMock.Setup(dm => dm.GetAll()).Returns(_groups);
			//arrange
			var group = new Group() { Id = 6, InstituteId = 0, Name = "ПИ-301" };
			//act
			_groupRepository.Update(group);
			//assert
			_dataManagerMock.Verify(dm => dm.Update(It.Is<Group>(gr => gr == group)), Times.Never);
		}

		private IGroupRepository _groupRepository;
		private Mock<IDataManager<Group>> _dataManagerMock;
		private List<Institute> _institutes;
		private List<Group> _groups;
	}
}