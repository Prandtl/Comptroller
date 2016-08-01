using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using Comptroller.Core.DataManagers;
using Comptroller.Core.Models;
using Comptroller.Core.Repositories;
using Moq;
using MvvmCross.Test.Core;
using NUnit.Framework;

namespace Comptroller.Tests
{
	[TestFixture]
	public class InstituteRepositoryShould
	{
		[Test]
		public void BeAbleToPutElements()
		{
			var institute = new Institute { Name = "ИМКН" };
			var mockDataManager = new Mock<IDataManager<Institute>>();
			_instituteRepository = new InstituteRepository(mockDataManager.Object);
			_instituteRepository.Add(institute);
			mockDataManager.Verify(dm => dm.Add(It.Is<Institute>(inst => inst == institute)));
		}

		[Test]
		public void BeAbleToGetAllElements()
		{
			var institute1 = new Institute { Id = 1, Name = "ИМКН" };
			var institute2 = new Institute { Id = 1, Name = "ИСПН" };
			var institute3 = new Institute { Id = 1, Name = "ИЕН" };
			var mockDataManager = new Mock<IDataManager<Institute>>();
			var institutes = new List<Institute>() { institute1, institute2, institute3 };
			mockDataManager.Setup(x => x.GetAll()).Returns(institutes);
			_instituteRepository = new InstituteRepository(mockDataManager.Object);
			var result = _instituteRepository.GetAll();
			Assert.Contains(institute1, result);
			Assert.Contains(institute2, result);
			Assert.Contains(institute3, result);
		}

		[Test]
		public void BeAbleToDeleteAnElement()
		{
			var institute = new Institute { Id = 1, Name = "ИСПН" };
			var mockDataManager = new Mock<IDataManager<Institute>>();
			_instituteRepository = new InstituteRepository(mockDataManager.Object);
			_instituteRepository.Delete(institute);
			mockDataManager.Verify(dm => dm.Delete(It.Is<Institute>(inst => inst == institute)));
		}

		[Test]
		public void ShouldBeAbleToUpdateAnItem()
		{
			const int id = 1;
			var institute = new Institute { Id = 1, Name = "ИСПН" };
			var mockDataManager = new Mock<IDataManager<Institute>>();
			_instituteRepository = new InstituteRepository(mockDataManager.Object);
			institute.Name = "ИМКН";
			_instituteRepository.Update(institute);
			mockDataManager.Verify(dm => dm.Update(It.Is<Institute>(inst => inst.Id == id)));
		}

		[Test]
		public void ShouldNotAddTwoInstitutesWithSameName()
		{
			var institute1 = new Institute { Id = 0, Name = "ИСПН" };
			var institute2 = new Institute { Id = 0, Name = "ИСПН" };
			var institutes = new List<Institute>() { institute1 };
			var mockDataManager = new Mock<IDataManager<Institute>>();
			mockDataManager.Setup(dm => dm.GetAll()).Returns(institutes);
			_instituteRepository = new InstituteRepository(mockDataManager.Object);
			Assert.Throws<Exception>(() => _instituteRepository.Add(institute2));
		}

		private IInstituteRepository _instituteRepository;
	}
}
