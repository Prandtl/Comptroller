using Comptroller.Core.Services.DataStore;
using MvvmCross.Test.Core;
using NUnit.Framework;

namespace Comptroller.Tests
{
	[TestFixture]
	public class InstituteRepositoryTests : MvxIoCSupportingTest//todo: надо разобраться как создавать InstituteRepository
	{
		[SetUp]
		public void SetupTest()
		{
			Setup();
		}

		[Test]
		public void TestTest()
		{
		}

		private readonly InstituteRepository _instituteRepository;
	}
}
