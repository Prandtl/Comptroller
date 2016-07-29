using Comptroller.Core.DataManagers;
using Comptroller.Core.Models;
using Comptroller.Core.Repositories;
using Moq;
using MvvmCross.Test.Core;
using NUnit.Framework;

namespace Comptroller.Tests
{
	[TestFixture]
	public class InstituteRepositoryShould : MvxIoCSupportingTest
	{
		[SetUp]
		public void SetupTest()
		{
			base.Setup();
		}

		[Test]
		public void BeAbleToPutElements()
		{
			var institute = new Institute() {Name = "ИМКН"};
			var mockDataManager = new Mock<IDataManager<Institute>>();
			_instituteRepository = new InstituteRepository(mockDataManager.Object);
			_instituteRepository.Add(institute);
			mockDataManager.Verify(dm=>dm.Add(It.IsAny<Institute>()));
		}

		private IInstituteRepository _instituteRepository;
	}
}
